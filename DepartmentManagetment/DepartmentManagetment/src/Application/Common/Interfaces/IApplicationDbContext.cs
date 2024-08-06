using DepartmentManagement.Domain.Entities;

namespace DepartmentManagement.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Department> Departments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
