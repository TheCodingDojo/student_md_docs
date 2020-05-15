# MERN Troubleshooting

## Webpack

### Installed globally

- I was able to fix the student issue by deleting the webpack folders inside of C:\users\username\node_modules

## Windows

### Space in user name

- configure `npm` to use Windows Short Names
- alternatively rename their username

## Extra Renders

- `<React.StrictMode>` in `index.js`
  - causes extra renders only in development when using hooks
  - intentional behavior to help catch unintended side effects, can be removed to avoid extra re-renders

## `Can’t perform a React state update on an unmounted component`

- the component being updated is no longer "mounted", no longer displayed
- usually happens if you go to a different page while an HTTP request (like an API request) was still pending for the previous page and then it finishes but that page is no longer active so the component cannot be updated
