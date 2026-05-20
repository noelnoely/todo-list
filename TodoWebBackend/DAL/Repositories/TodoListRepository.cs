using DAL.DbContextBuilder;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TodoListRepository : ITodoListRepository
{
    private readonly TodoListDbContext _dbContext;

    public TodoListRepository(TodoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(TodoList todoList)
    {
        await _dbContext.TodoList.AddAsync(todoList);
    }

    public async Task<IReadOnlyList<TodoList>> GetAllAsync()
    {
        return await _dbContext.TodoList.ToListAsync();
    }

    public async Task<TodoList?> GetByIdAsync(int id)
    {
        return await _dbContext.TodoList.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task UpdateAsync(TodoList todoList)
    {
        _dbContext.TodoList.Update(todoList);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TodoList todoList)
    {
        _dbContext.TodoList.Remove(todoList);
        return Task.CompletedTask;
    }
}