using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSystem.Domain.Entities;
using POSSystem.Domain.Entities;

namespace POSSystem.Persistance.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProductEntity>
    {
        public void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {

            builder.HasKey(r => new { r.OrderId, r.ProductId });
            builder.HasOne(r => r.Order)
             .WithMany(r => r.OrderPro)
             .HasForeignKey(r => r.OrderId);

            builder.HasOne(r => r.Product)
             .WithMany(r => r.ProductOr)
             .HasForeignKey(r => r.ProductId);

            builder.Property(r => r.Quantity)
                .IsRequired();
        }

    }
}
