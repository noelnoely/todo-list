using BLL.Dtos.TodoList;
using BLL.Mappers;
using BLL.Services.Interfaces;
using DAL.Interfaces;

namespace BLL.Services;

public class TodoListService : ITodoListService
{
    private readonly ITodoListRepository _repository;

    public TodoListService(ITodoListRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateAsync(CreateTodoListDto todoListDto)
    {
        var entity = todoListDto.ToEntity();
        await _repository.AddAsync(entity);
        return entity.Id;
    }

    public async Task<IReadOnlyList<TodoListDto>> GetAllAsync()
    {
        var todoLists = await _repository.GetAllAsync();

        return todoLists
            .Select(todoList => todoList.ToDto())
            .ToList();
    }

    public async Task<TodoListDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity?.ToDto();
    }

    public async Task<bool> UpdateAsync(int id, UpdateTodoListDto todoListDto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return false;
        }

        todoListDto.UpdateEntity(entity);
        await _repository.UpdateAsync(entity);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return false;
        }

        await _repository.DeleteAsync(entity);
        return true;
    }
}