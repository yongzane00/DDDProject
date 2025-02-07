using DDDProject.Application.Commands;
using DDDProject.Domain.Entities;
using DDDProject.Domain.Repositories;

namespace DDDProject.Application.Handlers;

public class CreateOrderHandler
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(CreateOrderCommand command)
    {
        var order = new Order(command.CustomerName);
        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();
        return order.Id;
    }
}
