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
    public  class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(r => r.OrderId);
            builder.Property(r => r.OrderDate)
                   .IsRequired();

            builder.Property(r => r.OrderTotal)
                .IsRequired();

            builder.Property(r => r.OrderStatus)
                .IsRequired();

            builder.HasOne(r => r.Customer)
                .WithMany(r => r.Orders)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}


