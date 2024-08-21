using System.Globalization;
using DepartmentManagement.Application.Common.Models;
using DepartmentManagement.Application.Departments.Queries.GetDepartmentList;
using DepartmentManagement.Application.Users.Queries;
using DepartmentManagement.Infrastructure.Identity;
using DepartmentManagetment.Application.Users.Commands.CreateUser.cs;
using DepartmentManagetment.Application.Users.Commands.DeleteUser;
using DepartmentManagetment.Application.Users.Commands.UpdateUser;
using DepartmentManagetment.Application.Users.Queries.CheckEmailUserDuplicate;
using DepartmentManagetment.Application.Users.Queries.GetUsersWithPagination;

namespace DepartmentManagement.Web.Endpoints;
public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this) 

            .MapGet(GetUserVMs).MapPut(UpdateUser, "/{id}")
            .MapGet(GetUsersWithPagination, "GetUsersWithPagination")
            .MapGet(CheckEmailUserDuplicate, "CheckEmailUserDuplicate")
            .MapPost(CreateUser, "CreateUser")
            .MapDelete(DeleteUser, "{id}")
            .MapIdentityApi<ApplicationUser>();
    }

    /// <summary>
    /// Lấy danh sách nhân viên
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public Task<List<UserVM>> GetUserVMs(ISender sender)
    {
        return sender.Send(new GetUserListQuery());
    }

    /// <summary>
    ///  Cập nhật thông tin User
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="updateUserCommand"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task UpdateUser(ISender sender, UpdateUserCommand updateUserCommand, string id)
    {
        updateUserCommand.Id = id;
        return sender.Send(updateUserCommand);
    }

    /// <summary>
    /// Lấy danh sách user phân trang
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<PaginatedList<UserVM>> GetUsersWithPagination(ISender sender, [AsParameters] GetUsersWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    /// <summary>
    /// Kiểm tra email đc tạo hay chưa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<bool> CheckEmailUserDuplicate(ISender sender, [AsParameters] CheckEmailUserDuplicateQuery query)
    {
        return sender.Send(query);
    }
    /// <summary>
    /// Tạo mới user
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    public Task<string> CreateUser(ISender sender, [AsParameters] CreateUserCommand command)
    {
        return sender.Send(command);
    }

    /// <summary>
    ///  Xóa User
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    public Task DeleteUser(ISender sender, string id)
    {
        return sender.Send(new DeleteUserCommand(id));
    }
}
