using DepartmentManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DepartmentManagement.Infrastructure.Identity;
public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Id Phòng ban tương ứng với tài khoản
    /// </summary>
    public Guid? DepartmentId { get; set; }

    public Department? Department { get; set; }

    /// <summary>
    /// Tên đầy đủ
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Địa chỉ
    /// </summary>
    public string Adresss { get; set; } = string.Empty;
}
