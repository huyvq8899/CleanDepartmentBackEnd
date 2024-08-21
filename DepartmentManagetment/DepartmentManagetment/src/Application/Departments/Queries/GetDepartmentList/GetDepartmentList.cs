using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Application.Common.Security;

namespace DepartmentManagement.Application.Departments.Queries.GetDepartmentList;
[Authorize]
public record GetDepartmentListQuery : IRequest<List<DepartmentVM>>;
public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, List<DepartmentVM>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDepartmentListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<DepartmentVM>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Departments.AsNoTracking().ProjectTo<DepartmentVM>(_mapper.ConfigurationProvider).
            OrderByDescending(x => x.CreatedDate).ToListAsync(cancellationToken);
    }


}
