using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the OrgUnit entity.
    /// </summary>
    public class OrgUnitConfiguration : IEntityTypeConfiguration<OrgUnit>
    {
        public void Configure(EntityTypeBuilder<OrgUnit> Builder)
        {
            Builder.ToTable("OrgUnits");

            Builder.HasKey(o => o.Id);

            Builder.Property(o => o.Id)
                .IsRequired();

            Builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(200);

            Builder.Property(o => o.OrgType)
                .IsRequired()
                .HasConversion<int>();

            Builder.Property(o => o.CreatedDate)
                .IsRequired();

            // Self-referential: Parent-Child relationship
            Builder.HasOne(o => o.ParentOrgUnit)
                .WithMany(o => o.ChildOrgUnits)
                .HasForeignKey(o => o.ParentOrgUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Owned entity: StreetAddress
            Builder.OwnsOne(o => o.StreetAddress, AddressBuilder =>
            {
                AddressBuilder.Property(a => a.StreetNumber)
                    .HasColumnName("StreetAddress_StreetNumber")
                    .HasMaxLength(20);

                AddressBuilder.Property(a => a.StreetName1)
                    .HasColumnName("StreetAddress_StreetName1")
                    .HasMaxLength(200);

                AddressBuilder.Property(a => a.StreetName2)
                    .HasColumnName("StreetAddress_StreetName2")
                    .HasMaxLength(200);

                AddressBuilder.Property(a => a.BuildingName)
                    .HasColumnName("StreetAddress_BuildingName")
                    .HasMaxLength(200);

                AddressBuilder.Property(a => a.ApartmentNumber)
                    .HasColumnName("StreetAddress_ApartmentNumber")
                    .HasMaxLength(20);

                AddressBuilder.Property(a => a.Locality)
                    .HasColumnName("StreetAddress_Locality")
                    .HasMaxLength(100);

                AddressBuilder.Property(a => a.State)
                    .HasColumnName("StreetAddress_State")
                    .HasMaxLength(100);

                AddressBuilder.Property(a => a.PostCode)
                    .HasColumnName("StreetAddress_PostCode")
                    .HasMaxLength(20);

                AddressBuilder.Property(a => a.Country)
                    .HasColumnName("StreetAddress_Country")
                    .HasMaxLength(100);
            });

            // Owned entity: PostalAddress
            Builder.OwnsOne(o => o.PostalAddress, AddressBuilder =>
            {
                AddressBuilder.Property(a => a.StreetNumber)
                    .HasColumnName("PostalAddress_StreetNumber")
                    .HasMaxLength(20);

                AddressBuilder.Property(a => a.StreetName1)
                    .HasColumnName("PostalAddress_StreetName1")
                    .HasMaxLength(200);

                AddressBuilder.Property(a => a.StreetName2)
                    .HasColumnName("PostalAddress_StreetName2")
                    .HasMaxLength(200);

                AddressBuilder.Property(a => a.BuildingName)
                    .HasColumnName("PostalAddress_BuildingName")
                    .HasMaxLength(200);

                AddressBuilder.Property(a => a.ApartmentNumber)
                    .HasColumnName("PostalAddress_ApartmentNumber")
                    .HasMaxLength(20);

                AddressBuilder.Property(a => a.Locality)
                    .HasColumnName("PostalAddress_Locality")
                    .HasMaxLength(100);

                AddressBuilder.Property(a => a.State)
                    .HasColumnName("PostalAddress_State")
                    .HasMaxLength(100);

                AddressBuilder.Property(a => a.PostCode)
                    .HasColumnName("PostalAddress_PostCode")
                    .HasMaxLength(20);

                AddressBuilder.Property(a => a.Country)
                    .HasColumnName("PostalAddress_Country")
                    .HasMaxLength(100);
            });

            // Many-to-one: President
            Builder.HasOne(o => o.President)
                .WithMany()
                .HasForeignKey(o => o.PresidentId)
                .OnDelete(DeleteBehavior.SetNull);

            // Many-to-one: HeadCoach
            Builder.HasOne(o => o.HeadCoach)
                .WithMany()
                .HasForeignKey(o => o.HeadCoachId)
                .OnDelete(DeleteBehavior.SetNull);

            // Owned entity: EmailAddress
            Builder.OwnsOne(o => o.EmailAddress, EmailBuilder =>
            {
                EmailBuilder.Property(e => e.Mailbox)
                    .HasColumnName("EmailMailbox")
                    .HasMaxLength(200);

                EmailBuilder.Property(e => e.Domain)
                    .HasColumnName("EmailDomain")
                    .HasMaxLength(200);
            });

            // Owned entity: PhoneNumber
            Builder.OwnsOne(o => o.PhoneNumber, PhoneBuilder =>
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

            // Indexes
            Builder.HasIndex(o => o.ParentOrgUnitId);

            Builder.HasIndex(o => o.OrgType);

            Builder.HasIndex(o => o.Name);
        }
    }
}

