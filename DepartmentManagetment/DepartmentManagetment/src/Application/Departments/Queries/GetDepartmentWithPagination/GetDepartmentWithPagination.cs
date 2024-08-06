using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Application.Common.Mappings;
using DepartmentManagement.Application.Common.Models;

namespace DepartmentManagement.Application.Departments.Queries.GetDepartmentWithPagination;

public record GetDepartmentWithPaginationQuery : IRequest<PaginatedList<DepartmentDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetDepartmetWithPaginationQueryHandler : IRequestHandler<GetDepartmentWithPaginationQuery, PaginatedList<DepartmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDepartmetWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DepartmentDto>> Handle(GetDepartmentWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Departments
            .OrderBy(x => x.Name)
            .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
