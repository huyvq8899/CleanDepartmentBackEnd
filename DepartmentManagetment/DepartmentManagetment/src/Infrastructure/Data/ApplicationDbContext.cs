using System.Reflection;
using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Domain.Entities;
using DepartmentManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DepartmentManagement.Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    /// <summary>
    ///  Value base
    /// </summary>
    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    #region Department
    public DbSet<Department> Departments => Set<Department>();
    #endregion

    #region Employee
    public DbSet<Employee> Employees => Set<Employee>();
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
