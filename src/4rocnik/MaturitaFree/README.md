# MaturitaFree

A Windows Forms application backed by Entity Framework Core with SQLite, structured in three projects.

---

## Project Structure

```
MaturitaFree/
├── MaturitaFree.App/          # WinForms application — entry point, DI wiring
├── MaturitaFree.Common/       # Domain entities, repository interfaces
└── MaturitaFree.Data.EF/      # EF Core DbContext, configurations, repositories
```

### MaturitaFree.Common
- **`Entities/BaseEntity.cs`** — abstract base with `Id`, `DateCreated`, `DateModified?`, `DateDeleted?`, `IsDeleted`
- **`Entities/BookEntity.cs`** — `BookEntity`, `PersonEntity`, `PersonWorkingOnBook`, `BookChapterEntity`, `BookParagraphEntity`
- **`Repositories/`** — `IRepository<T>` plus entity-specific interfaces (`IBookRepository`, `IPersonRepository`, etc.)

### MaturitaFree.Data.EF
- **`Context/AppDbContext.cs`** — EF Core `DbContext`; auto-applies audit fields on save; auto-registers all configurations
- **`Context/IAppDbContext.cs`** — interface for the DbContext (use this in DI instead of the concrete type)
- **`Context/AppDbContextFactory.cs`** — design-time factory used by `dotnet ef` CLI
- **`Configurations/`** — one `IEntityTypeConfiguration<T>` per entity; all inherit `BaseEntityConfiguration<T>` which sets up the PK, audit columns, and a **soft-delete query filter** (`IsDeleted == false`)
- **`Repositories/`** — concrete repositories; shadow FK queries use `Microsoft.EntityFrameworkCore.EF.Property<T>`
- **`Extensions/ServiceCollectionExtensions.cs`** — `AddDataLayer()` and `MigrateDatabase()`

### MaturitaFree.App
- **`Program.cs`** — builds the `ServiceCollection`, calls `AddDataLayer()`, exposes `Program.Services` for use anywhere in the app

---

## Configuration

The database path is configured when calling `AddDataLayer()` in `Program.cs`.

### Default (no appsettings needed)
By default the SQLite file is created next to the executable:
```
<exe folder>/maturita.db
```

### Custom path via appsettings.json
Add an `appsettings.json` to `MaturitaFree.App` and read it before registering services:

```json
{
  "Database": {
    "Path": "C:\\Users\\YourName\\AppData\\Local\\MaturitaFree\\maturita.db"
  }
}
```

Then wire it up in `Program.cs`:

```csharp
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

services.AddDataLayer(config["Database:Path"]);
```

Mark the file as **Copy to Output Directory** in its properties so it ships with the build.

---

## Migrations

> Prerequisites: `dotnet ef` global tool installed.
> ```
> dotnet tool install --global dotnet-ef
> ```

All commands should be run from the **solution root** (`MaturitaFree/`).

### Add a migration
```bash
dotnet ef migrations \
  --project MaturitaFree.Data.EF \
  --startup-project MaturitaFree.App \
  add <name>
```

Example:
```bash
dotnet ef migrations \
  --project MaturitaFree.Data.EF \
  --startup-project MaturitaFree.App
  add Init
```

### Apply migrations to the database
```bash
dotnet ef database
  --project MaturitaFree.Data.EF \
  --startup-project MaturitaFree.App \
  update
```

### Remove the last migration (if not yet applied)
```bash
dotnet ef migrations \
  --project MaturitaFree.Data.EF \
  --startup-project MaturitaFree.App
  remove
```

### List all migrations
```bash
dotnet ef migrations \
  --project MaturitaFree.Data.EF \
  --startup-project MaturitaFree.App
  list
```

> The design-time factory (`AppDbContextFactory`) is used automatically by the CLI — no running host is required.

---

## Resolving services at runtime

```csharp
// Specific repository
var bookRepo = Program.Services.GetRequiredService<IBookRepository>();

// Generic repository (basic CRUD only)
var chapterRepo = Program.Services.GetRequiredService<IRepository<BookChapterEntity>>();

// DbContext (for custom queries)
var db = Program.Services.GetRequiredService<IAppDbContext>();
```

---

## Soft Deletes

Entities are never hard-deleted. Calling `repository.DeleteAsync(id)` sets `IsDeleted = true` and stamps `DateDeleted`.

A global query filter on every entity automatically excludes soft-deleted rows from all queries. To include them, use `IgnoreQueryFilters()`:

```csharp
var allIncludingDeleted = await db.Set<BookEntity>()
    .IgnoreQueryFilters()
    .ToListAsync();
```
