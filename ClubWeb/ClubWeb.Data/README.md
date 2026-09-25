# ClubWeb.Data

This project contains the Entity Framework Core data access layer for the Judo club management web application.

## Project Structure

- **ApplicationDbContext.cs** - Main EF Core database context
- **EntityConfigurations/** - Fluent API configurations for all entities

## Dependencies

- .NET 10.0
- Microsoft.EntityFrameworkCore (10.0.0)
- Microsoft.EntityFrameworkCore.SqlServer (10.0.0)
- Microsoft.EntityFrameworkCore.Design (10.0.0)
- Classes project (domain entities)

## Entity Configurations

All entity configurations are located in the `EntityConfigurations` folder:

1. **PersonConfiguration** - Configures Person entity with owned types (Name, Address, EmailAddress, PhoneNumber)
2. **PlayerConfiguration** - Configures Player entity with owned types (Weight, Rank/Belt)
3. **OrgUnitConfiguration** - Configures organizational hierarchy
4. **RoleAssignmentConfiguration** - Configures role assignments
5. **SessionConfiguration** - Configures sessions
6. **AttendanceRecordConfiguration** - Configures attendance tracking
7. **PlayerClubAffiliationConfiguration** - Configures club affiliation history
8. **OrgBrandingConfiguration** - Configures branding settings
9. **OrgMoveRequestConfiguration** - Configures org move requests
10. **MembershipPlanConfiguration** - Configures membership plans
11. **PersonMembershipConfiguration** - Configures person memberships
12. **ResultCorrectionRequestConfiguration** - Configures result correction requests
13. **PlayerGradingConfiguration** - Configures grading history

## Usage

To use this DbContext in your application, register it in your DI container:

```csharp
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
```

## Database Migrations

To create migrations:

```bash
dotnet ef migrations add InitialCreate --project ClubWeb.Data --startup-project <YourStartupProject>
```

To apply migrations:

```bash
dotnet ef database update --project ClubWeb.Data --startup-project <YourStartupProject>
```

