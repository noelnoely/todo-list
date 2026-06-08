namespace BLL.Dtos.Todo;

public class CreateTodoDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int TodoListId { get; set; }
}