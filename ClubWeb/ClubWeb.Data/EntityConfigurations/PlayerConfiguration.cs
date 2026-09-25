using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the Player entity.
    /// </summary>
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> Builder)
        {
            Builder.ToTable("Players");

            Builder.HasKey(p => p.Id);

            Builder.Property(p => p.Id)
                .IsRequired();

            Builder.Property(p => p.PersonId)
                .IsRequired();

            Builder.Property(p => p.DateOfBirth)
                .IsRequired();

            Builder.Property(p => p.CreatedDate)
                .IsRequired();

            // Owned entity: Weight
            Builder.OwnsOne(p => p.Weight, WeightBuilder => WeightBuilder.Property(w => w.Kilograms)
                    .HasColumnName("WeightKilograms")
                    .HasPrecision(5, 2));

            // Owned entity: Rank (if Rank is a value object)
            // If Rank has its own table, use HasOne instead
            Builder.OwnsOne(p => p.Rank, RankBuilder =>
            {
                RankBuilder.Property(r => r.Value)
                    .HasColumnName("RankValue");

                RankBuilder.OwnsOne(r => r.Belt, BeltBuilder =>
                {
                    BeltBuilder.Property(b => b.PrimaryColour)
                        .HasColumnName("BeltPrimaryColour")
                        .HasConversion<int>();

                    BeltBuilder.Property(b => b.SecondaryColour)
                        .HasColumnName("BeltSecondaryColour")
                        .HasConversion<int>();
                });
            });

            // 1:1 relationship with Person
            Builder.HasOne(p => p.Person)
                .WithOne(pr => pr.Player)
                .HasForeignKey<Player>(p => p.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-one: HomeOrgUnit (current home club)
            Builder.HasOne(p => p.HomeOrgUnit)
                .WithMany()
                .HasForeignKey(p => p.HomeOrgUnitId)
                .OnDelete(DeleteBehavior.SetNull);

            // One-to-many: ClubAffiliations
            Builder.HasMany(p => p.ClubAffiliations)
                .WithOne(pca => pca.Player)
                .HasForeignKey(pca => pca.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: Gradings
            Builder.HasMany(p => p.Gradings)
                .WithOne(pg => pg.Player)
                .HasForeignKey(pg => pg.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            Builder.HasIndex(p => p.PersonId)
                .IsUnique();

            Builder.HasIndex(p => p.HomeOrgUnitId);

            Builder.HasIndex(p => p.DateOfBirth);
        }
    }
}

