# ***!!!Replace `{{your_project_name}}` and `{{app_name}}` with your chosen project & app names, removing curly braces!!!***

# Optional Design Patterns
- only try these if you are not struggling

## multiple views & template sub folders - better organization
- You can do everything in 1 `views.py` file and all `.html` files in `templates` folder if it's easier
- Splitting views is useful when you have more than one model, e.g., `User` and `Task` and you want to have a route for all users and a route for all tasks, you can't have the two view functions with the name 'all' and two html files named 'all' unless they are split into separate view files and separate template sub-folders
- **create the following structure replacing `users` and `tasks` with what is relevant to your project (you may only need 1 view file and 1 `templates` sub folder to start, but this will make it easier to add more when needed)**
- delete `views.py` and create the following dir structure in `{{app_name}}` folder
  - `views`
    - `users.py`
    - `tasks.py`
    - **`__init__.py`**
  - `templates`
    - `{{app_name}}`
      - `users`
        - `all.html`
      - `tasks`
        - `all.html`
      - `shared`
  - `static`
    - `{{app_name}}`
      - `css`
- `shared` is for `.html` files that are used by multiple different views files
- `{{app_name}}` folder prevents the following problem: django will merge each app's `templates` folder into a single `templates` folder, which may cause folder or file name conflicts if different apps use the same folder or file names

## `__init__.py` in `views` folder
- ``` py
  # import all functions from all view files
  from .users import *
  from .tasks import *
    ```

## `users.py`
- ``` py
  from django.shortcuts import render


  def login(request):
      return render(request, '{{app_name}}/users/login.html')


  def all(request):
      return render(request, '{{app_name}}/users/all.html')

    ```

## `tasks.py`
- ``` py
  from django.shortcuts import render


  def all(request):
      return render(request, '{{app_name}}/tasks/all.html')

    ```

## `{{app_name}}/urls.py`
- ``` py
  from django.urls import path
  from . import views

  urlpatterns = [
      path('', views.users.login, name='login'),
      path('users/all', views.users.all, name='all_users'),
      path('tasks/all', views.tasks.all, name='all_tasks'),
  ]
  
    ```

## `base.html` pattern
- [Django Girls base.html tutorial](https://tutorial.djangogirls.org/en/template_extending/)
- create a block in the head of the `base.html` that you can use to inject stylesheet `<link>` tags into from other html files
  - e.g., your extension html file has it's own personal stylesheet that you need the `base.html` to load
- create a block in between the `<title>` if you want each page to be able to set the `<title>` of the html page

## Fat models, skinny views
- move all the logic that relates to the model onto the model itself to keep that separate from the views (separation of concerns)
- ``` py
  import re # regex

  EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$')

  class UserManager(models.Manager):

    def create(self, request):
        user = None

        if self.is_reg_valid(request):
            user = User(
                first_name=request.POST['first_name'],
                last_name=request.POST['last_name'],
                email=request.POST['email'],
                password=bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt()).decode()
            )
            user.save()
        return user


    def is_reg_valid(self, request):

        if not EMAIL_REGEX.match(request.POST['email']):
            messages.error(request, "invalid email address.")
      
        if len(request.POST['first_name']) < 3:
            messages.error(request,
                           "First Name must be more than 2 characters.")

        if len(request.POST['first_name']) < 3:
            messages.error(request,
                           "Last Name must be more than 2 characters.")

        if len(request.POST['password']) < 8:
            messages.error(request,
                           "Password must be more than 8 characters.")

        if request.POST["password"] != request.POST["password_confirm"]:
            messages.error(request, "Passwords must match.")

        storage = messages.get_messages(request)
        storage.used = False  # don't clear messages
        return len(storage) == 0
    ```
- in `User` class
  - ``` py
      # give User.objects access to the methods on UserManager
      objects = UserManager()
      ```
- in views
  - ``` py
      new_user = User.objects.create(request)

      if new_user:
        pass # success - add to session
      else:
        pass # fail - redirect
      ```

## [Split models into multiple files](https://chrisbartos.com/articles/how-to-organize-your-models/)
- implemented in same way as multiple views