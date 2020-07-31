# Troubleshooting

## MultiValueDictKeyError
- the key doesn't exist in the dictionary
  - check the spelling
  - verify you are using the right key from the `<form>` that is being submitted, the key should relate to the `name` attribute on the `<input>` tags
  - verify the `<form>` has a `method="POST"`
    - if this is missing the request was sent as a GET request, which means `request.POST` is empty so the key's that correspond to the `<form>` `<input>` `name` attributes are missing

## Template not found
- is `templates` folder inside the app folder?
- no leading slash
- check spelling of `html` file compared to `return render` line
- check the folder structure, is the template inside another folder?
- `return render(request, 'shirts/new.html')`
  - this example the html file is inside a sub folder called `shirts`

## `pip` not recognized (windows)
- add it to path
- use current python path to see where python is installed
- pip is located in same directory with `\Scripts\` appended

## segmentation failure
- don't use bash

## Invalid Salt
- add `decode` to end `hashed_pw = bcrypt.hashpw('test'.encode(), bcrypt.gensalt()).decode()`
- is pw in db plaintext?

## Migration Issues
### Clear All DB Data
- doesn't delete migrations, so if there is an error in your migration files this won't fix it, see other options if this doesn't work
1. `pip install django-extensions`
2. add `django_extensions` to `INSTALLED_APPS`
3. `python manage.py reset_db`
4. `python manage.py makemigrations`
5. `python manage.py migrate`
6. comment out `django_extensions` in `INSTALLED_APPS` to avoid 'module not found error' when debug mode

### New Column Issue / Default Value
- can add a bogus default value just to get passed the error, then delete the existing rows from that table to start fresh, or the below
1. delete new field from model
2. `python manage.py makemigrations`
3. `python manage.py migrate`
4. if error
  - `python manage.py migrate --fake`
5. add field back
6. makemigrations & migrate

### Full destroy and restart db
- delete everythign in `migrations` folder ***EXCEPT*** `__init__.py`
- delete `db.sqlite3` file
- empty trashcan
- `python manage.py makemigrations`
- `python manage.py migrate`

## `RuntimeError: __class__ not set defining 'AbstractBaseUser' django`
- downgrade python to 3.7.x (to be compatible with django 1.10) or upgrade django

## Terminal
### Powershell
- [Running Py With Powershell](https://www.windowscentral.com/how-create-and-run-your-first-powershell-script-file-windows-10#run_powershell_script_windows10)

## Misc
### Erroneous Unresolved Import
- `ctrl + shift + p`
  - type `Python: Select Linter`
  - select 
- ctrl + shift + p > Open Settings (JSON)
- comment out `{"python.jediEnabled": false}` in `settings.json`