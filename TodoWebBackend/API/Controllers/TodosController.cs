using BLL.Dtos.Todo;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/todos")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpPost("/api/todo-lists/{todoListId}/todos")]
    public async Task<IActionResult> Create([FromRoute] int todoListId, [FromBody] CreateTodoDto todoDto)
    {
        var id = await _todoService.CreateAsync(todoListId, todoDto);
        if (id == null)
        {
            return NotFound();
        }

        return CreatedAtAction(
            nameof(GetById),
            new { id = id },
            id
        );
    }

    [HttpGet("/api/todo-lists/{todoListId}/todos")]
    public async Task<IActionResult> GetByTodoListId([FromRoute] int todoListId)
    {
        var todos = await _todoService.GetByTodoListIdAsync(todoListId);
        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var todo = await _todoService.GetByIdAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpGet("/api/todo-lists/{todoListId}/todos/active")]
    public async Task<IActionResult> GetActiveByTodoListId([FromRoute] int todoListId)
    {
        var todos = await _todoService.GetActiveByTodoListIdAsync(todoListId);
        return Ok(todos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, UpdateTodoDto todoDto)
    {
        var isUpdated = await _todoService.UpdateAsync(id, todoDto);
        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var isDeleted = await _todoService.DeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}