using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Domain.Entities;

namespace DepartmentManagement.Application.Departments.Commands.UpdateDepartment;

public record UpdateDepartmentCommand : IRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _context.Departments
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (department == null)
        {
            throw new NotFoundException(nameof(Department), request.Id.ToString());
        }

        department.Name = request.Name;
        department.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
