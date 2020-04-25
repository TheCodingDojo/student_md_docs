# Git Cheat Sheet

## Getting started

- Read [Git Handbook](https://guides.github.com/introduction/git-handbook/)
- Make your own cheat sheet of commonly used commands to reinforce learning
- **!!!IMPORTANT!!!** Replace `{{variable}}` with your own variable
- Remove the `{{}}` characters

## Resources

- [Getting Started About Version Control](https://git-scm.com/book/en/v2/Getting-Started-About-Version-Control)
- [GitHub](https://github.com/)
- [iteration Podcast](https://iteration.simplecast.com/episodes/s08e02-oYlx6rnY)
- [Learn git branching](https://learngitbranching.js.org/)
- [gitflow png](https://a5anka.github.io/images/gitflow_5_Vincent_Driessen.png)

## Common commands

- `git init`
- `git status`
- `git clone {{url}}`
- `git add {{files to add, or all using "."}}`
- `git commit -m "{{some message}}"`
- `git push`
- `git pull`
- `git checkout -b {{branch name}}`

---

## How to clone a project

- open a terminal window
- `cd` to where you want the new cloned folder to be created
- copy the url of the repo from GitHub via the **Clone or download** button
- `git clone {{url}}`
- `ls` or `dir` to view cloned project
- `cd {{newly created project folder name}}`
- open folder in editor of choice `code .` (if VSCode CLI installed in path)
- `ls -a` or `dir` to see hidden `.git` folder

---

## Create a github repository for your project

- there is a hidden `.git` folder that is inside of every folder that you have ran `.git init` from
  - there ise also a hidden `.git` folder inside of any repository that you cloned
- **your project folder must NOT be inside** of a folder that has already been initialized as a git repository

  - if it is, move your project folder to a different location

- **if you need to restart this process**, you must delete the hidden `.git` folder that is inside your project folder, look up how to see hidden folders on mac / windows. This `.git` folder is inside of every folder that you have ran `.git init` inside of

1. create a `.gitignore` file in your project folder if needed (you can google "name of stack `.gitignore`" for an example file)
2. open terminal to your project folder
3. `git init`
4. `git add .`
5. `git commit -m "first commit"`
6. [create a repo on github](https://github.com/new)
   - after repo is created github will provide some steps:
   1. paste the `git remote add` line to terminal
   2. paste the `git push` line to terminal
   3. refresh github and you should see your code on there
      - make sure none of the folders/files in the `.gitignore` were added, if they were, restart

---

## Branch Strategies / Collaboration

### Everything master branch - quick and easy

#### Tips

- everyone commits to master
- push and pull often
- to avoid merge conflicts do not edit the same file at the same time
- resolve merge conflicts in an editor or in github by selecting the changes you want to keep

#### General workflow for collaboration

- 1 person creates a new repository on github.com (add appropriate .gitignore if necessary)
- repo creator needs to 'Invite a collaborator' under Settings -> Manage access
- each collaborator clones the repo to their local machine `git clone {{url}}`

##### Repeat the steps below to push code to master

- create/edit files
- read the status of the vsc `git status`
- add all files to staging `git add .`
- `git status`
- save changes to the vcs `git commit -m '{{some message}}'
- push changes to repository `git push`
- `git status`

### Multi branch

#### General workflow

- update local master branch with `git pull`
- create a new branch from master `git checkout -b {{feature branch name}}`
- write some code
- `git status`
- add to staging `git add .`
- `git status`
- commit changes `git commit -m '{{some message}}'`
- push changes to remote repository `git push`

#### Multi Branch In Depth Steps

- create a new branch from master
- make changes
- push changes to repo
- make a pull request on github using the web interface
- add a reviewer
- reviewer should determine if changes are approved
- merge branch into master

---

## Updating your deployment

AWS deployment

- ssh into server
- cd into project folder
- `git status` to confirm in repo directory
- `git pull`
- resolve merge conflicts
- rebuild project (if necessary)
- restart services (nginx, gunicorn)
