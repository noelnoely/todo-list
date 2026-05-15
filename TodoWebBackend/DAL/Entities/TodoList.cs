namespace DAL.Entities;

public class TodoList : IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
}