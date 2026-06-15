using BLL.Dtos.Todo;
using BLL.Dtos.TodoList;
using BLL.Services;
using BLL.Services.Interfaces;
using BLL.Validation;
using BLL.Validation.Todo;
using BLL.Validation.TodoList;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        services.AddScoped<ITodoListService, TodoListService>();
        services.AddScoped<IValidator<CreateTodoListDto>, CreateTodoListDtoValidator>();
        services.AddScoped<IValidator<UpdateTodoListDto>, UpdateTodoListDtoValidator>();
        services.AddScoped<IValidator<CreateTodoDto>, CreateTodoDtoValidator>();
        services.AddScoped<IValidator<UpdateTodoDto>, UpdateTodoDtoValidator>();
        return services;
    }
}