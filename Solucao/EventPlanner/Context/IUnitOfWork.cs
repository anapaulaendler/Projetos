using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Context;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}