using DepartmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace DepartmentManagement.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Department> Departments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

}
