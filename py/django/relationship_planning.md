# Quick Relationship Tips
- plural and singular convention is to help with readability and to remind yourself you are dealing with a single instance or a list of instances
- when to not use the `class` name as part of the attribute name:
  - when a more descriptive name is available, like **author**, **uploaded_by**, **sender**, **recipient**
    - all of those names would be to represent the ***one*** `User` instance in a relationship and provide more detail about the nature of the relationship than just using **user** as the attribute name, furthermore, these more descriptive names already imply it is a **user**

## ***one*** to ***many***
- the ForeignKey (FK) goes on the ***many***
- `attribute_name = models.ForeignKey` goes on the ***many***
    - `attribute_name` should be named after the ***one*** `class` (in some way) and should be singular
- `related_name` should be named plural and named after the ***many*** `class` because this name will be a hidden attribute that is auto added to the ***one*** `class` so that a single instance of the ***one*** `class` can use this attribute to access (via dot notation) a LIST of the ***many*** related instances

## ***many*** to ***many***
- each `class` will contain an attribute that is accessed via dot notation to get a LIST of the ***many*** related `class` instances
- `attribute_name = models.ManyToManyField` can go on either model `class`
    - `attribute_name` will be named after the related `class` and should be pluralized
- `related_name` will also be plural and named after the `class` that the `ManyToManyField` is inside
    - the name given to `related_name` will become a hidden attribute auto added onto the related `class` (the `class` that the `ManyToManyField` is not inside of)

## Accessing the ***many***: `.all` ORM method
- when accessing a `related_name` via dot notation, since it will be a query set, you need to use `.all` method to get all the ***many*** related instances.
- ***in jinja, no parenthesis to execute methods:*** `.all`
- everywhere else: `.all()` or `.filter(arguments)`

## Accessing the ***one***: `.attribute_name`
- when you have a single instance of the ***many*** `class`, using `.attribute_name` (whatever you named it) will give you a single instance of the ***one*** related `class` (not a query set or list)

# Determining The Type of Relationship
## Steps
- select the two models / entities that are being related, then ask the below questions to determine the relationship
  - ``` py
      class Widget(models.Model):
          description = models.CharField(max_length=60)


      class Item(models.Model):
          description = models.CharField(max_length=60)
    ```
1. Can ***one*** **widget** be related to ***many*** **items**?
    - if no: see the 'no' section below
    - if yes: the relationship is ***one*** **widget** related to ***many*** **items** (FK goes on the ***many***)
      - ***one*** `Widget` instance related to ***many*** `Item` instances, but a single `Item` instance cannot be related to ***many*** `Widget` instances
      - ``` py
          class Widget(models.Model):
              description = models.CharField(max_length=60)
              # some_widget.items.all() to access list of many related items

          class Item(models.Model):
              description = models.CharField(max_length=60)

              # some_item.widget to access the one related widget
              widget = models.ForeignKey(
                  'Widget', on_delete='CASCADE', related_name='items'
              )
        ```
2. Same question from the opposite direction: Can ***one*** **item** be related to ***many*** **widgets**?
    - if yes to **#1** and **#2**: the relationship needs to be updated to ***many*** to ***many***
      - ***one*** `Widget` instance can be related to ***many*** `Item` instances
      - ***one*** `Item` &nbsp; &nbsp; instance can be related to ***many*** `Widget` instances
        - notice both the `ManyToManyField` attribute name and `related_name` should be pluralized for ***many*** to ***many***
      - ``` py
          class Widget(models.Model):
              description = models.CharField(max_length=60)

              # hidden 'items' attribute is available via dot notation
              # some_widget.items.all() to get a LIST of all the related items


          class Item(models.Model):
              description = models.CharField(max_length=60)

              # ManyToManyField can be added to either model
              # some_item.widgets.all() to get a LIST of all the related widgets
              widgets = models.ManyToManyField(
                  'Widget', related_name='items'
              )
        ```
## Answering No to above questions:
- if no to **#1** and yes to **#2**, it is&nbsp; *one* **item** &nbsp;&nbsp; &nbsp; related to *many* **widgets**
    - this is a reversal of &nbsp; &nbsp; &nbsp; &nbsp; *one* **widget** &nbsp;related to *many* **items** code snippet above
    - ``` py
      class Widget(models.Model):
          description = models.CharField(max_length=60)

          # some_widget.item to access the one related item
          item = models.ForeignKey(
              'Item', on_delete='CASCADE', related_name='widgets'
          )


      class Item(models.Model):
          description = models.CharField(max_length=60)
          # hidden 'widgets' attribute is available via dot notation
          # some_item.widgets.all() to get a LIST of all the related widgets
      ```
- if no to all, ask:
    - can *one* **widget** be related to only *one* **item** and
    - can *one* **item**&nbsp; &nbsp; &nbsp;be related to only *one* **widget**?
    - if yes to both: [one to one relationship](https://docs.djangoproject.com/en/3.0/topics/db/examples/one_to_one/)