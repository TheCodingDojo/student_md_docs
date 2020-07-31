# Relationship Examples
- user can have many tasks, but a task can be added by only 1 user
- many to many between user and tasks for liking: user can like many tasks, task can be liked by many users
- the value of `related_name` will become a key/prop by that name on the related model that can be accessed via dot notation
- ``` py
  class User(models.Model):
      first_name = models.CharField(max_length=60)
      last_name = models.CharField(max_length=60)
      email = models.CharField(max_length=60)
      password = models.CharField(max_length=60)
      created_at = models.DateTimeField(auto_now_add=True)
      updated_at = models.DateTimeField(auto_now=True)


  class Task(models.Model):
      title = models.CharField(max_length=60)
      description = models.TextField()
      created_at = models.DateTimeField(auto_now_add=True)
      updated_at = models.DateTimeField(auto_now=True)
      # When a User is deleted
      # the delete will 'cascade' to delete all the user's assigned_tasks as well
      assigned_to = models.ForeignKey(
          "User", related_name="assigned_tasks", on_delete=models.CASCADE)
      liked_by = models.ManyToManyField("User", related_name="liked_tasks")
  ```

# Post which has comments where comments can have comments
- ``` py
    class Post(models.Model):
        subject = models.CharField(max_length=255, default=None, blank=True, null=True)
        name = models.CharField(max_length=255)
        email = models.CharField(max_length=255)
        comment = models.TextField(max_length=1000)
        file_name = models.CharField(max_length=255, default=None, blank=True, null=True)
        image = models.ImageField(upload_to="forums", default=None, blank=True, null=True)
        thumbnail = models.ImageField(upload_to="forums", default=None, blank=True, null=True)
        is_thread = models.BooleanField()
        created_at = models.DateTimeField(auto_now_add=True)
        updated_at = models.DateTimeField(auto_now=True)
        replies = models.ManyToManyField("self", blank=True, related_name="thread")
    ```
- Many to many field will act as a list of comments that you can access from any given comment