using DDDProject.Application.Commands;
using DDDProject.Application.Handlers;
using DDDProject.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DDDProject.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly CreateOrderHandler _createOrderHandler;

    public OrdersController(CreateOrderHandler createOrderHandler)
    {
        _createOrderHandler = createOrderHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        if (string.IsNullOrEmpty(command.CustomerName))
            return BadRequest(new { message = "Customer name is required." });

        var orderId = await _createOrderHandler.Handle(command);

        return CreatedAtAction(nameof(GetOrder), new { id = orderId }, new { id = orderId });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder([FromServices] IOrderRepository repository, Guid id)
    {
        var order = await repository.GetByIdAsync(id);
        if (order == null) return NotFound(new { message = "Order not found." });

        return Ok(order);
    }
}
