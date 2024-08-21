using DepartmentManagement.Application.Common.Interfaces;
using DepartmentManagement.Domain.Constants;
using DepartmentManagement.Infrastructure.Data;
using DepartmentManagement.Infrastructure.Data.Interceptors;
using DepartmentManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>(); /// Dang ky service vao DI container
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>(); /// Dang ky service vao DI container

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            // Config my sql 
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)));
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        services.AddSingleton(TimeProvider.System);

        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        return services;
    }
}
