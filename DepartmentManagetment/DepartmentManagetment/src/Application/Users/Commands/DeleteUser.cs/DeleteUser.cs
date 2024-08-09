using DepartmentManagement.Application.Common.Interfaces;

namespace DepartmentManagetment.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(string userId) : IRequest;
public class DeleteUserCommandHanlder : IRequestHandler<DeleteUserCommand>
{
    private readonly IIdentityService _identityService;

    public DeleteUserCommandHanlder(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _identityService.DeleteUserAsync(request.userId);
    }
}
