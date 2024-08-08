using DepartmentManagement.Application.Common.Models;
using DepartmentManagement.Application.Departments.Commands.CreateDepartment;
using DepartmentManagement.Application.Departments.Commands.DeleteDepartment;
using DepartmentManagement.Application.Departments.Commands.UpdateDepartment;
using DepartmentManagement.Application.Departments.Queries.GetDepartmentList;
using DepartmentManagement.Application.Departments.Queries.GetDepartmentWithPagination;
using DepartmentManagetment.Application.Departments.Queries.CheckDuplicateCodeDepartment;
namespace DepartmentManagement.Web.Endpoints;


public class Departments : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this).RequireAuthorization()
            .MapGet(GetDepartmentWithPagination, "GetDepartmentWithPagination")
            .MapGet(GetDepartmentList)
            .MapGet(CheckCodeDuplicateDepartment, "CheckCodeDuplicateDepartment")
            .MapPost(CreateDepartment)
            .MapPut(UpdateDepartment, "/{id}")
            .MapDelete(DeleteDepartment, "/{id}");
    }
    /// <summary>
    /// Lấy thông tin phòng ban và phân trang
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<PaginatedList<DepartmentDto>> GetDepartmentWithPagination(ISender sender, [AsParameters] GetDepartmentWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    /// <summary>
    /// Lấy toàn bộ thông tin phòng ban
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public Task<List<DepartmentVM>> GetDepartmentList(ISender sender)
    {
        return sender.Send(new GetDepartmentListQuery());
    }

    /// <summary>
    /// Thêm mới phòng ban
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    public Task<Guid> CreateDepartment(ISender sender, CreateDepartmentCommamd command)
    {
        return sender.Send(command);
    }
    /// <summary>
    /// Cập nhật thông tin phòng ban
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>

    public Task UpdateDepartment(ISender sender, Guid id, UpdateDepartmentCommand command)
    {
        // Ensure the command has the correct id
        command = command with { Id = id };
        return sender.Send(command);
    }

    /// <summary>
    /// Xóa thông tin phòng ban
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeleteDepartment(ISender sender, Guid id)
    {
        return sender.Send(new DeleteDepartmentCommand(id));
    }

    /// <summary>
    ///  Hàm check trùng mã 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<bool> CheckCodeDuplicateDepartment(ISender sender, [AsParameters]  CheckDuplicateCodeDepartmentQuery query)
    {
        return sender.Send(query);
    }
}
