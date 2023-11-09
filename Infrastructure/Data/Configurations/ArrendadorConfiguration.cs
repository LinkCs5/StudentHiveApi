
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Data.Configurations;

public class ArrendadorConfiguration : IEntityTypeConfiguration<Arrendador>
{
    public void Configure (EntityTypeBuilder<Arrendador> builder )
    {
        builder.ToTable("Arrendadores");
        builder.HasKey(e => e.IdAnfitrion).HasName("PK__Arrendad__4673ACC7D60D73A5");

            builder.Property(e => e.IdAnfitrion).HasColumnName("ID_Anfitrion");
            builder.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.NombreAnfitrion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombreAnfitrion");
            builder.Property(e => e.NumeroTelefono)
                .HasMaxLength(100)
                .IsUnicode(false);
    }
}