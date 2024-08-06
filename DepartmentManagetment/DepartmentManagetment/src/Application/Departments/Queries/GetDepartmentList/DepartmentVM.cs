using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Application.Departments.Queries.GetDepartmentWithPagination;
using DepartmentManagement.Domain.Entities;

namespace DepartmentManagement.Application.Departments.Queries.GetDepartmentList;

public class DepartmentVM
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    public DateTime? CreatedDate { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Department, DepartmentVM>();
        }
    }
}
