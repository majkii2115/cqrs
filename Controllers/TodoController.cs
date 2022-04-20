using cqrs.Commands;
using cqrs.DTOs;
using cqrs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cqrs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("getTodo/{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        var todo = await _mediator.Send(new GetTodoById.Query(id));
        return todo == null ? NotFound("Not found todo item with given id.") : Ok(todo);
    } 

    [HttpPost("addTodo")]
    public async Task<IActionResult> AddTodo([FromBody] AddTodoDto addTodoDto)
    {
        var todo = await _mediator.Send(new AddTodo.Command(addTodoDto));
        return Ok(todo);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoDto updateTodoDto, int id)
    {
        var todo = await _mediator.Send(new UpdateTodo.Command(updateTodoDto, id));
        return todo == null ? NotFound("Not found todo item with given id.") : Ok(todo);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var response = await _mediator.Send(new DeleteTodo.Command(id));
        return response == true ? Ok() : NotFound("Not found todo item with given id."); 
    }
}
