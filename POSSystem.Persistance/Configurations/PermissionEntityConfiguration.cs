using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSystem.Domain.Entities;

namespace POSSystem.Persistance.Configurations
{
    public class PermissionEntityConfiguration : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.HasKey(r => r.PermissionId);
            builder.Property(r => r.PermissionName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(r => r.PermissionDescription)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(r => r.Roles)
                .WithMany(r => r.Permissions)
                .UsingEntity(j => j.ToTable("RolePermission"));

        }

    }
}


