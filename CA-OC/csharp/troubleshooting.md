# Csharp troubleshooting

## Omnisharp / 'image not found' error / go to definition broken

- Go to extensions in vscode -> click settings wheel for C# -> install another version -> go back 1 version

---

## Installation

- `dotnet` not recognized after installing? Restart terminal and type `dotnet` again.

---

## Configure which dotnet version to use

1. `dotnet --version` (if it already shows 2.2.x, do not continue)
2. `dotnet --list-sdks`
   - version 2.2.x not listed? Go back to installation instructions and install it
3. `dotnet new globaljson --sdk-version {{VERSION_NUMBER}}`
   - replace `{{VERSION_NUMBER}}` with the full 2.2 version number that was listed from in terminal
4. `dotnet --version` should now show the new version number

---

## Mac

- 'image not found' terminal error
  - `brew install mono` should fix without requiring extension downgrade

---

### open ssl already installed

- no problem, skip the ssl steps

---

## Session not persisting w/ MVC template

- [Remove Cookie Consent from Startup.cs](http://learn.codingdojo.com/m/25/5671/39759)

---

## Custom Error Attributes

---

### `[FutureDate]` example

- if used with `[Required]`
  - need to add an if null check in future date code and return success to allow `[Required]` to handle the null

### if breakpoint in `[FutureDate]` won't trigger, in controller:

- ```csharp
    if (newChef.DateOfBirth.Year == 1)
    {
        if (ModelState.ContainsKey("DateOfBirth") == true)
        {
            ModelState["DateOfBirth"].Errors.Clear();
        }
        ModelState.AddModelError("DateOfBirth", "Invalid Date");
    }
  ```

---

## Non-invocable method error on methods that are invocable

- re-build

---

## Import Error on Run

- remove special characters from folder names (the `:` and/or `#` were the culprit below)
- `/usr/local/share/dotnet/sdk/2.2.107/15.0/Microsoft.Common.props(66,3): error MSB4019: The imported project "/Users/studentsname/Desktop/Professional Career/Coding Dojo/C#:.Net Core/Project/obj/Project.csproj.*.props" was not found. Confirm that the path in the <Import> declaration is correct, and that the file exists on disk. [/Users/studentsname/Desktop/Professional Career/Coding Dojo/C#:.Net Core/Project/Project.csproj]`

---

## SQL null in query string

- for nullable numerical types, C# will auto conver `null` to string when insterted into a string and turn it into `''` which will break if SQL is expecting either `null` or a numerical type
- the string `'null'` needs to be concatenated into the query string

## "Parameterless constructor" error

- If you overloaded the default constructor (made your own constructor) you must add back in the default parameterless constructor
  - `public ModelName () {}`
    - ASP.NET depends on this constructor to automatically construct your models for you
