using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManagement.Application.Common.Models;
public class UserVM
{
    public string Id { get; set; } = string.Empty;
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Guid? DepartmentId { get; set; }

}
