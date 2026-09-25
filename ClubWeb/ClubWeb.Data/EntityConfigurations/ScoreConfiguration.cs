using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classes;

namespace ClubWeb.Data.EntityConfigurations
{
    /// <summary>
    /// Entity Framework Core configuration for the Score entity.
    /// Score contains collections, so we'll store it as a separate table or use JSON.
    /// For EF Core, we'll create a separate Score table with a one-to-many relationship for score items.
    /// </summary>
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> Builder)
        {
            Builder.ToTable("Scores");

            // Since Score is used as an owned entity in Match, we need to handle it differently
            // We'll store the collections as JSON strings or create separate score item tables
            // For now, we'll use a simpler approach: store counts as integers
            
            // Note: Score is typically used as an owned entity in Match
            // This configuration is for when Score needs to be a separate entity
        }
    }
}

