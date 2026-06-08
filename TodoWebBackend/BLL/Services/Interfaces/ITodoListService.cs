using BLL.Dtos.TodoList;

namespace BLL.Services.Interfaces;

public interface ITodoListService
{
    Task<int> CreateAsync(CreateTodoListDto todoListDto);
    Task<IReadOnlyList<TodoListDto>> GetAllAsync();
    Task<TodoListDto?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, UpdateTodoListDto todoListDto);
    Task<bool> DeleteAsync(int id);
}