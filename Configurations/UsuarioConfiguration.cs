using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
         builder.ToTable("Usuarios");

         builder.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__DE4431C57DF46421");

            builder.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            builder.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            builder.Property(e => e.FechaDeCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false);
            builder.Property(e => e.NumeroTelefono)
                .HasMaxLength(100)
                .IsUnicode(false);

    }
}