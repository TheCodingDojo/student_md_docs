# Model Example With 1:M & M:M
- `User` `Post` `Vote`
  - a `Post` as in posting on a forum
- 1 `User` : M `Post`
  - `User` can make many `Post`s but `Post` can only be made by 1 `User`
- M : M
  - `User` can `Vote` many times & `Post` can be have many `Vote`s
  - essentially two 1 : M
    - 1 `User` : M `Vote`
    - 1 `Post` : M `Vote`

## `User` Model
- ``` csharp
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

## `Post` Model
- ``` csharp
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

## M:M Model / Table
- ``` csharp
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