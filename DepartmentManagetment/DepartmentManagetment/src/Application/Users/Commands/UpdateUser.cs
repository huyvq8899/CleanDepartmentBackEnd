using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Application.Common.Models;

namespace DepartmentManagetment.Application.Users.Commands;

public record UpdateUserCommand : IRequest
{
    public string Id { get; set; } = string.Empty;

    public string FullName { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public Guid? DepartmentId { get; init; }
}
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IIdentityService _identityService;

    public UpdateUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        UserVM user = new UserVM()
        {
            DepartmentId = request.DepartmentId,
            FullName = request.FullName, 
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            Id = request.Id
        };
        await _identityService.UpdateUserAsync(user);
    }
}
