namespace cqrs.Domain;

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
}