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
    public  class CashierEntityConfiguration : IEntityTypeConfiguration<CashierEntity>
    {
        public void Configure(EntityTypeBuilder<CashierEntity> builder)
        {
            builder.HasKey(r => r.CashierId);
            builder.Property(r => r.CashierName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(r => r.User)
               .WithOne(r => r.Cashier)
               .HasForeignKey<CashierEntity>(r => r.CashierId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

