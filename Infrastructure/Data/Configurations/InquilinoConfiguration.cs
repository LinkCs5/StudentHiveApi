
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Data.Configurations;

public class InquilinoConfiguration : IEntityTypeConfiguration<Inquilino>
{
    public void Configure (EntityTypeBuilder<Inquilino> builder)
    {
        builder.ToTable("Inquilinos");

            builder.HasKey(e => e.IdInquilino).HasName("PK__Inquilin__495B043C89148494");

            builder.Property(e => e.IdInquilino).HasColumnName("ID_Inquilino");
            builder.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.NombreInquilino)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombreInquilino");
            builder.Property(e => e.NumeroTelefono)
                .HasMaxLength(100)
                .IsUnicode(false);

    }
}