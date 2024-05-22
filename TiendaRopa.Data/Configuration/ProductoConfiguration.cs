using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TiendaRopa.Models;

namespace TiendaRopa.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Talla).IsRequired();
            builder.Property(x => x.Color).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Precio).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(200);
        }
    }
}
