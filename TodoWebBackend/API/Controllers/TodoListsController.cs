using BLL.Dtos.TodoList;
using BLL.Services.Interfaces;
using BLL.Validation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/todo-lists")]
public class TodoListsController : ControllerBase
{
    private readonly ITodoListService _todoListService;
    private readonly IValidator<CreateTodoListDto> _createValidator;
    private readonly IValidator<UpdateTodoListDto> _updateValidator;

    public TodoListsController(ITodoListService todoListService, IValidator<CreateTodoListDto> createValidator,
        IValidator<UpdateTodoListDto> updateValidator)
    {
        _todoListService = todoListService;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoListDto todoListDto)
    {
        var validationResult = _createValidator.Validate(todoListDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var id = await _todoListService.CreateAsync(todoListDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id, },
            id
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todoLists = await _todoListService.GetAllAsync();

        return Ok(todoLists);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var todoList = await _todoListService.GetByIdAsync(id);
        if (todoList == null)
        {
            return NotFound();
        }

        return Ok(todoList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoListDto todoListDto)
    {
        var validationResult = _updateValidator.Validate(todoListDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var isUpdated = await _todoListService.UpdateAsync(id, todoListDto);
        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var isDeleted = await _todoListService.DeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}