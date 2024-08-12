﻿using DepartmentManagement.Application.Common.Models;
using DepartmentManagement.Application.Departments.Queries.GetDepartmentWithPagination;
using DepartmentManagetment.Application.Departments.Queries.CheckUsedDepartment;
using DepartmentManagetment.Application.Users.Queries.CheckEmailUserDuplicate;
using DepartmentManagetment.Application.Users.Queries.GetUsersWithPagination;

namespace DepartmentManagement.Application.Common.Interfaces;
public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);

    Task<List<UserVM>>GetUserVMs();

    Task UpdateUserAsync(UserVM userVM);

    Task<PaginatedList<UserVM>> GetPaginatedListUser(GetUsersWithPaginationQuery query);

    Task<bool> CheckEmailUserDuplicate(CheckEmailUserDuplicateQuery query);
    Task<bool> CheckUserExistUserDepartment(CheckUsedDepartmentQuery query);

}
