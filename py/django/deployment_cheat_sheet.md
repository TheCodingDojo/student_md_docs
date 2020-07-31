# Django Deployment Cheat Sheet

- create an AWS account then go to [AWS Management Console](https://us-west-1.console.aws.amazon.com/console/home?region=us-west-1)
- [AWS page for after you have an instance set up](https://us-west-1.console.aws.amazon.com/ec2/v2/home?region=us-west-1#Instances:sort=instanceId)
- [Deployment Vid from 05/2020](https://vimeo.com/421290939/4378c2279e)

---

## Git Repo steps

1. open VSCode to `{{your_project_name}}` folder
2. create a file named `.gitignore` at same level as `manage.py`

   - add this code to it

     - ```txt
       .vscode
       env/
       venv/
       __pycache__/
       .vscode/
       db.sqlite3
       ```

3. With your environment **activated** in VSCode terminal type : `pip freeze > requirements.txt`
4. `git init`
5. `git add .`
6. `git commit -m "first commit"`
7. [create a repo on github](https://github.com/new)
   - after repo is created github will provide some steps:
   1. paste the `git remote add` line to terminal
   2. paste the `git push` line to terminal
   3. refresh github and you should see your code on there
      - make sure none of the folders/files in the `.gitignore` were added, if they were restart
      - if you are remaking the github repo, you must delete the hidden `.git` folder in your project folder (google show hidden folders)

---

## [AWS](https://aws.amazon.com/console/) EC2 Virtual Machine setup (**_!!!!!!!REPLACE {{text}} WITH APPROPRIATE TEXT - DON'T KEEP CURLY BRACES!!!!!!!_**)

1. click Launch a virtual machine
   - With EC2
2. select Ubuntu Server 18.04 LTS (HVM)
   - free tier eligible
3. select free tier option
4. click Review and Launch
5. click Edit security groups
6. SSH Row: select My IP under Source
7. click Add Rule
   - Type: HTTP
   - Source: Anywhere
8. click Add Rule
   - Type: HTTPS
   - Source: Anywhere
9. click Review and Launch
10. click Launch
11. Select an existing key pair or create a new key pair
    - steps to create a new key pair if you don't have one
      1. select Create a new key pair
      2. Key pair name: django_pem
      3. click Download Key Pair
         - save it to a folder you will **NEVER** use as a github repo
      4. click Launch Instances
12. click View Instances (might load for a few minutes)
13. update Name column to: django
14. open terminal to where your downloaded pem file is located (**_windows users USE BASH instead of command prompt_**)
15. click connect at top of the AWS console
16. copy and paste the `chmod` line of code into your terminal that is opened to the location of your downloaded pem file
17. copy and paste the `ssh` line of code into your terminal
    - if connection time out error:
      1. description tab below click: Security groups launch-wizard-2
      2. Inbound tab
      3. click edit
      4. add SSH with source My IP (any time your ip address changes you need to do this, your ip address will be different from home vs at the dojo)
18. yes to continue if prompted
19. `sudo apt-get update`
20. `sudo apt-get install nginx`
    - y to continue if prompted
21. `git clone {{YOUR_REPO_URL}}` - click the Clone or download button on your repo to get the URL
22. `sudo apt-get install python3-venv`
    - y to continue if prompted
23. `cd {{GITHUB_REPO_NAME}}`
24. `python3 -m venv env`
    - new line will appear in terminal after it's finished
    - `ls` should now show a `venv` folder
25. `source venv/bin/activate` - should see `(venv)` now in terminal
26. `pip install -r requirements.txt`
    - some errors like 'Failed building wheel for autopep8' are ok
27. `pip install gunicorn`
28. [Get ready for vim - vim has no mercy](http://learn.codingdojo.com/m/119/6138/42637)
29. `cd {{YOUR_DJANGO_PROJECT_FOLDER_NAME}}` so that `ls` will show `settings.py`
30. `sudo vim settings.py`
31. press `i` to enter insert mode and use arrow keys / scroll to navigate to the correct place to type
    - update the following lines:
    1. `DEBUG = False`
    2. `ALLOWED_HOSTS = ['{{YOUR_IPv4_Public_IP_ADDRESS}}']`
       - this ip address is in description tab in AWS
       - don't delete the quotes
    3. `STATIC_ROOT = os.path.join(BASE_DIR, "static/")`
       - **paste this line at the bottom of file (right click, paste when in insert mode)**
    4. save and quit: press `esc`, type: `:wq`, press `enter`
32. `cd ..` so `ls` shows `manage.py`
33. `python manage.py collectstatic`
34. `python manage.py makemigrations`
35. `python manage.py migrate`
36. test gunicorn to see if it works: `gunicorn {{DJANGO_PROJECT_NAME}}.wsgi`
    - press `ctrl + c` to stop it
37. type `deactivate` to deactivate `venv`
38. `sudo vim /etc/systemd/system/gunicorn.service`

    1. copy below text into vscode and **_REPLACE ALL THE {{}} TEXT WITH RIGHT NAMES_** - remember you can use ctrl + D to select each occurrence

       - ```txt
         [Unit]
         Description=gunicorn daemon
         After=network.target
         [Service]
         User=ubuntu
         Group=www-data
         WorkingDirectory=/home/ubuntu/{{GITHUB_REPO_NAME}}
         ExecStart=/home/ubuntu/{{GITHUB_REPO_NAME}}/venv/bin/gunicorn --workers 3 --bind unix:/home/ubuntu/{{GITHUB_REPO_NAME}}/{{DJANGO_PROJ_NAME}}.sock {{DJANGO_PROJ_NAME}}.wsgi:application
         [Install]
         WantedBy=multi-user.target
         ```

    2. enter insert mode by pressing `i`
    3. right click and paste the updated text
    4. `esc` `:wq` `enter`

39. `cd ..` to get out of repo folder
40. `sudo systemctl daemon-reload`
41. `sudo systemctl restart gunicorn`
42. `sudo systemctl status gunicorn`
    - should see a green dot and _'active (running)'_ if it worked
    - if you see failed or `Tasks: 1`, you will likely have to terminate instance and start over
    - if you see any `{{}}` with an error, open the file in vim again and replace the `{{}}`
    - **if you edit the `gunicorn.service` file after this point, you must run the above 3 commands again**
43. press `ctrl + c`
44. open this text in vscode:

    - ```txt
      server {
        listen 80;
        server_name {{YOUR_EC2_IPv4_Public_IP_ADDRESS}};
        location = /favicon.ico { access_log off; log_not_found off; }
        location /static/ {
            root /home/ubuntu/{{GITHUB_REPO_NAME}};
        }
        location / {
            include proxy_params;
            proxy_pass http://unix:/home/ubuntu/{{GITHUB_REPO_NAME}}/{{DJANGO_PROJ_NAME}}.sock;
        }
      }
      ```

    1. **_REPLACE THE {{}}_** with appropriate names
    2. `sudo vim /etc/nginx/sites-available/{{DJANGO_PROJ_NAME}}`
    3. `i` to enter insert mode then
    4. copy the edited text from VSCode
    5. right click vim to paste
    6. `esc` `:wq` `enter`

45. `sudo ln -s /etc/nginx/sites-available/{{DJANGO_PROJ_NAME}} /etc/nginx/sites-enabled`
    - **don't delete the space**
46. `sudo nginx -t` to check if successful, if not, double check the vim file that was just created
47. `sudo rm /etc/nginx/sites-enabled/default`
48. `sudo service nginx restart`
49. paste public ip address from AWS under description tab into browser

- when you want to delete this AWS instance, right click it -> instance state -> terminate

---

## Updating deployed project with new code

1. push changes to github repo
2. `cd` to repo folder on the AWS server
3. `git pull`
4. restart gunicorn & nginx
