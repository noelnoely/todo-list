namespace DAL.Entities;

public class Todo : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public int TodoListId { get; set; }
}