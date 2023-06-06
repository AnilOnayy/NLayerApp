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
                new ProductFeature { ProductId = 1, Color = "Kırmızı", Height = 30, Width = 50 },
                new ProductFeature { ProductId = 2, Color = "Yeşil", Height = 30, Width = 50 },
                new ProductFeature { ProductId = 3, Color = "Sarı", Height = 30, Width = 50 },
                new ProductFeature { ProductId = 4, Color = "Mavi", Height = 30, Width = 50 },
                new ProductFeature { ProductId = 5, Color = "Turuncu", Height = 30, Width = 50 },
                new ProductFeature { ProductId = 6, Color = "Mor", Height = 30, Width = 50 }
                );
        }
    }
}
