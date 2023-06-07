using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;

namespace NLayer.Repository.Seeds
{
    internal class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature { Id = 1, ProductId = 1, Color = "Kırmızı", Height = 30, Width = 50 },
                new ProductFeature { Id = 2, ProductId = 2, Color = "Yeşil", Height = 30, Width = 50 },
                new ProductFeature { Id = 3, ProductId = 3, Color = "Sarı", Height = 30, Width = 50 },
                new ProductFeature { Id = 4, ProductId = 4, Color = "Mavi", Height = 30, Width = 50 },
                new ProductFeature { Id = 5, ProductId = 5, Color = "Turuncu", Height = 30, Width = 50 },
                new ProductFeature { Id = 6, ProductId = 6, Color = "Mor", Height = 30, Width = 50 }
                );
        }
    }
}
