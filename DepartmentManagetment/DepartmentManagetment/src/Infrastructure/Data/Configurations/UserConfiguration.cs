using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManagement.Domain.Entities;
using DepartmentManagement.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepartmentManagetment.Infrastructure.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.Adresss).HasMaxLength(255);
        builder.Property(x =>x.FullName).HasMaxLength(255);
    }
}
