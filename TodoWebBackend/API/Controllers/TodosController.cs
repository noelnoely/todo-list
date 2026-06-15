using BLL.Dtos.Todo;
using BLL.Services.Interfaces;
using BLL.Validation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/todos")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly IValidator<CreateTodoDto> _createValidator;
    private readonly IValidator<UpdateTodoDto> _updateValidator;

    public TodosController(ITodoService todoService, IValidator<CreateTodoDto> createValidator,
        IValidator<UpdateTodoDto> updateValidator)
    {
        _todoService = todoService;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpPost("/api/todo-lists/{todoListId}/todos")]
    public async Task<IActionResult> Create([FromRoute] int todoListId, [FromBody] CreateTodoDto todoDto)
    {
        var validationResult = _createValidator.Validate(todoDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

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
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoDto todoDto)
    {
        var validationResult = _updateValidator.Validate(todoDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

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