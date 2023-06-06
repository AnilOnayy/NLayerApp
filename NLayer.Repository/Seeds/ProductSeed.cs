using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Faber Castell 0.7 Uçlu Kalem", Price = 100, Stock = 30, CreatedDate = DateTime.Now },
                new Product { Id = 2, CategoryId = 1, Name = "Faber Castell 0.9 Uçlu Kalem", Price = 120, Stock = 40, CreatedDate = DateTime.Now },
                new Product { Id = 3, CategoryId = 2, Name = "Kürk Mantolu Madonna", Price = 170, Stock = 30, CreatedDate = DateTime.Now },
                new Product { Id = 4, CategoryId = 2, Name = "Nietzsche Ağladığında", Price = 80, Stock = 10, CreatedDate = DateTime.Now },
                new Product { Id = 5, CategoryId = 3, Name = "Kareli 90 yaprak defter", Price = 30, Stock = 100, CreatedDate = DateTime.Now },
                new Product { Id = 6, CategoryId = 3, Name = "180 yaprak düz defter", Price = 80, Stock = 40, CreatedDate = DateTime.Now }
            );
        }
    }
}
