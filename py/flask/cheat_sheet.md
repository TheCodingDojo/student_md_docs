# Flask cheat sheet for projects with `server` folder and `env` in project

## ***!!!Replace `{{your_project_name}}`  with your chosen project's name (remove the curly braces!!!)***

1. open terminal to where you want your project folder to be created
2. `mkdir {{your_project_name}}`
3. `cd {{your_project_name}}`
4. `mkdir server`
5. `cd server`
6. windows: `python -m venv env` mac: `python3 -m venv env`
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
    - `pip install Flask`
11. create the following folder structure in `server` folder
    - `templates`
      - `index.html`
    - `app.py`
12. `app.py`
    - ``` py
      from flask import Flask, render_template, redirect, request, session
      import os

      app = Flask(__name__)
      app.secret_key = os.urandom(16)


      @app.route('/')
      def home():
          return render_template("index.html")


      if __name__ == "__main__":
          app.run(debug=True)
        ```
13. Click debug icon in vscode side bar (bug icon Ctrl+shift+D)
    1. click gear icon
    2. select flask (if it doesn't show, might need to select python then flask will show)
    3. If prompted: press enter to confirm file name `app.py` or change the name if you used a different file name
    - `launch.json` will be created - ok to close it or delete it if need to re-do this step

# When reopening vscode
- vscode needs to be opened to the `server` folder so it detects the virtual environment
- if terminal doesn't show `(env)`: press **`+`** icon on terminal
- if `env` still has not activated, re-select the interpreter from the steps above

# Debugging Notes
## Starting server from `(env)` terminal: `python app.py` - when you don't need to pause on breakpoints
- stop debug mode if it is on (square stop button)
- this command will auto reload server on code changes which is useful for when you are making many changes

## To Debug with breakpoints (won't auto reload on code changes)
- Stop server `ctrl + c` Use play button in debug panel or press F5
  - add a breakpoint by clicking to the LEFT of the line number so that a red circle appears

## Source Control - Only when you need to add to github
- add the `env` folder to `.gitignore`
  - `pip freeze > requirements.txt` to create a file that lists installed packages (dependencies)
  - when repo is cloned / shared
    - create env
    - activate it
    - `pip install -r requirements.txt` to install everything required

# App Flow
1. request is made (url is visited)
2. server receives the request
3. `@app.route` urls are checked to see if the url matches any of these
4. when matching url is found, the function that is immediately below the `@app.route` is executed
    - any route parameters from the url will be passed as arguments to the function below it, this function must specify parameters of the same name as the url parameters if there are any
5. function renders an html document or redirects to another url

# `app.py` comments
- `os` is imported directly from python because it is available in python's standard library
- `Flask` is imported from `flask`, it does not come automatically available in python, so it is imported from the installed package
  - first letter capital is a naming convention for classes, suggesting that `Flask` is a class
  - `app = Flask(__name__)`: instantiating `Flask` sets up our server and returns us an object that comes with helpful built in functionality
  - `__name__`is a built-in variable which evaluates to the name of the current module. It can be used to detect if the file is being run directly or being imported
  - `app.secret_key = os.urandom(16)` is used for session, so secure info stored in session
- `@app.route('/')` is a route 'decorator'. This matches the localhost url with nothing after it
- `@app.route('/guest/<name>')` would match `http://localhost:5000/guest/some-text`
  - `<name>` is a route parameter, it works like a function parameter to store the value passed in at that position, so it would have the value `some-text` or whatever text is typed in there
  - the function below a route that has route parameters must have the same parameters with the same name, the parameter values are extracted out of the url and passed to the function below as argument(s)