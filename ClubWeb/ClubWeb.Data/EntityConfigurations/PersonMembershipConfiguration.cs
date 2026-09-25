using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the PersonMembership entity.
    /// </summary>
    public class PersonMembershipConfiguration : IEntityTypeConfiguration<PersonMembership>
    {
        public void Configure(EntityTypeBuilder<PersonMembership> Builder)
        {
            Builder.ToTable("PersonMemberships");

            Builder.HasKey(pm => pm.Id);

            Builder.Property(pm => pm.Id)
                .IsRequired();

            Builder.Property(pm => pm.PersonId)
                .IsRequired();

            Builder.Property(pm => pm.MembershipPlanId)
                .IsRequired();

            Builder.Property(pm => pm.StartDate)
                .IsRequired();

            Builder.Property(pm => pm.CreatedDate)
                .IsRequired();

            // Many-to-one: Person
            Builder.HasOne(pm => pm.Person)
                .WithMany(p => p.PersonMemberships)
                .HasForeignKey(pm => pm.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-one: MembershipPlan
            Builder.HasOne(pm => pm.MembershipPlan)
                .WithMany(mp => mp.PersonMemberships)
                .HasForeignKey(pm => pm.MembershipPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            Builder.HasIndex(pm => pm.PersonId);

            Builder.HasIndex(pm => pm.MembershipPlanId);

            Builder.HasIndex(pm => new { pm.PersonId, pm.EndDate })
                .HasFilter("[EndDate] IS NULL");
        }
    }
}

