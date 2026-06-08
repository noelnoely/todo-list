using BLL.Dtos.Todo;
using BLL.Mappers;
using BLL.Services.Interfaces;
using DAL.Interfaces;

namespace BLL.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly ITodoListRepository _todoListRepository;

    public TodoService(ITodoRepository todoRepository, ITodoListRepository todoListRepository)
    {
        _todoRepository = todoRepository;
        _todoListRepository = todoListRepository;
    }

    public async Task<int?> CreateAsync(CreateTodoDto todoDto)
    {
        var todoListExists = await _todoListRepository.ExistsAsync(todoDto.TodoListId);
        if (!todoListExists)
        {
            return null;
        }

        var entity = todoDto.ToEntity();
        await _todoRepository.AddAsync(entity);
        return entity.Id;
    }

    public async Task<IReadOnlyList<TodoDto>> GetByTodoListIdAsync(int todoListId)
    {
        var entities = await _todoRepository.GetByTodoListIdAsync(todoListId);
        return entities
            .Select(todo => todo.ToDto())
            .ToList();
    }

    public async Task<TodoDto?> GetByIdAsync(int id)
    {
        var entity = await _todoRepository.GetByIdAsync(id);
        return entity?.ToDto();
    }

    public async Task<IReadOnlyList<TodoDto>> GetActiveByTodoListIdAsync(int todoListId)
    {
        var entities = await _todoRepository.GetActiveByTodoListIdAsync(todoListId);
        return entities
            .Select(todo => todo.ToDto())
            .ToList();
    }

    public async Task<bool> UpdateAsync(int id, UpdateTodoDto todo)
    {
        var entity = await _todoRepository.GetByIdAsync(id);
        if (entity == null)
        {
            return false;
        }

        todo.UpdateEntity(entity);
        await _todoRepository.UpdateAsync(entity);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _todoRepository.GetByIdAsync(id);
        if (entity == null)

        {
            return false;
        }

        await _todoRepository.DeleteAsync(entity);
        return true;
    }
}