using BLL.Dtos.TodoList;
using DAL.Entities;

namespace BLL.Mappers;

public static class TodoListMapper
{
    public static TodoList ToEntity(this CreateTodoListDto dto)
    {
        return new TodoList
        {
            Name = dto.Name.Trim(),
        };
    }

    public static TodoListDto ToDto(this TodoList entity)
    {
        return new TodoListDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public static void UpdateEntity(this UpdateTodoListDto dto, TodoList entity)
    {
        entity.Name = dto.Name.Trim();
    }
}