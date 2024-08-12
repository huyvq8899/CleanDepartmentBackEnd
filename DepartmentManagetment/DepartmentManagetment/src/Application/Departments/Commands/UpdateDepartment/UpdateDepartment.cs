using DepartmentManagement.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace DepartmentManagement.Application.Departments.Commands.UpdateDepartment;

public record UpdateDepartmentCommand : IRequest
{
    public Guid Id { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<UpdateDepartmentCommand> _logger;
    public UpdateDepartmentCommandHandler(IApplicationDbContext context, ILogger<UpdateDepartmentCommand> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        using (var transaction = await _context.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                var department = await _context.Departments
                    .FindAsync(new object[] { request.Id }, cancellationToken);

                // Kiểm tra nếu phòng ban không tồn tại
                Guard.Against.NotFound(request.Id, department);

                // Cập nhật thông tin phòng ban
                department.Code = request.Code;
                department.Name = request.Name;
                department.Description = request.Description;

                // Lưu các thay đổi
                await _context.SaveChangesAsync(cancellationToken);

                // Commit transaction nếu không có lỗi
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);

                 _logger.LogError(ex, "An error occurred while updating the department.");
                throw;
            }
        }
    }

}
