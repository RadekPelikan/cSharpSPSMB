
Pridejte moznost rozvrhu

přidejte 2 entity:

### TeacherEntity

- Id
- Name

### TimeTableRecordEntity

- Id
- SubjectId
- TeacherId
- ClassId
- StartTime
- MinuteDuration

## Vývoj

### Migrace

```bash
dotnet tool install --global dotnet-ef
```

Přidat migraci pomocí:
```bash
cd .\EFCoreVIrgin.Data.EF\
dotnet ef --startup-project ..\EFCoreVirgin\ migrations add <nazev>
```

## Implementace

### Repository

- ClassRepository: Roman Brdlik
- ProfileRepository: Ondrej Fila
- StudentRepository: Ondrej Tomsicek
- SubjectRepository: Petr Kredba
- TeacherRepository: Matej Silhan
- TimeTableRecordRepository: Matej Kulisek
