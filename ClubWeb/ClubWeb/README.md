# ClubWeb - Blazor Server Application

This is the main Blazor Server application for the Judo club management system.

## Project Structure

- **Program.cs** - Application entry point with DI container setup
- **App.razor** - Root component
- **Pages/** - Razor pages and components
- **Shared/** - Shared components (MainLayout, NavMenu)
- **wwwroot/** - Static files (CSS, JS)

## Setup Instructions

### 1. Database Connection

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ClubWebDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 2. Create Database Migration

From the `ClubWeb` project directory:

```bash
dotnet ef migrations add InitialCreate --project ..\ClubWeb.Data\ClubWeb.Data.csproj
```

### 3. Update Database

```bash
dotnet ef database update --project ..\ClubWeb.Data\ClubWeb.Data.csproj
```

### 4. Run the Application

```bash
dotnet run
```

Or press F5 in Visual Studio.

## Dependencies

- .NET 10.0
- Blazor Server
- Entity Framework Core (via ClubWeb.Data project)

## Next Steps

1. Add authentication/authorization
2. Create pages for:
   - Organization tree management
   - Player management
   - Session management
   - Attendance tracking
   - Role management

