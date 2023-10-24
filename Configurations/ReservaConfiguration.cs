using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;

public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.ToTable("Reservas");
         builder.HasKey(e => e.IdReservas).HasName("PK__Reservas__A6174464FD92F4AC");

            builder.Property(e => e.IdReservas).HasColumnName("ID_Reservas");
            builder.Property(e => e.IdHabitacion).HasColumnName("ID_Habitacion");
            builder.Property(e => e.IdPublicacion).HasColumnName("ID_Publicacion");
            builder.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            builder.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__Reservas__ID_Hab__403A8C7D");

            builder.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdPublicacion)
                .HasConstraintName("FK__Reservas__ID_Pub__4222D4EF");

            builder.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Reservas__ID_Usu__412EB0B6");
    }
}