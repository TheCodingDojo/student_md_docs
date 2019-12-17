# Session not persisting w/ MVC template
- remove following lines from `Startup.cs`
- ``` csharp
  services.Configure<CookiePolicyOptions>(options =>
  {
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
  });
  ```
- ``` csharp
  app.UseHttpsRedirection();
  ```
- ``` csharp
  app.UseCookiePolicy();
  ```

# Custom Error Attributes
## `[FutureDate]` example
- if used with `[Required]`
  - need to add an if null check in future date code and return success to allow `[Required]` to handle the null

## if breakpoint in `[FutureDate]` won't trigger, in controller:
- ``` csharp
    if (newChef.DateOfBirth.Year == 1) 
    {
        if (ModelState.ContainsKey("DateOfBirth") == true) 
        {
            ModelState["DateOfBirth"].Errors.Clear();
        }
        ModelState.AddModelError("DateOfBirth", "Invalid Date");
    }
  ```

# Non-invocable method error on methods that are invocable
- re-build

# Import Error on Run
- remove special characters from folder names (the `:` and/or `#` were the culprit below)
- `/usr/local/share/dotnet/sdk/2.2.107/15.0/Microsoft.Common.props(66,3): error MSB4019: The imported project "/Users/studentsname/Desktop/Professional Career/Coding Dojo/C#:.Net Core/Project/obj/Project.csproj.*.props" was not found. Confirm that the path in the <Import> declaration is correct, and that the file exists on disk. [/Users/studentsname/Desktop/Professional Career/Coding Dojo/C#:.Net Core/Project/Project.csproj]`

# SQL null in query string
- for nullable numerical types, C# will auto conver `null` to string when insterted into a string and turn it into `''` which will break if SQL is expecting either `null` or a numerical type
- the string `'null'` needs to be concatenated into the query string