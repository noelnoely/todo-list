using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL.DbContextBuilder;

public class TodoListDbContextFactory : IDesignTimeDbContextFactory<TodoListDbContext>
{
    public TodoListDbContext CreateDbContext(string[] args)
    {
        return CreateDbContext();
    }

    public TodoListDbContext CreateDbContext()
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddUserSecrets<TodoListDbContextFactory>()
            .Build();

        var optionBuilder = new DbContextOptionsBuilder<TodoListDbContext>();
        optionBuilder.UseSqlServer(configurationBuilder.GetConnectionString("DevelopmentConnection"));

        return new TodoListDbContext(optionBuilder.Options);
    }
}