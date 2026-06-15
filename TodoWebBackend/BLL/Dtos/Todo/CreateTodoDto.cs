namespace BLL.Dtos.Todo;

public class CreateTodoDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}