namespace DepartmentManagetment.Application.Departments.Queries.CheckDuplicateCodeDepartment;
public class CheckDuplicateCodeDepartmentValidator : AbstractValidator<CheckDuplicateCodeDepartmentQuery>
{
    public CheckDuplicateCodeDepartmentValidator()
    {
        RuleFor(x => x.Code).MaximumLength(50);
    }
}
