using BLL.Dtos.Todo;
using DAL.Entities;

namespace BLL.Mappers;

public static class TodoMapper
{
    public static Todo ToEntity(this CreateTodoDto dto, int todoListId)
    {
        return new Todo
        {
            Name = dto.Name.Trim(),
            Description = dto.Description?.Trim(),
            Active = true,
            TodoListId = todoListId,
        };
    }

    public static TodoDto ToDto(this Todo entity)
    {
        return new TodoDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Active = entity.Active,
            TodoListId = entity.TodoListId,
        };
    }

    public static void UpdateEntity(this UpdateTodoDto dto, Todo entity)
    {
        entity.Name = dto.Name.Trim();
        entity.Description = dto.Description?.Trim();
    }
}