using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the RoleAssignment entity.
    /// </summary>
    public class RoleAssignmentConfiguration : IEntityTypeConfiguration<RoleAssignment>
    {
        public void Configure(EntityTypeBuilder<RoleAssignment> Builder)
        {
            Builder.ToTable("RoleAssignments");

            Builder.HasKey(ra => ra.Id);

            Builder.Property(ra => ra.Id)
                .IsRequired();

            Builder.Property(ra => ra.PersonId)
                .IsRequired();

            Builder.Property(ra => ra.OrgUnitId)
                .IsRequired();

            Builder.Property(ra => ra.RoleName)
                .IsRequired()
                .HasConversion<int>();

            Builder.Property(ra => ra.AssignedDate)
                .IsRequired();

            // Many-to-one: Person
            Builder.HasOne(ra => ra.Person)
                .WithMany(p => p.RoleAssignments)
                .HasForeignKey(ra => ra.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-one: OrgUnit
            Builder.HasOne(ra => ra.OrgUnit)
                .WithMany()
                .HasForeignKey(ra => ra.OrgUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-one: AssignedByPerson
            Builder.HasOne(ra => ra.AssignedByPerson)
                .WithMany()
                .HasForeignKey(ra => ra.AssignedByPersonId)
                .OnDelete(DeleteBehavior.SetNull);

            // Many-to-one: RevokedByPerson
            Builder.HasOne(ra => ra.RevokedByPerson)
                .WithMany()
                .HasForeignKey(ra => ra.RevokedByPersonId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            Builder.HasIndex(ra => new { ra.PersonId, ra.OrgUnitId, ra.RoleName });

            Builder.HasIndex(ra => ra.OrgUnitId);

            Builder.HasIndex(ra => ra.AssignedDate);
        }
    }
}

