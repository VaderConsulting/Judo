using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the Person entity.
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> Builder)
        {
            Builder.ToTable("Persons");

            Builder.HasKey(p => p.Id);

            Builder.Property(p => p.Id)
                .IsRequired();

            Builder.Property(p => p.Sex)
                .IsRequired()
                .HasConversion<int>();

            Builder.Property(p => p.SpecialNeeds)
                .IsRequired()
                .HasDefaultValue(false);

            Builder.Property(p => p.CreatedDate)
                .IsRequired();

            // Owned entity: Name
            Builder.OwnsOne(p => p.Name, NameBuilder =>
            {
                NameBuilder.Property(n => n.First)
                    .HasColumnName("FirstName")
                    .HasMaxLength(100);

                NameBuilder.Property(n => n.Last)
                    .HasColumnName("LastName")
                    .HasMaxLength(100);
            });

            // Owned entity: Address
            Builder.OwnsOne(p => p.Address, AddressBuilder =>
            {
                AddressBuilder.Property(a => a.StreetNumber)
                    .HasColumnName("StreetNumber")
                    .HasMaxLength(20);

                AddressBuilder.Property(a => a.StreetName1)
                    .HasColumnName("StreetName1")
                    .HasMaxLength(200);

                AddressBuilder.Property(a => a.StreetName2)
                    .HasColumnName("StreetName2")
                    .HasMaxLength(200);

                AddressBuilder.Property(a => a.BuildingName)
                    .HasColumnName("BuildingName")
                    .HasMaxLength(200);

                AddressBuilder.Property(a => a.ApartmentNumber)
                    .HasColumnName("ApartmentNumber")
                    .HasMaxLength(20);

                AddressBuilder.Property(a => a.Locality)
                    .HasColumnName("Locality")
                    .HasMaxLength(100);

                AddressBuilder.Property(a => a.State)
                    .HasColumnName("State")
                    .HasMaxLength(100);

                AddressBuilder.Property(a => a.PostCode)
                    .HasColumnName("PostCode")
                    .HasMaxLength(20);

                AddressBuilder.Property(a => a.Country)
                    .HasColumnName("Country")
                    .HasMaxLength(100);

                AddressBuilder.Property(a => a.Latitude)
                    .HasColumnName("Latitude")
                    .HasMaxLength(50);

                AddressBuilder.Property(a => a.Longitude)
                    .HasColumnName("Longitude")
                    .HasMaxLength(50);
            });

            // Owned entity: EmailAddress
            Builder.OwnsOne(p => p.EmailAddress, EmailBuilder =>
            {
                EmailBuilder.Property(e => e.Mailbox)
                    .HasColumnName("EmailMailbox")
                    .HasMaxLength(200);

                EmailBuilder.Property(e => e.Domain)
                    .HasColumnName("EmailDomain")
                    .HasMaxLength(200);
            });

            // Owned entity: PhoneNumber
            Builder.OwnsOne(p => p.PhoneNumber, PhoneBuilder =>
            {
                PhoneBuilder.Property(ph => ph.CountryCode)
                    .HasColumnName("PhoneCountryCode")
                    .HasMaxLength(10);

                PhoneBuilder.Property(ph => ph.AreaCode)
                    .HasColumnName("PhoneAreaCode")
                    .HasMaxLength(10);

                PhoneBuilder.Property(ph => ph.Number)
                    .HasColumnName("PhoneNumber")
                    .HasMaxLength(20);
            });

            // 1:1 relationship with Player
            Builder.HasOne(p => p.Player)
                .WithOne(pl => pl.Person)
                .HasForeignKey<Player>(pl => pl.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-many: Parents (self-referential)
            Builder.HasMany(p => p.Parents)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "PersonParent",
                    j => j.HasOne<Person>().WithMany().HasForeignKey("ParentId"),
                    j => j.HasOne<Person>().WithMany().HasForeignKey("ChildId"),
                    j =>
                    {
                        j.HasKey("ParentId", "ChildId");
                        j.ToTable("PersonParents");
                    });

            // Many-to-many: Siblings (self-referential)
            Builder.HasMany(p => p.Siblings)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "PersonSibling",
                    j => j.HasOne<Person>().WithMany().HasForeignKey("SiblingId"),
                    j => j.HasOne<Person>().WithMany().HasForeignKey("PersonId"),
                    j =>
                    {
                        j.HasKey("PersonId", "SiblingId");
                        j.ToTable("PersonSiblings");
                    });

            // One-to-many: RoleAssignments
            Builder.HasMany(p => p.RoleAssignments)
                .WithOne(ra => ra.Person)
                .HasForeignKey(ra => ra.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: AttendanceRecords
            Builder.HasMany(p => p.AttendanceRecords)
                .WithOne(ar => ar.Person)
                .HasForeignKey(ar => ar.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: PersonMemberships
            Builder.HasMany(p => p.PersonMemberships)
                .WithOne(pm => pm.Person)
                .HasForeignKey(pm => pm.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: ResultCorrectionRequests
            Builder.HasMany(p => p.ResultCorrectionRequests)
                .WithOne(rcr => rcr.RequestedByPerson)
                .HasForeignKey(rcr => rcr.RequestedByPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            Builder.HasIndex(p => p.CreatedDate);
        }
    }
}

