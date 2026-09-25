using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the OrgBranding entity.
    /// </summary>
    public class OrgBrandingConfiguration : IEntityTypeConfiguration<OrgBranding>
    {
        public void Configure(EntityTypeBuilder<OrgBranding> Builder)
        {
            Builder.ToTable("OrgBrandings");

            Builder.HasKey(ob => ob.Id);

            Builder.Property(ob => ob.Id)
                .IsRequired();

            Builder.Property(ob => ob.OrgUnitId)
                .IsRequired();

            Builder.Property(ob => ob.PrimaryColour)
                .HasMaxLength(50);

            Builder.Property(ob => ob.SecondaryColour)
                .HasMaxLength(50);

            Builder.Property(ob => ob.AccentColour)
                .HasMaxLength(50);

            Builder.Property(ob => ob.BackgroundColour)
                .HasMaxLength(50);

            Builder.Property(ob => ob.TextColour)
                .HasMaxLength(50);

            Builder.Property(ob => ob.LogoUrl)
                .HasMaxLength(500);

            Builder.Property(ob => ob.CreatedDate)
                .IsRequired();

            // One-to-one: OrgUnit
            Builder.HasOne(ob => ob.OrgUnit)
                .WithOne()
                .HasForeignKey<OrgBranding>(ob => ob.OrgUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint: One branding per OrgUnit
            Builder.HasIndex(ob => ob.OrgUnitId)
                .IsUnique();
        }
    }
}

