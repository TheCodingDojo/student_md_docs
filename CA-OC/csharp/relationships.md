# Relationship Advice

## Determining The Relationship Status

- Given two entities: `EntityA` and `EntityB`, ask the following questions

1. Can **_One_** `EntityA` instance be related to **_Many_** `EntityB` instances?
   - if yes, the relationship is **_One_** `EntityA` to **_Many_** `EntityB`
2. Can **_One_** `EntityB` instance be related to **_Many_** `EntityA` instances?
   - if yes to question 1 & question 2: the relationship is a **_Many_** to **_Many_**
     - you need to create a third class to keep track of this relationship (see below example)
   - if no to question 1 & yes to question 2, the relationship is **_One_** `EntityB` to **_Many_** `EntityA`

### _One_ `EntityA` to _Many_ `EntityB`

- the foreign key goes on the many, so `EntityB` gets a `public int EntityAId { get; set; }` added to it
- `EntityA` gets a `List<EntityB>`
- reverse if the relationship is the other way around

### _Many_ to _Many_ between `EntityA` and `EntityB`

- the new class / model / entity that is created gets it's **own primary key** and a **foreign key from each related model** and a **property of each related model data type**

- ```csharp

  [Key]
  public int NewModelNameId { get; set; }

  public int EntityAId { get; set; }
  public int EntityBId { get; set; }

  // navigation properties
  public EntityA EntityA { get; set; }
  public EntityB EntityB { get; set; }
  ```

  - **BOTH `EntityA` and `EntityB` would then get a navigation property** `public List<NewModelName> NewModelNames { get; set; }`
  - sometimes it makes more sense to name the navigation property something other than the name of the class itself
  - e.g., instead of `public User User { get; set; }` it could be `public User Author { get; set; }`

---

## Model Example With 1:M & M:M

- `User` `Post` `Vote`
  - a `Post` as in posting on a forum
- 1 `User` : M `Post` (1 : Many)
  - `User` can make many `Post`s but `Post` can only be made by 1 `User`
- M : M (Many : Many)
  - `User` can `Vote` many times & `Post` can have many `Vote`s
  - essentially two 1 : M form a M : M
    - 1 `User` : M `Vote`
    - 1 `Post` : M `Vote`

---

### `User` Model

- ```csharp
  public class User
  {
    [Key] // denotes PK, not needed if formatted ModelNameId
    public int UserId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "is required.")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(8, ErrorMessage = "must be at least 8 characters")]
    [DataType(DataType.Password)] // auto fills input type attr
    public string Password { get; set; }

    [NotMapped] // don't add to DB
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "doesn't match password")]
    [Display(Name = "Confirm Password")]
    public string PasswordConfirm { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation Properties
    public List<Post> Posts { get; set; } // 1 User : M posts relationship
    public List<Vote> Votes { get; set; } // M : M (Each User & Each Post can have many Votes (two 1 : M))
  }
  ```

---

### `Post` Model

- ```csharp
  public class Post
  {
    [Key]
    public int PostId { get; set; }
    public int UserId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be more than 2 characters.")]
    [MaxLength(45, ErrorMessage = "must be less than 45 characters.")]
    public string Topic { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be more than 2 characters.")]
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation Properties
    public User Author { get; set; }
    public List<Vote> Votes { get; set; }
  }
  ```

---

### M:M Model / Table

- ```csharp
  public class Vote
  {
    public int VoteId { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public bool IsUpvote { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation Properties
    public User Voter { get; set; }
    public Post Post { get; set; }
  }
  ```
