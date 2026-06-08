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
        await _dbContext.Todos.AddAsync(todo);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Todo>> GetByTodoListIdAsync(int todoListId)
    {
        return await _dbContext
            .Todos
            .AsNoTracking()
            .Where(todo => todo.TodoListId == todoListId)
            .ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        return await _dbContext
            .Todos
            .AsNoTracking()
            .FirstOrDefaultAsync(todo => todo.Id == id);
    }

    public async Task<IReadOnlyList<Todo>> GetActiveByTodoListIdAsync(int todoListId)
    {
        return await _dbContext
            .Todos
            .AsNoTracking()
            .Where(todo => todo.TodoListId == todoListId && todo.Active)
            .ToListAsync();
    }

    public async Task UpdateAsync(Todo todo)
    {
        _dbContext.Todos.Update(todo);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Todo todo)
    {
        _dbContext.Todos.Remove(todo);
        await _dbContext.SaveChangesAsync();
    }
}