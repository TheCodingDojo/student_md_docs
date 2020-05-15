# MERN Troubleshooting

## Extra Renders

- `<React.StrictMode>` in `index.js`
  - causes extra renders only in development when using hooks
  - intentional behavior to help catch unintended side effects, can be removed to avoid extra re-renders

## Webpack

### Installed globally

- I was able to fix the student issue by deleting the webpack folders inside of C:\users\username\node_modules

## Windows

### Space in user name

- configure `npm` to use Windows Short Names
- alternatively rename their username
