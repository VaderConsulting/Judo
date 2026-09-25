using Microsoft.EntityFrameworkCore;
using Classes;

namespace ClubWeb.Data
{
    /// <summary>
    /// Entity Framework Core database context for the Judo club management application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {
        }

        #region DbSets

        public DbSet<Person> Persons { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<OrgUnit> OrgUnits { get; set; }
        public DbSet<OrgMoveRequest> OrgMoveRequests { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }
        public DbSet<PersonMembership> PersonMemberships { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<ResultCorrectionRequest> ResultCorrectionRequests { get; set; }
        public DbSet<PlayerGrading> PlayerGradings { get; set; }
        public DbSet<PlayerClubAffiliation> PlayerClubAffiliations { get; set; }
        public DbSet<OrgBranding> OrgBrandings { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);

            // Apply all entity configurations
            ModelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

