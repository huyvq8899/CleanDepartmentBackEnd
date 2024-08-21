namespace DepartmentManagement.Domain.Entities;
public class Department : BaseAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    /// <summary>
    /// Tên phòng ban
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Mô tả thông tin phòng ban
    /// </summary>
    public string Description { get; set; } = string.Empty;
}

