using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace DepartmentManagement.Application.Departments.Commands.DeleteDepartment;

public record DeleteDepartmentCommand(Guid Id) : IRequest;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
{
    private readonly IApplicationDbContext _context;
    public DeleteDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments
        .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Departments.Remove(entity);


        await _context.SaveChangesAsync(cancellationToken);
    }
}
