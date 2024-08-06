using DepartmentManagement.Application.Common.Models;
using DepartmentManagement.Application.Departments.Queries.GetDepartmentList;
using DepartmentManagement.Application.Users.Queries;
using DepartmentManagement.Infrastructure.Identity;

namespace DepartmentManagement.Web.Endpoints;
public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this).MapGet(GetUserVMs)
            .MapIdentityApi<ApplicationUser>();
    }

    public Task<List<UserVM>> GetUserVMs(ISender sender)
    {
        return sender.Send(new GetUserListQuery());
    }
}
