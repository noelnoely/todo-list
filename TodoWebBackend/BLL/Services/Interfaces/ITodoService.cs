using BLL.Dtos.Todo;

namespace BLL.Services.Interfaces;

public interface ITodoService
{
    Task<int?> CreateAsync(int todoListId, CreateTodoDto todo);
    Task<IReadOnlyList<TodoDto>> GetByTodoListIdAsync(int todoListId);
    Task<TodoDto?> GetByIdAsync(int id);
    Task<IReadOnlyList<TodoDto>> GetActiveByTodoListIdAsync(int todoListId);
    Task<bool> UpdateAsync(int id, UpdateTodoDto todo);
    Task<bool> DeleteAsync(int id);
}