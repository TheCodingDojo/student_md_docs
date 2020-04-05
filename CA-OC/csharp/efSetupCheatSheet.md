# EF Setup Cheat Sheet

- open this file in VSCode and with it selected press `ctrl + shift + v` or right click it and open preview

## 1. Create New Project & Install Dependencies

1. `dotnet new mvc --no-https -o ProjName`
2. `dotnet add package MySql.Data.EntityFrameworkCore -v 8.0.11`
3. `dotnet add package Pomelo.EntityFrameworkCore.MySql -v 2.2.0`

## Project Files Setup

- delete following lines from `Startup.cs`

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

### 2. `appsettings.json`

- add "DBInfo" property (don't forget `,` that's needed before this new property)

  - ```json
      "DBInfo": {
        "Name": "MySqlConnection",
        "ConnectionString": "server=localhost;userid=root;password=root;port=3306;database=YOUR_DB_NAME;SslMode=None"
      }
    ```

### 3. Create `DbContext` model

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

## `Startup.cs`

### 4. `ConfigureServices` method

- add the below lines

- ```csharp
  services.AddDbContext<ForumContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
  services.AddSession();
  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
  ```

### 5. `Configure` method

- add below lines above `app.UseMvc`

- ```csharp
  app.UseStaticFiles();
  app.UseSession();
  ```

### 6. Add Controller Constructor to Receive DbContext

- inside your controller class, at the top

- ```csharp
  private ForumContext _db;
  public HomeController(ForumContext context)
  {
    _db = context;
  }
  ```

### 7. Add Whatever Other Models You Need

## Create DB (Migrate)

### 8. `dotnet ef migrations add NameThisMigration`

### 9. `dotnet ef database update`

### 10. Verify DB & Tables in workbench / mysql Shell

## Access Session from Views Directly

- add `@using Microsoft.AspNetCore.Http` in `Views/_ViewImports.cshtml`
- add `services.AddHttpContextAccessor();` in `ConfigureServices` in `Startup.cs`
- Access in a view: `<p>@Context.Session.GetString("UserFullName")</p>`
