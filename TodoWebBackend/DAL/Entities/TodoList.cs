namespace DAL.Entities;

public class TodoList : IEntity
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public List<Todo> Todos { get; set; }
    
}