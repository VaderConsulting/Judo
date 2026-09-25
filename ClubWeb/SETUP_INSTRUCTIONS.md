# ClubWeb Setup Instructions

## Prerequisites

- .NET 10.0 SDK installed
- SQL Server (LocalDB, SQL Server Express, or full SQL Server)
- Visual Studio 2022 or VS Code (optional)

## Project Structure

```
ClubWeb/
├── ClubWeb/                    # Blazor Server application
│   ├── Program.cs             # DI container setup
│   ├── appsettings.json       # Configuration (connection string)
│   ├── Pages/                 # Razor pages
│   ├── Shared/                # Shared components
│   └── wwwroot/               # Static files
├── ClubWeb.Data/              # EF Core data layer
│   ├── ApplicationDbContext.cs
│   └── EntityConfigurations/  # Entity configurations
└── ClubWeb.sln                # Solution file
```

## Step-by-Step Setup

### 1. Update Connection String

Edit `ClubWeb/appsettings.json` and update the connection string to match your SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ClubWebDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

**Common connection string examples:**

- **LocalDB**: `Server=(localdb)\\mssqllocaldb;Database=ClubWebDb;Trusted_Connection=True;MultipleActiveResultSets=true`
- **SQL Server Express**: `Server=.\\SQLEXPRESS;Database=ClubWebDb;Trusted_Connection=True;MultipleActiveResultSets=true`
- **Full SQL Server**: `Server=localhost;Database=ClubWebDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True`

### 2. Restore NuGet Packages

Open a terminal in the `ClubWeb` directory and run:

```bash
dotnet restore
```

### 3. Create Database Migration

From the `ClubWeb/ClubWeb` directory:

```bash
dotnet ef migrations add InitialCreate --project ..\ClubWeb.Data\ClubWeb.Data.csproj --startup-project .
```

This will create a `Migrations` folder in the `ClubWeb.Data` project.

### 4. Create the Database

Apply the migration to create the database:

```bash
dotnet ef database update --project ..\ClubWeb.Data\ClubWeb.Data.csproj --startup-project .
```

### 5. Run the Application

```bash
dotnet run --project ClubWeb
```

Or open the solution in Visual Studio and press F5.

The application will be available at:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`

## Troubleshooting

### Migration Errors

If you get errors about missing EF Core tools:

```bash
dotnet tool install --global dotnet-ef
```

### Connection String Issues

- Ensure SQL Server is running
- Check that the database name doesn't already exist (or change it)
- Verify your connection string syntax

### Build Errors

- Ensure all projects reference the Classes project correctly
- Check that .NET 10.0 SDK is installed: `dotnet --version`
- Restore packages: `dotnet restore`

## Next Steps

After the application is running:

1. **Add Authentication** - Implement user authentication and authorization
2. **Create Pages** - Build pages for:
   - Organization tree management
   - Player management
   - Session creation and attendance
   - Role management
3. **Add Services** - Create service layer for business logic
4. **Seed Data** - Add initial data (org units, roles, etc.)

## Development Notes

- The application uses **Blazor Server** (SignalR-based)
- Entity Framework Core is configured with **SQL Server**
- All entity configurations are in `ClubWeb.Data/EntityConfigurations/`
- The domain classes are in the `Classes` project

