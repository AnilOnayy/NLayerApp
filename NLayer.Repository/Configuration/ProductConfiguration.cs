using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;

namespace NLayer.Repository.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)"); // Toplam 18 karaker virgülden sonra 2 karakter
            builder.ToTable("Products");

            builder
                .HasOne(x => x.Category) // Bir ürünün 1 kategorisi olabilir
                .WithMany(x => x.Products)  // 1 kategori birden fazla ürüne bağlı olabilir
                .HasForeignKey(x => x.CategoryId); // Product'da yabancı anahtar CategoryId Kolonudur.

        }
    }
}
