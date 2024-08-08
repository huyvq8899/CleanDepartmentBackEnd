using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Application.Common.Interfaces;

namespace DepartmentManagetment.Application.Users.Queries.CheckEmailUserDuplicate;

public record CheckEmailUserDuplicateQuery : IRequest<bool>
{
    public string Email { get; init; } = string.Empty;
}
public class CheckEmailUserDuplicateQueryHandler : IRequestHandler<CheckEmailUserDuplicateQuery, bool>
{
    private readonly IIdentityService _identityService;
    public CheckEmailUserDuplicateQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(CheckEmailUserDuplicateQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.CheckEmailUserDuplicate(request);
    }
}
