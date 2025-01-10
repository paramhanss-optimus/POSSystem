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
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(r => r.UserId);

            builder.Property(r => r.Password)
                   .IsRequired();

            builder.Property(r => r.Email)
                .IsRequired();

            

            builder.HasOne(r => r.Customer)
             .WithOne(r => r.User)
             .HasForeignKey<UserEntity>(r => r.CustomerId)
             .OnDelete(DeleteBehavior.Cascade);

        }
    }
}


