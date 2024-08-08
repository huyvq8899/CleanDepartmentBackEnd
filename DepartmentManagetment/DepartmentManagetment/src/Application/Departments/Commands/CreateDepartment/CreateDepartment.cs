using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Application.Departments.Commands.DeleteDepartment;
using DepartmentManagement.Application.Departments.Commands.UpdateDepartment;
using DepartmentManagement.Domain.Entities;

namespace DepartmentManagement.Application.Departments.Commands.CreateDepartment;

public record CreateDepartmentCommamd : IRequest<Guid>
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}
public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommamd, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateDepartmentCommamd request, CancellationToken cancellationToken)
    {
        Department department = new Department()
        {
            Name = request.Name,
            Description = request.Description,

        };

        await _context.Departments.AddAsync(department);

        await _context.SaveChangesAsync(cancellationToken);

        return department.Id;

    }


}
