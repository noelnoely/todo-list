using DAL.Entities;

namespace DAL.Interfaces;

public interface ITodoRepository
{
    // Create
    Task AddAsync(Todo todo);

    // Read
    Task<IReadOnlyList<Todo>> GetByTodoListIdAsync(int todoListId);
    Task<Todo?> GetByIdAsync(int id);
    Task<IReadOnlyList<Todo>> GetActiveByTodoListIdAsync(int todoListId);

    // Update
    Task UpdateAsync(Todo todo);

    // Delete
    Task DeleteAsync(Todo todo);
}