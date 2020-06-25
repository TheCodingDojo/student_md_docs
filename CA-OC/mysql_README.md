# MySQL Info

- [Download Link](https://dev.mysql.com/downloads/mysql/)

## If you are having problems

1. follow uninstall steps below
2. follow install steps below
3. follow testing steps below

### Reasons to Reinstall

- Authentication method 'caching_sha2_password' failed
  - forgot to click **RADIO BUTTON:** "Use Legacy Authentication Method" when installing
- Forgot password or password not working

---

## [Windows Installation Video](https://www.youtube.com/watch?v=u96rVINbAUI)

- **RADIO BUTTON:** "Use Legacy Authentication Method" when installing
- **CHECK BOX:** "Configure MySQL Server as a Windows Service
- **CHECK BOX:** "Start the MySQL Server at System Startup

---

## Windows Uninstall

- press windows key -> type "add or remove programs"
- remove MySQL Workbench
- restart computer
- use above download link and follow the Windows Installation Video above

---

## Mac Installation Instructions

- Use Download Link above
- Select Mac
- Download DMG Archive option from the
- **RADIO BUTTON:** "Use Legacy Authentication Method" when installing
- **CHECK BOX:** "Start the MySQL Server at System Startup
- If mysql isn't recognized in termainl after installing
  - paste this in terminal: `alias mysql=/usr/local/mysql/bin/mysql`
- if you can't figure out how to open MySql Workbench, you may need to install it separately [Download Workbench](https://dev.mysql.com/downloads/workbench/)

---

## Mac Uninstall Instructions [destroy-mysql](https://github.com/neilm813/destroy-mysql)

- If your installing doesn't work, uninstall it

1. download the `.sh` file using clone or download button
2. in terminal: type `sh` (add a space after `sh`) then drag and drop file to auto to the terminal to auto fill the path to the file, then press enter to run
3. when prompted to search your computer, press `enter` / `return` key
4. some lines will be printed to the terminal, once done, exit terminal
5. restart computer
6. follow the Mac Installation Instructions in this file

---

## Cautionary Tale

- "Changed mac account to be admin and after restart lost ALL files associated with that account and it started the Mac as though the account had been created for the first time.
  So she lost all of her classwork."

---

## Test if it works

1. open MySQL Workbench
2. click Local instance MySQL in the middle left of home tab
3. click the +SQL button in the top left below the File menu
4. in the newly opened tab, type `SHOW DATABASES`
5. click the lightning bolt icon on the SQL tab to execute this query

- If you see rows listed in the below result grid, everything is working fine
