using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManagement.Application.Departments.Commands.CreateDepartment;
public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommamd>
{
    public CreateDepartmentValidator()
    {
        RuleFor(d => d.Name).MaximumLength(200);

        RuleFor(d => d.Description).MaximumLength(250); 
    }
}
