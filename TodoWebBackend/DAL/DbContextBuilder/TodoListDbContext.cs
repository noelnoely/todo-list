using DAL.Entities;
using DAL.Seed;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbContextBuilder;

public class TodoListDbContext : DbContext
{
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<Todo> Todos { get; set; }

    public TodoListDbContext(DbContextOptions<TodoListDbContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoListDbContext).Assembly);
        InitialSeeding.UseSeed(modelBuilder);
    }
}