using ApiProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.İmagePath).IsRequired();
            builder.HasData(new[]
            {
                new Product(){Id=1,Name="Samsung S6", Price=5000, Stock=45, CreatedDate=DateTime.Now,İmagePath="aieaieaieaieaiea",CategoryId=1},
                  new Product(){Id=2,Name="Samsung S7", Price=6000, Stock=55, CreatedDate=DateTime.Now,İmagePath="eeee",CategoryId=2},
                    new Product(){Id=3,Name="Samsung S8", Price=7000, Stock=55, CreatedDate=DateTime.Now,İmagePath="iiii",CategoryId=1}
            });
        }
    }
}
