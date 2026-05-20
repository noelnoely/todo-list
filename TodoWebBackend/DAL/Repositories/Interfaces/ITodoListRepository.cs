using DAL.Entities;

namespace DAL.Interfaces;

public interface ITodoListRepository
{
    // Create:
    Task AddAsync(TodoList todoList);

    // Read:
    Task<IReadOnlyList<TodoList>> GetAllAsync();
    Task<TodoList?> GetByIdAsync(int id);

    // Update:
    Task UpdateAsync(TodoList todoList);

    // Delete:
    Task DeleteAsync(TodoList todoList);
}