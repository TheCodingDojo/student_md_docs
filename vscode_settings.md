# Useful Generic Extensions
- CSS Formatter
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

# Recommended Settings
- ctrl + shift + p then type Open Settings (JSON)
- add these settings on ***TOP of file, inside curly brace***
- ``` json
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

# Misc
- [font with ligatures](https://dev.to/expertsinside/cascadia-code-a-new-font-for-visual-studio-code-and-terminal-47oc)
- [integrated cmder](https://winsmarts.com/using-cmder-as-integrated-shell-in-vscode-c3340714fe3c)