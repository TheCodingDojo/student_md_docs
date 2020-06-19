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

## NullReferenceException

- The object you are trying to access properties on is null, look at where you tried to get the object from to find out where you could have gotten null from instead of what you wanted

---

## Reset Database

1. drop the migrations table in the db
2. delete migrations folder in project
3. fix models
4. `dotnet ef migrations add NameTheMigration`
5. `dotnet ef database update`

- If that doesn't work: delete migrations folder, drop database then migrate and update again to completely recreate the db (losing all data)

---

## Foreign Key Constraint Failure

- A foreign key is required on the model and was not provided, you need to provide it.
- `someModelInstance.NameOfForeignKey = someInteger;` where `someInteger` is the primary key of a different model

---

## Duplicate key primary - value `0`

- This means there is already a row in this table with a primary key of 0 and you are trying to add another one with primary key of 0
- The primary key shouldn't be 0, if MySQL is auto incrementing the primary key like we want it to, it will start at `1`
- In MySQL Workbench, right click the table, click alter table, then look at the primary key row, check if the `AI` (auto increment) box is checked. If it's not, something went wrong with your migrations, you can try checking it and applying the changes, but something else is probably wrong that caused it to not be checked in the first place
- Verify this model's primary key field is named properly following this pattern: `ModelNameId`, if it's not, fix it then migrate and update db
  - if it still doesn't work, following the Reset Database steps in this file

## Session not persisting w/ MVC template

- [Remove Cookie Consent from Startup.cs](http://learn.codingdojo.com/m/25/5671/39759)

---

## Custom Error Attributes

---

### `[FutureDate]` example

- if used with `[Required]`
  - need to add an if null check in future date code and return success to allow `[Required]` to handle the null

### if breakpoint in `[FutureDate]` won't trigger, in controller

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

---

## "Parameterless constructor" error

- If you overloaded the default constructor (made your own constructor) you must add back in the default parameterless constructor
  - `public ModelName () {}`
    - ASP.NET depends on this constructor to automatically construct your models for you

---

## `.Include` 'DbSet' does not contain a definition for 'Include'

- `using Microsoft.EntityFrameworkCore;`

---

## Ambiguous route / multiple routes match

- your controller has more than one method (action) with the same URL, change one of them

---

## Page not found

- first determine if the page that is not found is due to the a redirect or not
- put a `Console.WriteLine` or a breakpoint in the method (action) that is handling the **\*request**, if the `Console.WriteLine` happens or the breakpoint is triggered, then it is the redirect inside this method (action) that is likely causing the problem

---

## Authentication method 'caching_sha2_password' failed

- you forgot to select "Use Legacy Authentication Method" option when installing MySql, uninstall, restart computer then [reinstall](https://github.com/TheCodingDojo/student_md_docs/blob/master/CA-OC/mysql_README.md)
