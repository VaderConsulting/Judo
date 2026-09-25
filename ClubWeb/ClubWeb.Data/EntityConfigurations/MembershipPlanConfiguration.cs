using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the MembershipPlan entity.
    /// </summary>
    public class MembershipPlanConfiguration : IEntityTypeConfiguration<MembershipPlan>
    {
        public void Configure(EntityTypeBuilder<MembershipPlan> Builder)
        {
            Builder.ToTable("MembershipPlans");

            Builder.HasKey(mp => mp.Id);

            Builder.Property(mp => mp.Id)
                .IsRequired();

            Builder.Property(mp => mp.OrgUnitId)
                .IsRequired();

            Builder.Property(mp => mp.Name)
                .IsRequired()
                .HasMaxLength(200);

            Builder.Property(mp => mp.Description)
                .HasMaxLength(1000);

            Builder.Property(mp => mp.Price)
                .IsRequired()
                .HasPrecision(10, 2);

            Builder.Property(mp => mp.BillingPeriod)
                .IsRequired()
                .HasMaxLength(50);

            Builder.Property(mp => mp.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            Builder.Property(mp => mp.CreatedDate)
                .IsRequired();

            // Many-to-one: OrgUnit
            Builder.HasOne(mp => mp.OrgUnit)
                .WithMany()
                .HasForeignKey(mp => mp.OrgUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: PersonMemberships
            Builder.HasMany(mp => mp.PersonMemberships)
                .WithOne(pm => pm.MembershipPlan)
                .HasForeignKey(pm => pm.MembershipPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            Builder.HasIndex(mp => mp.OrgUnitId);

            Builder.HasIndex(mp => mp.IsActive);
        }
    }
}

