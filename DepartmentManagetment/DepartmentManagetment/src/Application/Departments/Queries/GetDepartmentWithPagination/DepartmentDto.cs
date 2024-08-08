using DepartmentManagement.Domain.Entities;

namespace DepartmentManagement.Application.Departments.Queries.GetDepartmentWithPagination;
public class DepartmentDto
{
    public Guid Id { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}
