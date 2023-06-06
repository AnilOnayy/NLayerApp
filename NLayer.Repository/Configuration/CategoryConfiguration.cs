using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;

namespace NLayer.Repository.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id); // Primary Key
            builder.Property(x => x.Id).UseIdentityColumn(1, 1); // Identity  & Kaçtan başlayıp kaç kaç artıcak.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); // Zorunlu olsun ve max 50 karakter olsun.

            builder.ToTable("Categories"); // Veri tabanı tarafında tabloyu özel olarak isimlendirmek.
        }
    }
}
