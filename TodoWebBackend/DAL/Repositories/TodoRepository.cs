using DAL.DbContextBuilder;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoListDbContext _dbContext;

    public TodoRepository(TodoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Todo todo)
    {
        await _dbContext.Todo.AddAsync(todo);
    }

    public async Task<IReadOnlyList<Todo>> GetByTodoListIdAsync(int todoListId)
    {
        return await _dbContext
            .Todo
            .Where(x => x.TodoListId == todoListId)
            .ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        return await _dbContext.Todo.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IReadOnlyList<Todo>> GetActiveByTodoListIdAsync(int todoListId)
    {
        return await _dbContext
            .Todo
            .Where(x => x.TodoListId == todoListId && x.Active)
            .ToListAsync();
    }

    public Task UpdateAsync(Todo todo)
    {
        _dbContext.Todo.Update(todo);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Todo todo)
    {
        _dbContext.Todo.Remove(todo);
        return Task.CompletedTask;
    }
}