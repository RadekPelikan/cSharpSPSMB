# Git
- systém orgánů, které slouží k příjmu a zpracování potravy a následnému vyloučení nestravitelných zbytků z organizmu

## HighLevel - Jak používat git commandy

- `git clone` - stáhne repozitář na lokální zařízení (PC).
- `git add <path>` - "staguje" soubory, `<path>` určí, jaké soubory nebo adresář "zastagovat".
- `git commit -m "<message>"` - "commitne" soubory s danou `<message>`.
- `git push` - uploadne změny na remote repozitář (např. GitHub).
- `git pull` - stáhne změny na lokální zařízení z remote repozitáře.

# Git 'stage'

### Co je staging
Staging je proces, kdy připravujeme soubory, které chceme commitnout. Soubor musí být ve stavu "staged", než může být součástí commitu.

### Jak funguje `git add`
- `git add <path>` přidá soubor do staging area.
- Chcete-li přidat všechny soubory, použijte `git add .`.

### Jak přidám/odeberu do stage
- Přidat: `git add <file>`
- Odebrat: `git reset <file>`

### Jak si zobrazím, co mám ve stage
- Použijte `git status` k zobrazení staged a unstaged souborů.

# Git commit

### Co přesně znamená commit
Commit ukládá změny v kódu do repozitáře s popisnou zprávou.

### Jak uzavřu stage
- Použijte `git commit -m "<message>"`.

### Jak odeberu commit
- Použijte `git reset --soft HEAD~1` pro odebrání posledního commitu.

### Jak si zobrazím commity
- Použijte `git log`.

### Jaké flagy git commit ještě může mít?
- `-a`: automaticky stage všechny upravené soubory před commitnutím.
- `--amend`: upraví poslední commit.

# Git branch

### Co je git branch
Branch (větev) umožňuje pracovat na různých funkcionalitách nebo opravách bez ovlivnění hlavního kódu.

### Jak vytvořím novou branch
- `git branch <branch-name>`.

### Jak smažu branch
- `git branch -d <branch-name>`.

### Jak to funguje
Každá větev je jako samostatná linie vývoje. Můžete přepínat mezi nimi.

### Jak si zobrazím branche
- `git branch` pro zobrazení existujících větví.

### Jak zjistím, na jakém aktuálním branchi jsem
- `git branch` a aktuální větev bude označena hvězdičkou (*).

### Jak si zobrazím rozdíl mezi dvěma branchami
- `git diff <branch1>..<branch2>` ukáže rozdíly mezi větvemi.

### Jak si zobrazím rozdíl dvou branchí
- `git diff <branch1> <branch2>`.

### Příklad jmenné konvence nazývání branchí
- `feature/nová-funkce` nebo `bugfix/opravena-chyba`.

# Git merge

### Co je git merge
Merge sloučí změny z jedné větve do druhé.

### Jak se používá
- `git merge <branch-name>`.

### Jak zruším merging
- `git merge --abort`.

### Co jsou merge conflicts a jak je vyřeším?
Merge conflict nastane, když dvě větve mají konfliktní změny. Musíte je vyřešit ručně a poté commitnout.

# Git rebase

### Co je git rebase
Rebase přenáší změny z jedné větve na jinou, což vytváří lineární historii.

### Jak se používá
- `git rebase <branch-name>`.

# Git pull

### Co je git pull
Stáhne změny z remote repozitáře a sloučí je s lokálními změnami.

### Jak se používá
- `git pull origin <branch-name>`.

# Git remote

### Co je git remote
Remote repozitář je vzdálené úložiště, například GitHub.

### Jak se používá
- Přidání: `git remote add <name> <url>`.
- Odebrání: `git remote remove <name>`.
- Změna URL: `git remote set-url <name> <new-url>`.

### Jaký je rozdíl mezi lokálním repozitářem a remote repozitářem
Lokální repozitář je na vašem PC, zatímco remote repozitář je na serveru (např. GitHub).

# Git push

### Co je git push
Push uploaduje lokální změny na remote repozitář.

### Jak se používá
- `git push origin <branch-name>`.

# Pull Request

### Co je pull request
Pull request je žádost o sloučení změn z jedné větve do druhé.

### Jak se vytvoří v GitHubu
1. Vytvořte novou branch a proveďte změny.
2. Přejděte na GitHub a klikněte na "New Pull Request".

### Co pull request obsahuje
Obsahuje změny, které byly provedeny, a zprávu o tom, co bylo změněno.

### Kdo jej schvaluje
Pull request obvykle schvaluje jiný člen týmu nebo správce repozitáře.

# Soubor .gitignore

### Co je .gitignore
Soubor .gitignore určuje, které soubory a složky by měly být ignorovány Gitem.

### Jak se používá
Vytvořte soubor s názvem `.gitignore` a přidejte názvy souborů nebo složek, které chcete ignorovat.

### Vysvětlení celé syntaxi
- Každý řádek v .gitignore obsahuje cestu k souboru nebo složce, které mají být ignorovány.

### Jak se používá hvězdička
- Hvězdička (`*`) reprezentuje libovolné znaky. Např. `*.log` ignoruje všechny soubory s příponou .log.

### Jak ignoruji soubory
- Přidejte název souboru do `.gitignore`.

### Jak ignoruji složky
- Přidejte název složky (s lomítkem na konci) do `.gitignore`, např. `logs/` pro ignoraci složky logs.
