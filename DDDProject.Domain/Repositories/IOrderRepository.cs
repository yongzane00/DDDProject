using DDDProject.Domain.Entities;

namespace DDDProject.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(Guid id);
    Task AddAsync(Order order);
    Task SaveChangesAsync();
}
