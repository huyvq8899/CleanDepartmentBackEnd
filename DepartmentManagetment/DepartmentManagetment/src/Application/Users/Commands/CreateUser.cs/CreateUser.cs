using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Application.Common.Interfaces;

namespace DepartmentManagetment.Application.Users.Commands.CreateUser.cs;

public record CreateUserCommand : IRequest<string>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IIdentityService _identityService;
    public CreateUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        string result = string.Empty;

        var resultCreate = await _identityService.CreateUserAsync(request.Email, request.Password);

        if (resultCreate.Result.Succeeded)
        {
            result = resultCreate.UserId;
        }

        return result;
    }

}
