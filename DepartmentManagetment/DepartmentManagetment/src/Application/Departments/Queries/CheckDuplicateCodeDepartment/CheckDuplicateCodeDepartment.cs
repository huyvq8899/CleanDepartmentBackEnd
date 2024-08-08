using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Application.Common.Interfaces;

namespace DepartmentManagetment.Application.Departments.Queries.CheckDuplicateCodeDepartment;
public record CheckDuplicateCodeDepartmentQuery : IRequest<bool>
{
    public string Code { get; init; } = string.Empty;
}
public class CheckDuplicateCodeDepartmentQueryHandler : IRequestHandler<CheckDuplicateCodeDepartmentQuery, bool>
{
    private readonly IApplicationDbContext _context;

    public CheckDuplicateCodeDepartmentQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(CheckDuplicateCodeDepartmentQuery request, CancellationToken cancellationToken)
    {
        return await _context.Departments.AnyAsync(x => x.Code == request.Code);
    }
}
