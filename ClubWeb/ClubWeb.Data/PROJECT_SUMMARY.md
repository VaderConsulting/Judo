# ClubWeb.Data Project Summary

## Project Structure

```
ClubWeb.Data/
├── ClubWeb.Data.csproj          # Project file with EF Core dependencies
├── ApplicationDbContext.cs      # Main DbContext
├── README.md                     # Project documentation
├── PROJECT_SUMMARY.md           # This file
└── EntityConfigurations/
    ├── PersonConfiguration.cs
    ├── PlayerConfiguration.cs
    ├── OrgUnitConfiguration.cs
    ├── RoleAssignmentConfiguration.cs
    ├── SessionConfiguration.cs
    ├── AttendanceRecordConfiguration.cs
    ├── PlayerClubAffiliationConfiguration.cs
    ├── OrgBrandingConfiguration.cs
    ├── OrgMoveRequestConfiguration.cs
    ├── MembershipPlanConfiguration.cs
    ├── PersonMembershipConfiguration.cs
    ├── ResultCorrectionRequestConfiguration.cs
    ├── PlayerGradingConfiguration.cs
    ├── MatchConfiguration.cs
    └── ScoreConfiguration.cs
```

## Entity Configurations Created

### Core Entities
1. **PersonConfiguration** - Person entity with owned types (Name, Address, EmailAddress, PhoneNumber)
2. **PlayerConfiguration** - Player entity with owned types (Weight, Rank/Belt), 1:1 with Person
3. **OrgUnitConfiguration** - Organizational hierarchy with self-referential parent-child relationships

### Role & Access Control
4. **RoleAssignmentConfiguration** - Role assignments (Role, OrgUnit pairs)

### Sessions & Attendance
5. **SessionConfiguration** - Generic sessions (training, grading, etc.)
6. **AttendanceRecordConfiguration** - Attendance tracking with unique constraint (SessionId, PersonId)

### Membership & Billing
7. **MembershipPlanConfiguration** - Membership plans per club
8. **PersonMembershipConfiguration** - Person-to-membership relationships

### Club Affiliation
9. **PlayerClubAffiliationConfiguration** - Club affiliation history with filtered index for active affiliations

### Results & Corrections
10. **MatchConfiguration** - Match entity with score handling (Score stored as integer counts)
11. **ResultCorrectionRequestConfiguration** - Match result correction requests

### Grading
12. **PlayerGradingConfiguration** - Player grading history

### Organizational Management
13. **OrgMoveRequestConfiguration** - Organizational unit move requests
14. **OrgBrandingConfiguration** - Branding settings with field-by-field inheritance

### Supporting
15. **ScoreConfiguration** - Score entity (placeholder, Score handled in MatchConfiguration)

## Key Features

### Owned Entity Types
- **Name** - FirstName, LastName columns
- **Address** - Full address structure (StreetAddress, PostalAddress)
- **EmailAddress** - Mailbox, Domain
- **PhoneNumber** - CountryCode, AreaCode, Number
- **Weight** - Kilograms with precision
- **Rank/Belt** - PrimaryColour, SecondaryColour (enum conversions)

### Relationships Configured
- **1:1** - Person ↔ Player
- **1:Many** - All parent-child relationships
- **Many:Many** - Person Parents/Siblings (self-referential via join tables)
- **Self-Referential** - OrgUnit parent-child hierarchy

### Indexes
- Foreign key indexes for performance
- Unique constraints (AttendanceRecord, OrgBranding)
- Filtered indexes (PlayerClubAffiliation for active records)
- Date-based indexes for queries

### Delete Behaviors
- **Cascade** - Child entities (RoleAssignments, AttendanceRecords, etc.)
- **Restrict** - Critical relationships (OrgUnit hierarchy, Match relationships)
- **SetNull** - Optional relationships (President, HeadCoach, etc.)

## Special Handling

### Score Entity
The `Score` class contains `ObservableCollection<int>` properties which EF Core cannot map directly. The `MatchConfiguration` handles this by:
- Ignoring the Score navigation properties
- Adding explicit integer columns for score counts:
  - Player1IpponCount, Player1WazaAriCount, Player1YukoCount, etc.
  - Player2IpponCount, Player2WazaAriCount, Player2YukoCount, etc.

**Note**: You may need to add mapping logic in your application layer to convert between Score objects and these integer columns.

## Database Migration Notes

When creating migrations:
1. All entities use `Guid` as primary keys
2. Enum types are stored as integers with conversions
3. Owned entities are stored in the same table as their parent
4. Many-to-many relationships use join tables
5. String properties have appropriate max lengths
6. Decimal/float properties have precision specified

## Next Steps

1. **Register DbContext** in your Blazor app's DI container
2. **Create Initial Migration**: `dotnet ef migrations add InitialCreate`
3. **Update Database**: `dotnet ef database update`
4. **Add Score Mapping Logic** - Create extension methods or services to map Score objects to/from integer columns
5. **Add Seed Data** - Create initial data for OrgUnits, Roles, etc.

## Dependencies

- .NET 10.0
- Microsoft.EntityFrameworkCore (10.0.0)
- Microsoft.EntityFrameworkCore.SqlServer (10.0.0)
- Microsoft.EntityFrameworkCore.Design (10.0.0)
- Classes project (domain entities)

