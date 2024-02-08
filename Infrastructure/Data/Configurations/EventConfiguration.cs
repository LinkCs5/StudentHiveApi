using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;


public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");        
            builder.HasKey(e => e.IdEvent).HasName("PK__Events__12A4DF3F89DFF1DE");

            builder.Property(e => e.IdEvent).HasColumnName("ID_Event");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.EventType)
                .HasMaxLength(50)
                .IsUnicode(false);
    }
}