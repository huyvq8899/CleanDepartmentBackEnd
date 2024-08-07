using System.Globalization;
using DepartmentManagement.Application.Common.Models;
using DepartmentManagement.Application.Departments.Queries.GetDepartmentList;
using DepartmentManagement.Application.Users.Queries;
using DepartmentManagement.Infrastructure.Identity;
using DepartmentManagetment.Application.Users.Commands;

namespace DepartmentManagement.Web.Endpoints;
public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this).MapGet(GetUserVMs).MapPut(UpdateUser, "/{id}")
            .MapIdentityApi<ApplicationUser>();
    }

    public Task<List<UserVM>> GetUserVMs(ISender sender)
    {
        return sender.Send(new GetUserListQuery());
    }

    public Task UpdateUser(ISender sender, UpdateUserCommand updateUserCommand, string id)
    {
        updateUserCommand.Id = id;
        return sender.Send(updateUserCommand);
    }
}
