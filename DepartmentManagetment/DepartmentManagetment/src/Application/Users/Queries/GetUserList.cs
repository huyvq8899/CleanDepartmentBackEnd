using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Application.Common.Models;

namespace DepartmentManagement.Application.Users.Queries;

public record GetUserListQuery : IRequest<List<UserVM>>;
public class GetUserListQueryHanlder : IRequestHandler<GetUserListQuery, List<UserVM>>
{
    private readonly IIdentityService _identityService;

    public GetUserListQueryHanlder(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<List<UserVM>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.GetUserVMs();
    }
}
