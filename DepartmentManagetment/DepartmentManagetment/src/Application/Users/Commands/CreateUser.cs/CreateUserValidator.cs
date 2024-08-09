namespace DepartmentManagetment.Application.Users.Commands.CreateUser.cs;
public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
    }
}
