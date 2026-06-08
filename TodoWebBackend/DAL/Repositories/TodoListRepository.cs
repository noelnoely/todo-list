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
        await _dbContext.TodoLists.AddAsync(todoList);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<TodoList>> GetAllAsync()
    {
        return await _dbContext
            .TodoLists
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TodoList?> GetByIdAsync(int id)
    {
        return await _dbContext
            .TodoLists
            .AsNoTracking()
            .FirstOrDefaultAsync(todoList => todoList.Id == id);
    }

    public async Task UpdateAsync(TodoList todoList)
    {
        _dbContext.TodoLists.Update(todoList);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TodoList todoList)
    {
        _dbContext.TodoLists.Remove(todoList);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _dbContext
            .TodoLists
            .AsNoTracking()
            .AnyAsync(todoList => todoList.Id == id);
    }
}