# EF Setup Cheat Sheet

## 1. Create New Project & Install Dependencies

1. `dotnet new mvc --no-https -o ProjName`
2. `dotnet add package Pomelo.EntityFrameworkCore.MySql -v 2.2.0`
   - [Learn platform version number reference](http://learn.codingdojo.com/m/25/5675/40112)

---

## Project Files Setup

- [delete following lines from `Startup.cs`](http://learn.codingdojo.com/m/25/5671/39759)

  - ```csharp
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });
    ```

  - `app.UseHttpsRedirection();`
  - `app.UseCookiePolicy();`

- delete `<partial name="_CookieConsentPartial"></partial>` from `_Layout.cs`

---

### 2. `appsettings.json`

- add "DBInfo" property (don't forget `,` that's needed before this new property)

  - ```json
      "DBInfo": {
        "Name": "MySqlConnection",
        "ConnectionString": "server=localhost;userid=root;password=root;port=3306;database=YOUR_DB_NAME;SslMode=None"
      }
    ```

---

### 3. Create `DbContext` model

- rename `ForumContext` to something relevant to your project
- use your own model name and namespace

- ```csharp
  using Microsoft.EntityFrameworkCore;

  namespace Forum.Models
  {
    public class ForumContext : DbContext
    {
      public ForumContext(DbContextOptions options) : base(options) { }
      // tables in db
      public DbSet<User> Users { get; set; }
      public DbSet<Post> Posts { get; set; }
      public DbSet<Vote> Votes { get; set; }
    }
  }
  ```

---

## `Startup.cs`

---

### 4. `ConfigureServices` method

- add the below lines using your own context name instead of `ForumContext`

- ```csharp
  services.AddDbContext<ForumContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
  services.AddSession();
  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
  ```

---

### 5. `Configure` method

- add below lines above `app.UseMvc`

- ```csharp
  app.UseStaticFiles();
  app.UseSession();
  ```

---

### 6. Add Controller Constructor to Receive DbContext

- inside your controller class, at the top

- ```csharp
  private ForumContext db;
  public HomeController(ForumContext context)
  {
    db = context;
  }
  ```

---

### 7. Add Whatever Other Models You Need

---

## Create DB (Migrate)

---

### 8. `dotnet ef migrations add GiveANameToThisMigration`

---

### 9. `dotnet ef database update`

---

### 10. Verify DB & Tables in workbench / mysql Shell

---

## Optional: Access Session from Views Directly

- this is helpful if you are repeatedly adding the same thing from session into the `ViewBag` for many actions
- add `@using Microsoft.AspNetCore.Http` in `Views/_ViewImports.cshtml`
- add `services.AddHttpContextAccessor();` in `ConfigureServices` in `Startup.cs`
- Access in a view: `<p>@Context.Session.GetString("UserFullName")</p>`

---

## Request Response Cycle Review (if you can't explain this effortlessly when asked to, keep re-reading it)

1. the **_client_** makes a **_request_** by visiting a URL
   - a URL is usually visited by the **_client_** clicking on an anchor tag (GET request), typing a URL into the address bar (GET), submitting a form (POST)
2. the **_server_** receives the **_request_** and runs the method (action) that has the matching URL
3. the **_server_** **_responds_** to the request by **_serving_** up an HTML page (rendering), or redirecting to another action method which has it's own URL
4. the request response cycle is complete
   - a redirect triggers an additional request response cycle, the **_response_** is a redirect which triggers a **_request_** for the URL that the client was redirected to

---

## Routing Review

---

### Route Parameters

- read the Request Response Cycle Review
- a route parameter is a placeholder in a URL that is given a name when the route is set up in the controller
  - just like a parameter in a function, it is a placeholder name that will be given a value later on (when function is called / route is visited)
  - the controller method (action) needs a corresponding parameter with a matching name for every parameter in the URL
  - when redirecting to a controller method (action), if that action has parameters, they need to be provided when redirecting

---

### Where are the route parameter placeholders given an actual value

- this happens either in the HTML files or when redirecting in the controller
  - `<a>` tags and `<form>` tags need to have actual parameter values added to them using razor
    - the values are inserted either directly into the `<a>` tag's `href` and the `<form>` tag's `action` attributes or using ASP.NET tag helpers

---

#### Route Parameter Example

- ```html
  <a href="/Quotes/@Model.QuoteId">
    View Quote
  </a>
  ```

- OR

  - ```html
    <a
      asp-controller="Quotes"
      asp-action="Details"
      asp-route-quoteId="@Model.QuoteId"
    >
      View Quote
    </a>
    ```

- the above `<a>` tags would create an `href` that looks like this with some id value inserted: `href="/Quotes/5"`
- these URLS would match / connect to a URL pattern in the `QuotesController`

  - ```csharp
    // the parameter in the method has to have the same name as the route parameter in the URL
    // and the same name as the asp-route-paramName tag helper if using that
    [HttpGet("Quotes/{quoteId}")]
    public IActionResult Details(int quoteId)
    ```

---

### Routing with a `<form>`

- a form needs a way for the **_client_** to **_request_** it to be displayed (rendered), therefore a URL / route is needed for displaying / rendering the HTML page that has the `<form>` in it
  - GET **_request_** to GET the page that displays the `<form>`
  - there will be a controller method (action) with matching URL to handle the **_request_** that will **_respond_** with `return View()` to display the HTML page with the `<form>` in it
- the form needs a DIFFERENT URL / route to submit to so the submission can be processed, this URL is specified in the `<form>` `action` attribute or the ASP.NET tag helpers on the `<form>` tag
  - the URL / route that the `<form>` submits to (POST **_request_**) needs a corresponding controller method (action) with a matching URL
    - this method (action) will **_respond_** with either a `return RedirectToAction` if successful or a `return View("NameOfView")` if there was a validation error to display the `<form>` again with error messages

---

#### `<form>` routing example

- handle the _request_ for the `<form>` to be displayed

  - ```csharp
    [HttpGet("/Quotes/New")]
    public IActionResult New()
    {
      return View();
    }
    ```

- ```html
  <form asp-controller="Quotes" asp-action="Create" method="POST"></form>
  ```

- OR

  - ```html
    <form action="/Quotes/Create" method="POST"></form>
    ```

- form submits to the route that matches the `action` attribute or the `asp-controller` and `asp-action`, MAY NEED TO ADD A ROUTE PARAMETER TO THE FORM if the controller method (action) that the `<form>` submits to needs more information

- ```csharp
  [HttpPost("/Quotes/Create")] public IActionResult Create(Quote newQuote)
  {
    if (ModelState.IsValid == false)
    {
        // to display validation error messages
        return View("New");
    }

    // no validation errors: save to database then redirect
    // if action redirecting to has parameters, must provide them here as well
    return RedirectToAction("NameOfControllerMethod");
  }
  ```

---

## [Troubleshooting](https://github.com/TheCodingDojo/student_md_docs/blob/master/CA-OC/csharp/troubleshooting.md)

---

## [Relationship Advice](https://github.com/TheCodingDojo/student_md_docs/blob/master/CA-OC/csharp/relationships.md)

---

## Old stuff

- `dotnet add package MySql.Data.EntityFrameworkCore -v 8.0.11`
