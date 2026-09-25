using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the Session entity.
    /// </summary>
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> Builder)
        {
            Builder.ToTable("Sessions");

            Builder.HasKey(s => s.Id);

            Builder.Property(s => s.Id)
                .IsRequired();

            Builder.Property(s => s.OrgUnitId)
                .IsRequired();

            Builder.Property(s => s.SessionType)
                .IsRequired()
                .HasConversion<int>();

            Builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            Builder.Property(s => s.Description)
                .HasMaxLength(1000);

            Builder.Property(s => s.ScheduledStart)
                .IsRequired();

            Builder.Property(s => s.CreatedDate)
                .IsRequired();

            // Many-to-one: OrgUnit
            Builder.HasOne(s => s.OrgUnit)
                .WithMany()
                .HasForeignKey(s => s.OrgUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: AttendanceRecords
            Builder.HasMany(s => s.AttendanceRecords)
                .WithOne(ar => ar.Session)
                .HasForeignKey(ar => ar.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            Builder.HasIndex(s => s.OrgUnitId);

            Builder.HasIndex(s => s.ScheduledStart);

            Builder.HasIndex(s => s.SessionType);
        }
    }
}

