using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbContextBuilder;

public class TodoListDbContext : DbContext
{
    public DbSet<TodoList> TodoList { get; set; }
    public DbSet<Todo> Todo { get; set; }

    public TodoListDbContext(DbContextOptions<TodoListDbContext> contextOptions) : base(contextOptions)
    {
        
    }
}