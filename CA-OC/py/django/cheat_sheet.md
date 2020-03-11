# Django 2.2 Cheat Sheet (`env` in project structure)

---

## Follow EVERY step carefully!\*

---

## **_!!!Copy & Paste commands - REPLACE `{{your_project_name}}` and `{{app_name}}` with your chosen project & app names, REMOVING curly braces!!!_**

1. open terminal to where you want your project folder to be created
2. `mkdir {{your_project_name}}`
3. `cd {{your_project_name}}`
4. `mkdir server`
5. `cd server`
6. **windows**: `python -m venv env` **mac**: `python3 -m venv env`
   - new line in terminal will appear after finished
7. **open vscode to `server` folder**. From terminal, you can type: `code .`
   - mac - if `code .` doesn't work, open vscode:
     1. cmd + shift + p
     2. type: shell command: install 'code' command in PATH
     3. restart terminal
     4. open terminal to `server` folder then type `code .` again
8. Select python interpreter
   1. Windows: `Ctrl+shift+P` Mac: `Cmd+shift+P`
   2. Type: Python: Select Interpreter
   3. Choose from dropdown the one with `env`
   - if it doesn't show up, your env might still be processing or you named it differently or the env was created in the wrong place
9. Open new integrated terminal, **it should show `(env)` in the terminal**
   - if integrated terminal doesn't show `(env)`, press the **`+`** button to open new integrated terminal
10. Install dependencies from your integrated terminal that shows `(env)` so these will be installed **_only_** for this project
    - **windows**: `pip install Django==VERSION_NUMBER`
    - **mac**: `pip3 install Django==VERSION_NUMBER`
    - [Check Ver. Num On Learn Platform](http://learn.codingdojo.com/m/119/6152/42896)
11. From `server` folder in integrated terminal: `django-admin startproject your_proj_name .` <- don't forget the period
    - `.` will make it so there's only one folder with the your_proj_name instead of also having an inner folder with the same name
12. Click debug icon in vscode side bar (bug icon Ctrl+shift+D)
    1. click gear icon or "create a launch.json file" link
    2. select python
    3. select django
    - `launch.json` will be created - ok to close it. Can delete if you need to re-do this step.
13. `python manage.py startapp {{app_name}}` to make a new app with it's own folder (adding `_app` as a suffix to the name can help make the folder structure clearer)
14. Add your app in `settings.py` which is in `your_proj_name` folder
    - add _`'{{app_name}}',`_ to the 0 idx (top) of `INSTALLED_APPS` **list** (don't forget the comma)
15. `urls.py` inside `your_proj_name` folder

    - ```py
      # from django.contrib import admin
      from django.urls import path, include

      urlpatterns = [
          # path('admin/', admin.site.urls),
          path('', include('{{app_name}}.urls')),
      ]
      ```

16. create `urls.py` in `{{app_name}}` folder

    - ```py
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

    - ```py
      from django.shortcuts import render, redirect
      ```


      def index(request):
          return render(request, 'index.html')
        ```

19. `python manage.py runserver` - see Debugging Notes below

---

## When reopening vscode

- vscode needs to be opened to the `server` folder so it detects the virtual environment
- **if terminal doesn't show `(env)`:** press **`+`** icon on terminal
  - if `env` still has not activated, re-select the python interpreter and then press **`+`** icon on terminal again

---

## Debugging Notes

---

### To Debug with breakpoints (won't auto reload on code changes)

- **Stop server** `ctrl + c` then press play button in debug panel or press F5
  - add a breakpoint by clicking to the LEFT of the line number so that a red circle appears

---

## App flow walkthrough

1. _Request_ is made from a URL being visited via:
   - typed into address bar
   - anchor tag
   - `<form>` submitted triggering `POST` _request_ to URL in `action` attribute
   - `return redirect` from `views.py`
2. URL is compared to the `urls.py` file to see if it matches any of the urls in the list of urls
3. When URL is matched, it runs the specified view function, passing any URL parameters to the view function. The view function needs a parameter for each of the URL parameters using the same parameter names.
4. view function gets data from the database if needed and sends that data to the right template (HTML) to display the data, **_OR_** the view function `return redirect` to another URL
5. Whatever the view function returns is the _response_ which finishes the _request_ _response_ cycle.

- the _request_ and _response_ can be seen in the network tab of chrome dev tools

---

## Route Parameters / URL clarifications

---

### `urls.py` - NO LEADING SLASHES

- `path('users/<int:user_id>', views.user_profile, name="users_profile"),`
- this is to MATCH a _requested_ URL in order for django to know which view function to route to when a URL is requested so that the proper _response_ can be given to the client
- `<int:id>` is a PLACEHOLDER for whatever integer will be located at that section of the URL
  - it is a route parameter, just like a function parameter, it will store the value that is passed in when the url is visited just like a function parameter will store the value that is passed in when the function is executed
  - e.g., `http://localhost:8000/users/15` - `15` is the value of route parameter `user_id`
- when this url is visited, the `user_profile` function in `views.py` will be executed and it MUST have a corresponding parameter with the same name as the route parameter: `def user_profile(request, user_id)`

---

### When are values inserted into urls?

- when a client types in a url

---

#### HTML files

- in `html` files you generally have **leading slashes on your urls**
- in `<a>` tags
- in `action` attribute of a `<form>` tag
- the above are all places where you will use jinja to insert the actual value that you want `user_id` to have
- `<a href="/users/{{ user.id }}">`
- `<form action="/users/{{ user.id }}/update" method="POST">`

---

#### `views.py`

- you generally have **leading slashes on your urls** here
- when you `return redirect(f'/users/{some_id}')`

---

## Terminal Commands

---

### `python manage.py runserver`

- stop debug mode if it is on
- this command will auto reloading server on code changes which is useful for when you are making many changes

---

### Migrating

1. `python manage.py makemigrations`
2. `python manage.py migrate`

---

### Shell

1. `python manage.py shell`
2. `from {{app_name}}.models import *`

---

### Source Control - Only when you need to add to github

- create a `.gitignore` file with the below code so certain files/folders are not added to github:
  - ```txt
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

---

## Django MTV (Model Template View)

- the view retrieves data from the database via the model, formats it, bundles it up in an HTTP response object and sends it to the client (browser).
- In other words, the view presents the model to the client as an HTTP response.

---

## [Troubleshooting](https://github.com/TheCodingDojo/student_md_docs/blob/master/py/django/troubleshooting.md)

---

## [Determing the type of relationship](https://github.com/TheCodingDojo/student_md_docs/blob/master/py/django/relationship_planning.md)

---

## [Advanced Topics](https://github.com/TheCodingDojo/student_md_docs/blob/master/py/django/advanced.md)

---

## Prefill date from db into input box

- ```py
  def edit_show(request, show_id):
      selected_show = Show.objects.get(id=show_id)
      context = {
          'selected_show': selected_show,
          'formatted_release_date': selected_show.release_date.strftime("%Y-%m-%d")
      }
  ```
- `<input value="{{ formatted_release_date }}" type="date" name="release_date">`
- chrome console gives an invalid format warning when trying to insert a value that is not formatted in this way
