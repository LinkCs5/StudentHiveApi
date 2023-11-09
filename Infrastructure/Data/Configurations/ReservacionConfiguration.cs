
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Data.Configurations;

public class ReservacionConfiguration : IEntityTypeConfiguration<Reservacion>
{
    public void Configure(EntityTypeBuilder<Reservacion> builder)
    {
        builder.ToTable("Reservaciones");
            builder.HasKey(e => e.IdReserva).HasName("PK__Reservac__12CAD9F4D0AFFDF6");

            builder.Property(e => e.IdReserva).HasColumnName("ID_Reserva");
            builder.Property(e => e.IdInquilino).HasColumnName("ID_Inquilino");
            builder.Property(e => e.IdPublicacion).HasColumnName("ID_Publicacion");

            builder.HasOne(d => d.IdInquilinoNavigation).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.IdInquilino)
                .HasConstraintName("FK__Reservaci__ID_In__3E52440B");

            builder.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.IdPublicacion)
                .HasConstraintName("FK__Reservaci__ID_Pu__3F466844");
        
    }
}