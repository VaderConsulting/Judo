using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the ResultCorrectionRequest entity.
    /// </summary>
    public class ResultCorrectionRequestConfiguration : IEntityTypeConfiguration<ResultCorrectionRequest>
    {
        public void Configure(EntityTypeBuilder<ResultCorrectionRequest> Builder)
        {
            Builder.ToTable("ResultCorrectionRequests");

            Builder.HasKey(rcr => rcr.Id);

            Builder.Property(rcr => rcr.Id)
                .IsRequired();

            Builder.Property(rcr => rcr.MatchId)
                .IsRequired();

            Builder.Property(rcr => rcr.RequestedByPersonId)
                .IsRequired();

            Builder.Property(rcr => rcr.Reason)
                .HasMaxLength(1000);

            Builder.Property(rcr => rcr.RequestedChanges)
                .HasMaxLength(2000);

            Builder.Property(rcr => rcr.Status)
                .IsRequired()
                .HasConversion<int>();

            Builder.Property(rcr => rcr.RequestedDate)
                .IsRequired();

            Builder.Property(rcr => rcr.ReviewNotes)
                .HasMaxLength(1000);

            // Many-to-one: Match
            Builder.HasOne(rcr => rcr.Match)
                .WithMany(m => m.ResultCorrectionRequests)
                .HasForeignKey(rcr => rcr.MatchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-one: RequestedByPerson
            Builder.HasOne(rcr => rcr.RequestedByPerson)
                .WithMany(p => p.ResultCorrectionRequests)
                .HasForeignKey(rcr => rcr.RequestedByPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-one: ReviewedByPerson
            Builder.HasOne(rcr => rcr.ReviewedByPerson)
                .WithMany()
                .HasForeignKey(rcr => rcr.ReviewedByPersonId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            Builder.HasIndex(rcr => rcr.MatchId);

            Builder.HasIndex(rcr => rcr.RequestedByPersonId);

            Builder.HasIndex(rcr => rcr.Status);

            Builder.HasIndex(rcr => rcr.RequestedDate);
        }
    }
}

