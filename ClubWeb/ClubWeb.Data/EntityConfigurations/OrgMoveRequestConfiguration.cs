using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the OrgMoveRequest entity.
    /// </summary>
    public class OrgMoveRequestConfiguration : IEntityTypeConfiguration<OrgMoveRequest>
    {
        public void Configure(EntityTypeBuilder<OrgMoveRequest> Builder)
        {
            Builder.ToTable("OrgMoveRequests");

            Builder.HasKey(omr => omr.Id);

            Builder.Property(omr => omr.Id)
                .IsRequired();

            Builder.Property(omr => omr.OrgUnitId)
                .IsRequired();

            Builder.Property(omr => omr.RequestedParentOrgUnitId)
                .IsRequired();

            Builder.Property(omr => omr.RequestedByPersonId)
                .IsRequired();

            Builder.Property(omr => omr.Status)
                .IsRequired()
                .HasConversion<int>();

            Builder.Property(omr => omr.RequestedDate)
                .IsRequired();

            Builder.Property(omr => omr.ReviewNotes)
                .HasMaxLength(1000);

            // Many-to-one: OrgUnit
            Builder.HasOne(omr => omr.OrgUnit)
                .WithMany()
                .HasForeignKey(omr => omr.OrgUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-one: RequestedParentOrgUnit
            Builder.HasOne(omr => omr.RequestedParentOrgUnit)
                .WithMany()
                .HasForeignKey(omr => omr.RequestedParentOrgUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-one: RequestedByPerson
            Builder.HasOne(omr => omr.RequestedByPerson)
                .WithMany()
                .HasForeignKey(omr => omr.RequestedByPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-one: ReviewedByPerson
            Builder.HasOne(omr => omr.ReviewedByPerson)
                .WithMany()
                .HasForeignKey(omr => omr.ReviewedByPersonId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            Builder.HasIndex(omr => omr.OrgUnitId);

            Builder.HasIndex(omr => omr.RequestedParentOrgUnitId);

            Builder.HasIndex(omr => omr.Status);

            Builder.HasIndex(omr => omr.RequestedDate);
        }
    }
}

