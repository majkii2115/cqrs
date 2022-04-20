using cqrs.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs.Commands;
public class DeleteTodo
{
    public record Command(int id) : IRequest<bool>;

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly DatabaseContext _context;
        public Handler(DatabaseContext context)
        {
            _context = context;
        } 
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == request.id);
            if(todo is null) return false;
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}