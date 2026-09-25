using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the PlayerGrading entity.
    /// </summary>
    public class PlayerGradingConfiguration : IEntityTypeConfiguration<PlayerGrading>
    {
        public void Configure(EntityTypeBuilder<PlayerGrading> Builder)
        {
            Builder.ToTable("PlayerGradings");

            Builder.HasKey(pg => pg.Id);

            Builder.Property(pg => pg.Id)
                .IsRequired();

            Builder.Property(pg => pg.PlayerId)
                .IsRequired();

            Builder.Property(pg => pg.AwardedDate)
                .IsRequired();

            Builder.Property(pg => pg.GradingType)
                .IsRequired()
                .HasConversion<int>();

            Builder.Property(pg => pg.Notes)
                .HasMaxLength(1000);

            Builder.Property(pg => pg.CreatedDate)
                .IsRequired();

            // Owned entity: AwardedRank
            Builder.OwnsOne(pg => pg.AwardedRank, RankBuilder =>
            {
                RankBuilder.Property(r => r.Value)
                    .HasColumnName("AwardedRankValue");

                RankBuilder.OwnsOne(r => r.Belt, BeltBuilder =>
                {
                    BeltBuilder.Property(b => b.PrimaryColour)
                        .HasColumnName("AwardedBeltPrimaryColour")
                        .HasConversion<int>();

                    BeltBuilder.Property(b => b.SecondaryColour)
                        .HasColumnName("AwardedBeltSecondaryColour")
                        .HasConversion<int>();
                });
            });

            // Many-to-one: Player
            Builder.HasOne(pg => pg.Player)
                .WithMany(p => p.Gradings)
                .HasForeignKey(pg => pg.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-one: AwardedByOrgUnit
            Builder.HasOne(pg => pg.AwardedByOrgUnit)
                .WithMany()
                .HasForeignKey(pg => pg.AwardedByOrgUnitId)
                .OnDelete(DeleteBehavior.SetNull);

            // Many-to-one: AwardedByPerson
            Builder.HasOne(pg => pg.AwardedByPerson)
                .WithMany()
                .HasForeignKey(pg => pg.AwardedByPersonId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            Builder.HasIndex(pg => pg.PlayerId);

            Builder.HasIndex(pg => pg.AwardedDate);

            Builder.HasIndex(pg => pg.GradingType);
        }
    }
}

