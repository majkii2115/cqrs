using cqrs.Domain;

namespace cqrs.Database;
public class Repository
{   
    public List<Todo> Todos = new List<Todo>
    {
        new Todo {Id = 1, Name = "blabla", Completed = false},
        new Todo {Id = 2, Name = "Two", Completed = true},
        new Todo {Id = 3, Name = "Trzy", Completed = false},
        new Todo {Id = 4, Name = "Four", Completed = true}
        
    };
}