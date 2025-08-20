using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KayraExport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KayraExport.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(300);

            builder.Property(p => p.Price)
                .HasPrecision(10,2);

            builder.Property(p => p.Stock)
                .IsRequired();
        }
    }
}