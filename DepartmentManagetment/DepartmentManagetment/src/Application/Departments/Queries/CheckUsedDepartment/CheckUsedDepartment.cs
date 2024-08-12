using DepartmentManagement.Application.Common.Interfaces;

namespace DepartmentManagetment.Application.Departments.Queries.CheckUsedDepartment;
public record CheckUsedDepartmentQuery : IRequest<bool>
{
    public Guid Id { get; set; }
};
public class CheckUsedDepartmentQueryHandler : IRequestHandler<CheckUsedDepartmentQuery, bool>
{
    private readonly IIdentityService _identityService;

    public CheckUsedDepartmentQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(CheckUsedDepartmentQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.CheckUserExistUserDepartment(request);
    }
}
