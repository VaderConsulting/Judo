using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the PlayerClubAffiliation entity.
    /// </summary>
    public class PlayerClubAffiliationConfiguration : IEntityTypeConfiguration<PlayerClubAffiliation>
    {
        public void Configure(EntityTypeBuilder<PlayerClubAffiliation> Builder)
        {
            Builder.ToTable("PlayerClubAffiliations");

            Builder.HasKey(pca => pca.Id);

            Builder.Property(pca => pca.Id)
                .IsRequired();

            Builder.Property(pca => pca.PlayerId)
                .IsRequired();

            Builder.Property(pca => pca.OrgUnitId)
                .IsRequired();

            Builder.Property(pca => pca.StartDate)
                .IsRequired();

            Builder.Property(pca => pca.CreatedDate)
                .IsRequired();

            // Many-to-one: Player
            Builder.HasOne(pca => pca.Player)
                .WithMany(p => p.ClubAffiliations)
                .HasForeignKey(pca => pca.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-one: OrgUnit (Club)
            Builder.HasOne(pca => pca.OrgUnit)
                .WithMany()
                .HasForeignKey(pca => pca.OrgUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            Builder.HasIndex(pca => pca.PlayerId);

            Builder.HasIndex(pca => pca.OrgUnitId);

            Builder.HasIndex(pca => new { pca.PlayerId, pca.EndDate })
                .HasFilter("[EndDate] IS NULL");
        }
    }
}

