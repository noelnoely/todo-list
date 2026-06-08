namespace BLL.Dtos.Todo;

public class TodoDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool Active { get; set; }
    public int TodoListId { get; set; }
}