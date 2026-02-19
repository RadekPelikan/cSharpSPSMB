# Quick Start Guide

## Creating Your First Migration

### For PostgreSQL (Current Configuration)

Your [appsettings.json](KeycloakVirgin/appsettings.json) is currently set to PostgreSQL. To create a migration:

```bash
cd /path/to/KeycloakVirgin

# Add a new migration
dotnet ef migrations add AddUserTable \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj

# The migration will be created in: KeycloakVirgin.Data.EF/Migrations/PostgreSql/

# Apply the migration
dotnet ef database update \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj
```

### For SQLite

To create migrations for SQLite, first update [appsettings.json](KeycloakVirgin/appsettings.json):

```json
{
  "Database": {
    "Provider": "Sqlite",
    "SqliteFileName": "virgin.db"
  }
}
```

Then:

```bash
# Add a new migration
dotnet ef migrations add AddUserTable \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj

# The migration will be created in: KeycloakVirgin.Data.EF/Migrations/Sqlite/

# Apply the migration
dotnet ef database update \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj
```

## Example Workflow

### Supporting Both Databases

```bash
# 1. Create entity changes
# Edit your entities in KeycloakVirgin.Common/Entity/

# 2. Create PostgreSQL migration
# Set "Provider": "PostgreSql" in appsettings.json
dotnet ef migrations add AddNewFeature \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj

# 3. Create SQLite migration
# Set "Provider": "Sqlite" in appsettings.json
dotnet ef migrations add AddNewFeature \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj

# 4. Test PostgreSQL
# Set "Provider": "PostgreSql" in appsettings.json
dotnet ef database update \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj
dotnet run --project KeycloakVirgin/KeycloakVirgin.csproj

# 5. Test SQLite
# Set "Provider": "Sqlite" in appsettings.json
dotnet ef database update \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj
dotnet run --project KeycloakVirgin/KeycloakVirgin.csproj
```

## Common Commands

### List all migrations
```bash
dotnet ef migrations list \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj
```

### Generate SQL script
```bash
dotnet ef migrations script \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj \
    --output migration.sql
```

### Remove last migration
```bash
dotnet ef migrations remove \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj
```

### Update to specific migration
```bash
dotnet ef database update MigrationName \
    --project KeycloakVirgin.Data.EF/KeycloakVirgin.Data.EF.csproj \
    --startup-project KeycloakVirgin/KeycloakVirgin.csproj
```

## Tips

- **Always check appsettings.json** before running migration commands
- **Use descriptive migration names** like `AddUserTable` or `UpdateProductSchema`
- **Test migrations on both databases** if you support multiple providers
- **Commit migrations to version control** along with your entity changes

For more details, see [README-Migrations.md](README-Migrations.md).
