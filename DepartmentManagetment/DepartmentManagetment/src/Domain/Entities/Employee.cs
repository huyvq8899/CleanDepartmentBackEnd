using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManagement.Domain.Entities;
public class Employee : BaseAuditableEntity
{
    /// <summary>
    /// Tên nhân viên
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Email nhân viên
    /// </summary>
    public string Email { get; set; } = string.Empty;
    /// <summary>
    /// Phòng ban của nhân viên
    /// </summary>
    public Guid? DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}
