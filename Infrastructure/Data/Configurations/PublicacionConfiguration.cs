
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Data.Configurations;

public class PublicacionConfiguration : IEntityTypeConfiguration<Publicacion>
{
    public void Configure( EntityTypeBuilder<Publicacion> builder)
    {
        builder.ToTable("Publicaciones");

            builder.HasKey(e => e.IdPublicacion).HasName("PK__Publicac__1EF15D3A16597549");

            builder.Property(e => e.IdPublicacion).HasColumnName("ID_Publicacion");
            builder.Property(e => e.Estatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            builder.Property(e => e.IdAnfitrion).HasColumnName("ID_Anfitrion");
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

            builder.HasOne(d => d.IdAnfitrionNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdAnfitrion)
                .HasConstraintName("FK__Publicaci__ID_An__3B75D760");


    }
}