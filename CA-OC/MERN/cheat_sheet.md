# MERN Basic Project Creation Cheat Sheet

## REMOVE THE `{{TEXT}}` and replace the text with your own

1. open terminal to where you want your project to be created
2. `mkdir {{PROJECT_NAME}}`
3. `cd {{PROJECT_NAME}}`
4. `code .` to open VSCode to `{{PROJECT_NAME}}` folder
5. in VSCode terminal: `npm init -y` to initialize a new back-end node project (your server) with a `package.json`
6. install back-end dependencies, usually `npm i express mongoose cors`
   - your back-end `package.json` should now show have these dependencies listed
7. create `server` folder
8. in VSCode terminal: `npx create-react-app client` to create a `client` folder for your front-end react app
9. open a 2nd VSCode terminal (split terminal icon or plus icon) and `cd client` when it's done being created
10. install front-end dependencies, usually `npm i axios @reach/router`
    - your front-end `package.json` (inside `client` folder) should now have these dependencies listed
11. create the modularized back-end folder structure and files in the `server` folder
    - `cd` to `server` folder in other VSCode terminal and run server with `nodemon server.js`
      - one VSCode terminal should be open to `client` folder and one should be open to `server` folder
12. Test all back-end CRUD functionality using postman
    - including sending in invalid lengths or missing keys that are required
13. from `client` folder run react app with `npm start`
    - you should have two VSCode terminals open, one open to `client` folder running the react app and one open to `server` folder running your `server.js`
