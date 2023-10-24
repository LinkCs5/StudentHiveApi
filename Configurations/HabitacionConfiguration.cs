using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;

public class HabitacionConfiguration : IEntityTypeConfiguration<Habitacion>
{
    public void Configure(EntityTypeBuilder<Habitacion> builder)
    {
        builder.ToTable("Habitaciones");
        builder.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__9B68325418810F81");

            builder.Property(e => e.IdHabitacion).HasColumnName("ID_Habitacion");
            builder.Property(e => e.FechaPublicacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.Precio).HasColumnType("decimal(8, 2)");
            builder.Property(e => e.Ubicacion)
                .HasMaxLength(250)
                .IsUnicode(false);
    }
}
