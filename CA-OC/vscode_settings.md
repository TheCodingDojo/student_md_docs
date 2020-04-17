# Useful Generic Extensions

- click the square blocks on the side panel to go to the extension marketplace and then search for and install the below listed extensions
- Prettier - Code formatter
- Bracket Pair Colorizer
  - closing & opening brackets color cordinated
- indent-rainbow
  - colorful indentation
- Path Intellisense
  - auto complete directory paths that are typed as strings
- material icon theme
  - clearer looking folder & file icons
- Live Server
  - runs `.html` file as a live server that auto refreshes page when changes are made
- open in browser
  - right click `.html` file tab to open in browser
- Live Share
  - the one by Microsoft
- SQLite
  - to view SQLite tables (useful in Python Stack during Django)

## Recommended Settings

- ctrl or cmd + shift + p then type: Open Settings (JSON) -> press enter
- add these settings on **_TOP of file, inside curly brace_**

- ```json
  "files.autoSave": "onFocusChange",
  "editor.formatOnSave": true,
  "editor.snippetSuggestions": "top",
  "editor.wordWrap": "on",
  "editor.detectIndentation": true,
  "editor.renderWhitespace": "selection",
  "emmet.includeLanguages": {
      "razor": "html",
      "aspnetcorerazor": "html",
      "javascript": "javascriptreact",
  },
  ```

## Python

- linter: pycodestyle
- formatter: autopep8

## Misc

- [font with ligatures](https://dev.to/expertsinside/cascadia-code-a-new-font-for-visual-studio-code-and-terminal-47oc)
- [integrated cmder](https://winsmarts.com/using-cmder-as-integrated-shell-in-vscode-c3340714fe3c)
