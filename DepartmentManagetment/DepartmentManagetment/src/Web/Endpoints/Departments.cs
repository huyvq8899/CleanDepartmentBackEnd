using DepartmentManagement.Application.Common.Models;
using DepartmentManagement.Application.Departments.Commands.CreateDepartment;
using DepartmentManagement.Application.Departments.Commands.DeleteDepartment;
using DepartmentManagement.Application.Departments.Commands.UpdateDepartment;
using DepartmentManagement.Application.Departments.Queries.GetDepartmentList;
using DepartmentManagement.Application.Departments.Queries.GetDepartmentWithPagination;
namespace DepartmentManagement.Web.Endpoints;


public class Departments : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this).RequireAuthorization()
            .MapGet(GetDepartmentWithPagination, "GetDepartmentWithPagination")
            .MapGet(GetDepartmentList)
            .MapPost(CreateDepartment)
            .MapPut(UpdateDepartment, "/{id}")
            .MapDelete(DeleteDepartment, "/{id}");
    }

    public Task<PaginatedList<DepartmentDto>> GetDepartmentWithPagination(ISender sender, [AsParameters] GetDepartmentWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<List<DepartmentVM>> GetDepartmentList(ISender sender)
    {
        return sender.Send(new GetDepartmentListQuery());
    }

    public Task<Guid> CreateDepartment(ISender sender, CreateDepartmentCommamd command)
    {
        return sender.Send(command);
    }

    public Task UpdateDepartment(ISender sender, Guid id, UpdateDepartmentCommand command)
    {
        // Ensure the command has the correct id
        command = command with { Id = id };
        return sender.Send(command);
    }

    public Task DeleteDepartment(ISender sender, Guid id)
    {
        return sender.Send(new DeleteDepartmentCommand(id));
    }

}
