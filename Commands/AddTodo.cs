using AutoMapper;
using cqrs.Database;
using cqrs.Domain;
using cqrs.DTOs;
using MediatR;

namespace cqrs.Commands;
public class AddTodo
{
    //Query/Command
    //All the data we need
    public record Command(AddTodoDto addToDoDto) : IRequest<Response>;

    //Handler
    //Bussiness logic to execute
    public class Handler : IRequestHandler<Command, Response>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public Handler(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Response> Handle(Command command, CancellationToken cancellationToken)
        {
            //All the business logic

            var todo = _mapper.Map<Todo>(command.addToDoDto);
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return new Response(todo.Id, todo.Name, todo.Description, todo.IsCompleted, todo.CreationDate);
        }
    }

    //Response
    //The data we want to return
    public record Response(int Id, string Name, string Description, bool IsCompleted, DateTime CreationDate);
}