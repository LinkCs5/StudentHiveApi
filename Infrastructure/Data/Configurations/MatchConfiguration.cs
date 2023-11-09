
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Data.Configurations;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure( EntityTypeBuilder<Match> builder )
    {
        builder.ToTable("Matchs");

            builder.HasKey(e => e.IdMatch).HasName("PK__Matchs__5D365398AC91FF1F");

            builder.Property(e => e.IdMatch).HasColumnName("ID_Match");
            builder.Property(e => e.IdReserva).HasColumnName("ID_Reserva");

            builder.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Matchs)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__Matchs__ID_Reser__4222D4EF");

    }
}