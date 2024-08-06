using DepartmentManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DepartmentManagement.Infrastructure.Identity;
public class ApplicationUser : IdentityUser
{
    public Guid? DepartmentId { get; set; }

    public Department? Department { get; set; }
}
