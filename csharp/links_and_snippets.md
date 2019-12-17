- [MVC Diagram](https://mdn.mozillademos.org/files/16042/model-view-controller-light-blue.png)
- [Sports ORM Django C# Ver.](https://github.com/wgoode3/SportsORM)


# EF
## Update
- ``` csharp
  [HttpPost("editthing/{id}")]
  public IActionResult EditThis(int id, User editedUser)
  {
      if (ModelState.IsValid)
      {
            editedUser.UserId = id;
            dbContext.Update(editedUser);
            dbContext.Entry(editedUser).Property("CreatedAt").IsModified = false;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
      }
      return View("EditThing", editedUser);
  }
  ```