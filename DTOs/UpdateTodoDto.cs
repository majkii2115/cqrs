namespace cqrs.DTOs;
public class UpdateTodoDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}