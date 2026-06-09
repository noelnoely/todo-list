using DAL.DbContextBuilder;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TodoListDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<ITodoListRepository, TodoListRepository>();
        return services;
    }
}