/**
  The database context is the main class that coordinates Entity Framework functionality for a given data model. 
*/

using Microsoft.EntityFrameworkCore;

namespace credit_card_project.Models {
  public class TodoContext : DbContext {
    public TodoContext (DbContextOptions<TodoContext> options) : base (options) { }

    public DbSet<TodoItem> TodoItems { get; set; }
  }
}