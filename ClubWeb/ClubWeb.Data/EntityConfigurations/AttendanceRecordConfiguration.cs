using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the AttendanceRecord entity.
    /// </summary>
    public class AttendanceRecordConfiguration : IEntityTypeConfiguration<AttendanceRecord>
    {
        public void Configure(EntityTypeBuilder<AttendanceRecord> Builder)
        {
            Builder.ToTable("AttendanceRecords");

            Builder.HasKey(ar => ar.Id);

            Builder.Property(ar => ar.Id)
                .IsRequired();

            Builder.Property(ar => ar.SessionId)
                .IsRequired();

            Builder.Property(ar => ar.PersonId)
                .IsRequired();

            Builder.Property(ar => ar.CheckInTime)
                .IsRequired();

            // Many-to-one: Session
            Builder.HasOne(ar => ar.Session)
                .WithMany(s => s.AttendanceRecords)
                .HasForeignKey(ar => ar.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-one: Person
            Builder.HasOne(ar => ar.Person)
                .WithMany(p => p.AttendanceRecords)
                .HasForeignKey(ar => ar.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint: One attendance record per person per session
            Builder.HasIndex(ar => new { ar.SessionId, ar.PersonId })
                .IsUnique();

            // Indexes
            Builder.HasIndex(ar => ar.CheckInTime);
        }
    }
}

