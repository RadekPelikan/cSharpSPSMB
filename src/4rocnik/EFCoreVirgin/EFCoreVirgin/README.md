
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

Pridejte si base repozitar
```bash
git remote add base https://github.com/RadekPelikan/cSharpSPSMB.git
```

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

Podivejte se na ClassRepository pro udelani konstruktoru

- ClassRepository: Roman Brdlik
- ProfileRepository: Ondrej Fila
- StudentRepository: Ondrej Tomsicek
- SubjectRepository: Petr Kredba
- TeacherRepository: Matej Silhan
- TimeTableRecordRepository: Matej Kulisek

### Facade

- StudentFacade: Stepan Zdarsky
- TeacherFacade: Michal Dvorak
- TimeTableRecordFacade: Jan Urban
