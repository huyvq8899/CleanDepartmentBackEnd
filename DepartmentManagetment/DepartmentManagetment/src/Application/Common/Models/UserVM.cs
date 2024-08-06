using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManagement.Application.Common.Models;
public class UserVM
{
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }

}
