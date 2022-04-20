using cqrs.Database;
using MediatR;

namespace cqrs.Queries;
public static class GetTodoById
{
    //Query/Command
    //All the data we need
    public record Query(int Id) : IRequest<Response>;

    //Handler
    //Bussiness logic to execute
    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly Repository _repository;
        public Handler(Repository respository)
        {
            _repository = respository;
        }
        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            //All the business logic
            var todo = _repository.Todos.FirstOrDefault(x => x.Id == request.Id);
            return todo == null ? null : new Response(todo.Id, todo.Name, todo.Completed);
        }
    }

    //Response
    //The data we want to return
    public record Response(int Id, string Name, bool Completed);
}