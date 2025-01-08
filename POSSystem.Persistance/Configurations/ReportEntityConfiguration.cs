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
    public  class ReportEntityConfiguration : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            builder.HasKey(r => r.ReportId);
            builder.Property(r => r.ReportName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.TotalSales)
                   .IsRequired();

            builder.Property(r => r.TotalPurchases)
                .IsRequired();


            builder.Property(r => r.TotalOrders)
                .IsRequired();

        }
    }
}




