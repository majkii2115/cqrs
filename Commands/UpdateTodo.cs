using AutoMapper;
using cqrs.Database;
using cqrs.Domain;
using cqrs.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs.Commands;
public static class UpdateTodo
{
    public record Command(UpdateTodoDto updateTodoDto, int id) : IRequest<Response>;

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
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == command.id);
            if(todo is null) return null;

            _mapper.Map<UpdateTodoDto,Todo>(command.updateTodoDto, todo);

            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
            return new Response(todo.Id, todo.Name, todo.Description, todo.IsCompleted, todo.CreationDate);
        }
    }

    public record Response(int Id, string Name, string Description, bool IsCompleted, DateTime CreationDate);
}
