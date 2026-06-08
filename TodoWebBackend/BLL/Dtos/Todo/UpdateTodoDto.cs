namespace BLL.Dtos.Todo;

public class UpdateTodoDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}