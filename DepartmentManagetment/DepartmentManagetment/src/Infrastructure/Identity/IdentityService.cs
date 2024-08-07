using Azure.Core;
using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Application.Common.Models;
using DepartmentManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DepartmentManagement.Infrastructure.Identity;
public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        return user?.UserName;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<List<UserVM>> GetUserVMs()
    {
        return await _userManager.Users.Select(x =>
        new UserVM { 
            Id = x.Id,  
            UserName = x.UserName, 
            DepartmentId = x.DepartmentId,
            PhoneNumber = x.PhoneNumber,
            FullName = x.FullName,
            Address = x.Adresss

        }).ToListAsync();
    }

    public async Task UpdateUserAsync(UserVM userVM)
    {
        var user = await _userManager.FindByIdAsync(userVM.Id);
        if (user != null)
        {
            user.FullName = userVM.FullName ?? string.Empty;
            user.Adresss = userVM.Address ?? string.Empty;
            user.PhoneNumber = userVM.PhoneNumber;
            user.DepartmentId = userVM.DepartmentId;
            // Update other properties as needed

            // Save changes
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            Guard.Against.NotFound(userVM.Id, userVM);

        }
        // Update user properties

    }



}
