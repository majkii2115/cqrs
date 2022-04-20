using cqrs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cqrs.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        var response = await _mediator.Send(new GetTodoById.Query(id));
        return response == null ? NotFound() : Ok(response);
    } 
}
