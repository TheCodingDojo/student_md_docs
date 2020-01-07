# Django 2.2 Cheat Sheet (`env` in project structure)

# ***!!!Replace `{{your_project_name}}` and `{{app_name}}` with your chosen project & app names, removing curly braces!!!***

1. open terminal to where you want your project folder to be created
2. `mkdir {{your_project_name}}`
3. `cd {{your_project_name}}`
4. `mkdir server`
5. `cd server`
6. **windows**: `python -m venv env` **mac**: `python3 -m venv env`
    - new line in terminal will appear after finished
7. open vscode to `server` folder. From terminal, you can type: `code .`
    - mac - if `code .` doesn't work, open vscode:
      1. cmd + shift + p
      2. type: shell command: install 'code' command in PATH
      3. restart terminal
      4. open terminal to `server` folder then type `code .` again
8. `Ctrl+shift+P` -> 'select interpreter' -> choose the one from the env
    - if it doesn't show up, your env is still being created, wait then select interpreter again
9. Open new integrated terminal, should show `(env)` in the terminal
    - if integrated terminal doesn't show `(env)`, press the **`+`** button to open new integrated terminal
10. Install dependencies from your integrated terminal that shows `(env)` so these will be installed only for this project
    - `pip install Django==VERSION_NUMBER`
    - [Check Ver. Num On Learn Platform](http://learn.codingdojo.com/m/119/6152/42896)
    - `pip install pylint-django`
11. From `server` folder `django-admin startproject your_proj_name .`
    - ` .` will make it so there's only one folder with the your_proj_name instead of also having an inner folder with the same name
12. Click debug icon in vscode side bar (bug icon Ctrl+shift+D)
    1. click gear icon
    2. select python
    3. select django
    - `launch.json` will be created - ok to close it. Can delete if you need to re-do this step.
13. `python manage.py startapp {{app_name}}` to make a new app with it's own folder
14. Add app in `settings.py` which is in `your_proj_name` folder
    - add *`'{{app_name}}',`* to 0 idx (top) of `INSTALLED_APPS` list (don't forget the comma)
15. `urls.py` inside `your_proj_name` folder
    - ``` py
      # from django.contrib import admin
      from django.urls import path, include

      urlpatterns = [
          # path('admin/', admin.site.urls),
          path('', include('{{app_name}}.urls')),
      ]
        ```
16. create `urls.py` in `{{app_name}}` folder
    - ``` py
      from django.urls import path
      from . import views

      # NO LEADING SLASHES
      urlpatterns = [
          path('', views.index, name='index'),
      ]
        ```
17. create following folder structure in `{{app_name}}` folder
    - `templates`
      - `index.html`
18. `views.py`
    - ``` py
      from django.shortcuts import render, redirect


      def index(request):
          return render(request, 'index.html')
        ```
19. `python manage.py runserver` - see Debugging Notes below

# When reopening vscode
- vscode needs to be opened to the `server` folder so it detects the virtual environment
- if terminal doesn't show `(env)`: press **`+`** icon on terminal
- if `env` still has not activated, re-select the interpreter from the steps above

# Debugging Notes
## To Debug with breakpoints (won't auto reload on code changes)
- **Stop server** `ctrl + c` then press play button in debug panel or press F5
  - add a breakpoint by clicking to the LEFT of the line number so that a red circle appears

# Route Parameters / URL clarifications
## `urls.py` - NO LEADING SLASHES
- `path('users/<int:user_id>', views.user_profile, name="users_profile"),`
- this is to MATCH a *requested* URL in order for django to know which view function to route to when a URL is requested so that the proper *response* can be given to the client
- `<int:id>` is a PLACEHOLDER for whatever integer will be located at that section of the URL
  - it is a route parameter, just like a function parameter, it will store the value that is passed in when the url is visited just like a function parameter will store the value that is passed in when the function is executed
  - e.g., `http://localhost:8000/users/15` - `15` is the value of route parameter `user_id`
- when this url is visited, the `user_profile` function in `views.py` will be executed and it MUST have a corresponding parameter with the same name as the route parameter: `def user_profile(request, user_id)`

## When are values inserted into urls?
- when a client types in a url

### HTML files
- in `html` files you generally have **leading slashes on your urls**
- in `<a>` tags
- in `action` attribute of a `<form>` tag
- the above are all places where you will use jinja to insert the actual value that you want `user_id` to have
- `<a href="/users/{{ user.id }}">`
- `<form action="/users/{{ user.id }}/update" method="POST">`

### `views.py`
- you generally have **leading slashes on your urls** here
- when you `return redirect(f'/users/{some_id}')`

# Terminal Commands
## `python manage.py runserver`
- stop debug mode if it is on
- this command will auto reloading server on code changes which is useful for when you are making many changes

## Migrating
1. `python manage.py makemigrations`
2. `python manage.py migrate`

## Shell
1. `python manage.py shell`
2. `from {{app_name}}.models import *`

## Source Control - Only when you need to add to github
- create a `.gitignore` file with the below code so certain files/folders are not added to github:
  - ``` txt
      .vscode
      env/
      venv/
      __pycache__/
      .vscode/
      db.sqlite3
    ```
- `pip freeze > requirements.txt` to create a file that lists installed packages (dependencies)
- when repo is cloned / shared
  - create env
  - activate it
  - `pip install -r requirements.txt` to install everything required

# Django MTV (Model Template View)
- the view retrieves data from the database via the model, formats it, bundles it up in an HTTP response object and sends it to the client (browser).
- In other words, the view presents the model to the client as an HTTP response.

# App flow walkthrough
1. *Request* is made from a URL being visited via: 
    - typed into address bar
    - anchor tag
    - `<form>` submitted triggering `POST` *request* to URL in `action` attribute
    - `return redirect` from `views.py`
2. URL is compared to the `urls.py` file to see if it matches any of the urls in the list of urls
3. When URL is matched, it runs the specified view function, passing any URL parameters to the view function. The view function needs a parameter for each of the URL parameters using the same parameter names.
4. view function gets data from the database if needed and sends that data to the right template (HTML) to display the data, ***OR*** the view function `return redirect` to another URL
5. Whatever the view function returns is the *response* which finishes the *request* *response* cycle.
- the *request* and *response* can be seen in the network tab of chrome dev tools

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

# Prefill date from db into input box
- ``` py
  def edit_show(request, show_id):
      selected_show = Show.objects.get(id=show_id)
      context = {
          'selected_show': selected_show,
          'formatted_release_date': selected_show.release_date.strftime("%Y-%m-%d")
      }
  ```
- `<input value="{{ formatted_release_date }}" type="date" name="release_date">`
- chrome console gives an invalid format warning when trying to insert a value that is not formatted in this way


# [Advanced Topics](https://github.com/TheCodingDojo/student_md_docs/blob/master/py/django/advanced.md)