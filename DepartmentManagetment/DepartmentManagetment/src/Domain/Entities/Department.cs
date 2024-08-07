namespace DepartmentManagement.Domain.Entities;
public class Department : BaseAuditableEntity
{
    /// <summary>
    /// Tên phòng ban
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Mô tả thông tin phòng ban
    /// </summary>
    public string Description { get; set; } = string.Empty;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
