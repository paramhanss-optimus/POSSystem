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
    public class InventoryEntityConfiguration : IEntityTypeConfiguration<InventoryEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryEntity> builder)
        {
            builder.HasKey(r => r.ProductId);
            
            builder.Property(r => r.ProductId)
                   .ValueGeneratedOnAdd();

            builder.Property(r => r.ProductName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.ProductStock)
                   .IsRequired();
        }
    }
}


