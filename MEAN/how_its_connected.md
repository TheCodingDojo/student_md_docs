# Modularization Walkthrough (backend)
## Starting from the top of `server.js`
1. express is required
2. we use express to create our app
3. add the necessary `app.set` and `app.use` like usual
4. `mongoose.js` is required, triggering `mongoose.js` to be executed
    1. `mongoose` is required
    2. `mongoose` connects to our db
    3. models are required in `mongoose.js` triggering the execution of each model file that is required
        1. when a model file is executed, the model and it's schema is registered to mongoose, allowing us to use `mongoose.model('ModelName')` elsewhere to reference the model
5. routes are required, triggering the `module.exports` in `routes.js` to return it's function
    1. the returned function is immediately executed and our app is sent to the function as an argument because `routes.js` needs access to our app instance
    2. `routes.js` requires our controller triggering the controllers `module.exports` which returns us an object containing methods
    3. `routes.js` attaches each route to our app and maps each route to a method in our controller, the method is only executed when the route url is visited
6. the `app.listen` is finally executed, our app is now ready 'respond' to user's 'requests' (visiting a url / making an api call)

# Angular & Routing
1. URL is visited
2. Angular checks if it matches any url/route/`path` in `app-routing.module.ts`
    - if it matches it renders the specified `component` without making a network request to the server
3. No angular route matched, network request goes to server
4. `routes.js` are checked for a matching route
    - if route matches, the specified controller method is executed and data or errors are returned
5. no route matched in `routes.js`, catch all route will be matched and return angular's `index.html` to avoid an error from the resource not being found