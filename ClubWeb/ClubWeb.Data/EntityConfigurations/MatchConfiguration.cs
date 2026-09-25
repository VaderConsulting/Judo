using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the Match entity.
    /// </summary>
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> Builder)
        {
            Builder.ToTable("Matches");

            Builder.HasKey(m => m.Identifier);

            Builder.Property(m => m.Identifier)
                .IsRequired();

            Builder.Property(m => m.Date)
                .IsRequired();

            Builder.Property(m => m.Result)
                .IsRequired()
                .HasConversion<int>();

            Builder.Property(m => m.State)
                .IsRequired()
                .HasConversion<int>();

            Builder.Property(m => m.Result)
                .IsRequired()
                .HasDefaultValue(false);

            Builder.Property(m => m.GoldenPoint)
                .IsRequired()
                .HasDefaultValue(false);

            // Owned entity: Player1Score
            // Score contains ObservableCollection<int> properties which EF Core doesn't support directly
            // We'll store the score data as JSON or use a workaround
            // For now, we'll ignore the Score properties and handle them via a separate approach
            // Alternatively, we can store score counts as separate integer columns
            Builder.Ignore(m => m.Player1Score);
            Builder.Ignore(m => m.Player2Score);
            
            // Add explicit score columns as integers (counts)
            Builder.Property<int>("Player1IpponCount")
                .HasDefaultValue(0);
            Builder.Property<int>("Player1WazaAriCount")
                .HasDefaultValue(0);
            Builder.Property<int>("Player1YukoCount")
                .HasDefaultValue(0);
            Builder.Property<int>("Player1HansokuMakeCount")
                .HasDefaultValue(0);
            Builder.Property<int>("Player1ShidoCount")
                .HasDefaultValue(0);
            
            Builder.Property<int>("Player2IpponCount")
                .HasDefaultValue(0);
            Builder.Property<int>("Player2WazaAriCount")
                .HasDefaultValue(0);
            Builder.Property<int>("Player2YukoCount")
                .HasDefaultValue(0);
            Builder.Property<int>("Player2HansokuMakeCount")
                .HasDefaultValue(0);
            Builder.Property<int>("Player2ShidoCount")
                .HasDefaultValue(0);

            // Owned entity: Player1Weight
            Builder.OwnsOne(m => m.Person1Weight, WeightBuilder => WeightBuilder.Property(w => w.Kilograms)
                    .HasColumnName("Player1WeightKilograms")
                    .HasPrecision(5, 2));

            // Owned entity: Player2Weight
            Builder.OwnsOne(m => m.Person2Weight, WeightBuilder => WeightBuilder.Property(w => w.Kilograms)
                    .HasColumnName("Player2WeightKilograms")
                    .HasPrecision(5, 2));

            // Owned entity: Player1Belt
            Builder.OwnsOne(m => m.Player1Belt, BeltBuilder =>
            {
                BeltBuilder.Property(b => b.PrimaryColour)
                    .HasColumnName("Player1BeltPrimaryColour")
                    .HasConversion<int>();

                BeltBuilder.Property(b => b.SecondaryColour)
                    .HasColumnName("Player1BeltSecondaryColour")
                    .HasConversion<int>();
            });

            // Owned entity: Player2Belt
            Builder.OwnsOne(m => m.Player2Belt, BeltBuilder =>
            {
                BeltBuilder.Property(b => b.PrimaryColour)
                    .HasColumnName("Player2BeltPrimaryColour")
                    .HasConversion<int>();

                BeltBuilder.Property(b => b.SecondaryColour)
                    .HasColumnName("Player2BeltSecondaryColour")
                    .HasConversion<int>();
            });

            // Many-to-one: Person1
            Builder.HasOne(m => m.Person1)
                .WithMany()
                .HasForeignKey("Person1Id")
                .OnDelete(DeleteBehavior.Restrict);

            Builder.Property<Guid?>("Person1Id");

            // Many-to-one: Person2
            Builder.HasOne(m => m.Person2)
                .WithMany()
                .HasForeignKey("Person2Id")
                .OnDelete(DeleteBehavior.Restrict);

            Builder.Property<Guid?>("Person2Id");

            // Many-to-one: Winner
            Builder.HasOne(m => m.Winner)
                .WithMany()
                .HasForeignKey("WinnerId")
                .OnDelete(DeleteBehavior.SetNull);

            Builder.Property<Guid?>("WinnerId");

            // Many-to-one: WhiteBelt
            Builder.HasOne(m => m.WhiteBelt)
                .WithMany()
                .HasForeignKey("WhiteBeltId")
                .OnDelete(DeleteBehavior.SetNull);

            Builder.Property<Guid?>("WhiteBeltId");

            // Many-to-one: BlueBelt
            Builder.HasOne(m => m.BlueBelt)
                .WithMany()
                .HasForeignKey("BlueBeltId")
                .OnDelete(DeleteBehavior.SetNull);

            Builder.Property<Guid?>("BlueBeltId");

            // Many-to-one: Division
            Builder.HasOne(m => m.Division)
                .WithMany()
                .HasForeignKey("DivisionId")
                .OnDelete(DeleteBehavior.SetNull);

            Builder.Property<Guid?>("DivisionId");

            // Many-to-one: Mat
            Builder.HasOne(m => m.Mat)
                .WithMany()
                .HasForeignKey("MatId")
                .OnDelete(DeleteBehavior.SetNull);

            Builder.Property<Guid?>("MatId");

            // One-to-many: ResultCorrectionRequests
            Builder.HasMany(m => m.ResultCorrectionRequests)
                .WithOne(rcr => rcr.Match)
                .HasForeignKey(rcr => rcr.MatchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            Builder.HasIndex(m => m.Date);

            Builder.HasIndex(m => m.Result);

            Builder.HasIndex(m => m.State);
        }
    }
}

