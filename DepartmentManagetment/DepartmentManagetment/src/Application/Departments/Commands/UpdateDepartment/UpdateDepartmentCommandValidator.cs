using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManagement.Application.Departments.Commands.UpdateDepartment;
public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(d => d.Code).MaximumLength(50);

        RuleFor(d => d.Name).MaximumLength(250);

        RuleFor(d => d.Description).MaximumLength(250);
    }
}
