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
    public class AdminEntityConfiguration : IEntityTypeConfiguration<AdminEntity>
    {
        public void Configure(EntityTypeBuilder<AdminEntity> builder)
        {

            builder.HasKey(r => r.AdminId);
            builder.Property(r => r.AdminName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(r => r.User)
                .WithOne(r => r.Admin)
                .HasForeignKey<AdminEntity>(r => r.AdminId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}


