using cqrs.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs.Queries;
public class GetTodoById
{
    //Query/Command
    //All the data we need
    public record Query(int Id) : IRequest<Response>;

    //Handler
    //Bussiness logic to execute
    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly DatabaseContext _context;
        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            //All the business logic
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == request.Id);
            return todo == null ? null : new Response(todo.Id, todo.Name, todo.Description, todo.IsCompleted, todo.CreationDate);
        }
    }

    //Response
    //The data we want to return
    public record Response(int Id, string Name, string Description, bool Completed, DateTime CreationDate);
}