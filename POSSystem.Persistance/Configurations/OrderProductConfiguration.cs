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
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderInventory>
    {
        public void Configure(EntityTypeBuilder<OrderInventory> builder)
        {

            builder.HasKey(r => new { r.OrderId, r.ProductId });
            builder.HasOne(r => r.Order)
             .WithMany(r => r.OrderInventory)
             .HasForeignKey(r => r.OrderId);

            builder.HasOne(r => r.Product)
             .WithMany(r => r.InventoryOrder)
             .HasForeignKey(r => r.ProductId);

            builder.Property(r => r.Quantity)
                .IsRequired();
        }

    }
}
