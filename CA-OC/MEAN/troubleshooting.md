# Mac Installation
- use installer or
- [Mongo Docs For Mac Installation](https://docs.mongodb.com/manual/tutorial/install-mongodb-on-os-x/)

# Response returns HTML instead of data
- look for the `<app-root>` tag in the returned HTML, if it is there, that is the angular `index.html` file which is returned when no other routes in the back end are matched. Review `routes.js` compared with the URL that is being used in the request for errors

# `undefined` Component Prop
- it is being assigned `undefined`, likely from accessing a key that is not defined