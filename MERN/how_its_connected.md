# Express modularization
- **when a you `require` a file, it runs the code in the required file before the lines below are run**
- [Video walkthrough of below steps with breakpoints](https://youtu.be/0z1y5RpR7WQ)

## Starting point: `server.js`
- this is the file that is actually executed, it connects everything else, the lines are run top to bottom.
1. `require('express');` from `node_modules`
2. `require` mongoose configurations: `require('./config/mongoose.config');` 
    - this triggers the code in `mongoose.config` to be executed that configure and connect mongoose
3. create our `app` by calling the `express` function: `const app = express();`
4. `require` our app's routes: `require('./routes/modelName.routes')(app);`
    - immediately invoke the function that is exported from this `require` and pass it our app
      - **but, before this happens, the below steps happen**
5. `modelName.routes.js` runs `require('../controllers/modelName.controller')`
6. `modelName.controller.js` runs `require('../models/modelName.model')`
7. `modelName.model.js` runs `require('mongoose')` to get a reference to mongoose from `node_modules`
    - mongoose has already been connected and configured from step 2
    - `ModelNameSchema` is created and registered with mongoose
    - get a reference to the model from mongoose and export it: `module.exports = ModelName;`
8. `ModelName.controller.js` has now received the exported mongoose model from `modelName.model.js`
9. `ModelName.controller.js` now `exports` an object full of methods
10. `modelName.routes.js` has now received the exported object from `ModelName.controller.js`
    - methods from the exported object can now be referenced in `modelName.routes.js`
11. `modelName.routes.js` now `exports` a function
12. `server.js` now receives the exported function from `modelName.routes.js` and executes it immediately
13. Everything is now set up, time to `app.listen` for ***requests*** in order to ***respond*** to them.

# React