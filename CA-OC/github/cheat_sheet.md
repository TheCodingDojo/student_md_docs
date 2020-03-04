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
