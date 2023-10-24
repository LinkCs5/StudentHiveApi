using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;

public class PublicacionConfiguration : IEntityTypeConfiguration<Publicacion>
{
    public void Configure(EntityTypeBuilder<Publicacion> builder)
    {
        builder.ToTable("Publicaciones");
        builder.HasKey(e => e.IdPublicacion).HasName("PK__Publicac__1EF15D3A4C6B5484");

            builder.Property(e => e.IdPublicacion).HasColumnName("ID_Publicacion");
            builder.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            builder.Property(e => e.IdHabitacion).HasColumnName("ID_Habitacion");
            builder.Property(e => e.Imagenes)
                .HasMaxLength(250)
                .IsUnicode(false);
            builder.Property(e => e.NumeroDeCuartosHabitacion).HasColumnName("NumeroDeCuartos_Habitacion");
            builder.Property(e => e.PrecioHabitacion)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Precio_Habitacion");
            builder.Property(e => e.Titulo)
                .HasMaxLength(500)
                .IsUnicode(false);
            builder.Property(e => e.UbicacionHabitacion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Ubicacion_Habitacion");

            builder.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__Publicaci__ID_Ha__3D5E1FD2");
    }
}