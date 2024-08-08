using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Application.Common.Models;

namespace DepartmentManagetment.Application.Users.Queries;
public record GetUsersWithPaginationQuery : IRequest<PaginatedList<UserVM>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<UserVM>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;

    public GetUsersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService)
    {
        _context = context;
        _mapper = mapper;
        _identityService = identityService;
    }

    public async Task<PaginatedList<UserVM>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.GetPaginatedListUser(request);

    }
}
