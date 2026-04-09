# Multiple Database Provider Migrations

This project supports multiple database providers (SQLite and PostgreSQL) with separate migration folders for each. The system automatically uses the correct migration folder based on your `appsettings.json` configuration.

## Migration Folder Structure

```
KeycloakVirgin.Data.EF/
└── Migrations/
    ├── Sqlite/          # SQLite-specific migrations
    └── PostgreSql/      # PostgreSQL-specific migrations
```

## How It Works

The migration system automatically reads your `Database.Provider` setting from [appsettings.json](KeycloakVirgin/appsettings.json) and:

1. **Creates migrations in the correct folder** - SQLite migrations go to `Migrations/Sqlite`, PostgreSQL migrations go to `Migrations/PostgreSql`
2. **Uses separate history tables** - Each provider tracks its migrations independently:
   - SQLite: `__EFMigrationsHistory_Sqlite`
   - PostgreSQL: `__EFMigrationsHistory_PostgreSql`
3. **Applies the correct migrations at runtime** - The application automatically uses migrations matching the configured provider

## Configuration

Set your database provider in [appsettings.json](KeycloakVirgin/appsettings.json):

```json
{
  "Database": {
    "Provider": "PostgreSql",  // or "Sqlite"
    "SqliteFileName": "virgin.db",
    "Host": "localhost",
    "Port": 5432,
    "Database": "keycloak",
    "Username": "keycloak",
    "Password": "keycloak"
  }
}
```

## Usage

### Add a New Migration

The migration will automatically be created in the correct folder based on your current appsettings.json configuration:

```bash
# Navigate to the project root
cd /path/to/KeycloakVirgin

# Add migration (creates in Migrations/PostgreSql if Provider=PostgreSql)
dotnet ef migrations add MigrationName \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj \
    --context AppDbContext
```

**The migration will be created in:**
- `Migrations/Sqlite/` if `Database.Provider` is set to `Sqlite`
- `Migrations/PostgreSql/` if `Database.Provider` is set to `PostgreSql`

### Update Database

Apply migrations to your database:

```bash
dotnet ef database update \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj \
    --context AppDbContext
```

### Remove Last Migration

```bash
dotnet ef migrations remove \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj \
    --context AppDbContext
```

## Switching Between Providers

To create migrations for a different provider, simply change the `Provider` setting in [appsettings.json](KeycloakVirgin/appsettings.json):

### Example: Creating Migrations for Both Providers

```bash
# 1. Create PostgreSQL migration
# Edit appsettings.json: "Provider": "PostgreSql"
dotnet ef migrations add InitialCreate \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj

# 2. Create SQLite migration
# Edit appsettings.json: "Provider": "Sqlite"
dotnet ef migrations add InitialCreate \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj
```

## Adding a New Database Provider

The system is designed to be extensible. To add a new provider (e.g., MySQL, SQL Server):

### 1. Add to DatabaseProvider Enum

Edit [DatabaseConfig.cs](KeycloakVirgin.Common/AppSettings/DatabaseConfig.cs):

```csharp
public enum DatabaseProvider
{
    Sqlite,
    PostgreSql,
    MySql  // Add new provider
}
```

### 2. Update GetConnectionString Method

Add connection string logic in [DatabaseConfig.cs](KeycloakVirgin.Common/AppSettings/DatabaseConfig.cs):

```csharp
return Provider switch
{
    DatabaseProvider.Sqlite => $"Data Source={SqliteFileName}",
    DatabaseProvider.PostgreSql => $"Host={Host};Port={Port};...",
    DatabaseProvider.MySql => $"Server={Host};Port={Port};...",  // Add case
    _ => throw new ArgumentException($"Unsupported provider: {Provider}")
};
```

### 3. Add Switch Cases

Update these three locations (marked with comments "Add new cases here when adding new database providers"):

**a) [AppDbContextFactory.cs](KeycloakVirgin.Data.EF/Context/AppDbContextFactory.cs)**
```csharp
private static void ConfigureProvider(...)
{
    switch (provider)
    {
        case DatabaseProvider.MySql:
            optionsBuilder.UseMySql(connectionString, ...);
            break;
    }
}

private static string GetMigrationFolder(DatabaseProvider provider)
{
    return provider switch
    {
        DatabaseProvider.MySql => "Migrations/MySql",
    };
}

private static string GetMigrationHistoryTable(DatabaseProvider provider)
{
    return provider switch
    {
        DatabaseProvider.MySql => "__EFMigrationsHistory_MySql",
    };
}
```

**b) [AppDbContext.cs](KeycloakVirgin.Data.EF/Context/AppDbContext.cs)**
```csharp
private static void ConfigureProvider(...)
{
    switch (provider)
    {
        case DatabaseProvider.MySql:
            optionsBuilder.UseMySql(connectionString, ...);
            break;
    }
}

private static string GetMigrationHistoryTable(DatabaseProvider provider)
{
    return provider switch
    {
        DatabaseProvider.MySql => "__EFMigrationsHistory_MySql",
    };
}
```

**c) [ServiceExtensions.cs](KeycloakVirgin/InstallExtensions/ServiceExtensions.cs)**
```csharp
private static void ConfigureDatabaseProvider(...)
{
    switch (provider)
    {
        case DatabaseProvider.MySql:
            options.UseMySql(connectionString, ...);
            break;
    }
}

private static string GetMigrationHistoryTable(DatabaseProvider provider)
{
    return provider switch
    {
        DatabaseProvider.MySql => "__EFMigrationsHistory_MySql",
    };
}
```

### 4. Create Migration Folder

```bash
mkdir -p KeycloakVirgin.Data.EF/Migrations/MySql
```

That's it! The system will now support the new provider.

## Best Practices

1. **Keep Migrations in Sync**: When you change your entity model, create migrations for all providers you support
2. **Test Both Databases**: Always test migrations on all supported database types
3. **Version Control**: Commit all migration folders to version control
4. **Migration Names**: Use descriptive names that clearly indicate what changed

## Troubleshooting

### Wrong Migration Folder
If migrations are created in the wrong folder, check your [appsettings.json](KeycloakVirgin/appsettings.json) `Database.Provider` setting.

### Migration Not Found at Runtime
Ensure the `Database.Provider` in your runtime appsettings matches the provider for which you created migrations.

### Starting Fresh
To reset all migrations for a provider:

```bash
# 1. Delete migration files
rm -rf KeycloakVirgin.Data.EF/Migrations/PostgreSql/*

# 2. Drop/recreate the database or delete the migration history table

# 3. Create initial migration
# (Set Provider to PostgreSql in appsettings.json)
dotnet ef migrations add InitialCreate \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj
```

## Verify Migration History

### PostgreSQL
```bash
docker exec -it <postgres-container> psql -U keycloak -d keycloak \
    -c "SELECT * FROM \"__EFMigrationsHistory_PostgreSql\";"
```

### SQLite
```bash
sqlite3 KeycloakVirgin/virgin.db \
    "SELECT * FROM __EFMigrationsHistory_Sqlite;"
```
