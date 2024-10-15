# Git

## HighLevel - Jak používat git commandy
- **`git clone`**: Stáhne repozitář na lokální zařízení (PC).
- **`git add <path>`**: "Staguje" soubory, `<path>` určuje, které soubory nebo adresáře stagovat.
- **`git commit -m "<message>"`**: Uloží změny s popisnou zprávou `<message>`.
- **`git push`**: Uploadne změny na remote repozitář (např. GitHub).
- **`git pull`**: Stáhne změny z remote repozitáře na lokální zařízení.

## Git 'stage'
- **Co je staging**: Staging je proces přípravy souborů na commit.
- **Jak funguje `git add`**: Přidá soubor do staging area, např. `git add <file>`.
- **Jak přidám/odeberu do stage**: Přidání: `git add <file>`, Odebrání: `git reset <file>`.
- **Jak si zobrazím, co mám ve stage**: Použij `git status`.

## Git commit
- **Co znamená commit**: Uložení změn v kódu do repozitáře.
- **Jak uzavřu stage**: Použij `git commit -m "<message>"`.
- **Jak odeberu commit**: `git reset --soft HEAD~1`.
- **Jak si zobrazím commity**: Použij `git log`.
- **Flagy pro git commit**: `-a` (automaticky stage), `--amend` (upraví poslední commit).

## Git branch
- **Co je git branch**: Větev umožňuje pracovat na různých funkcích bez ovlivnění hlavního kódu.
- **Jak vytvořím novou branch**: `git branch <branch-name>`.
- **Jak smažu branch**: `git branch -d <branch-name>`.
- **Jak si zobrazím branche**: `git branch`.
- **Jak zjistím aktuální branch**: `git branch` (označeno hvězdičkou).
- **Jak si zobrazím rozdíl mezi dvěma branchami**: `git diff <branch1>..<branch2>`.
- **Jak si zobrazím rozdíl dvou branchí**: `git diff <branch1> <branch2>`.
- **Příklad jmenné konvence**: `feature/nová-funkce` nebo `bugfix/opravena-chyba`.

## Git merge
- **Co je git merge**: Sloučení změn z jedné větve do druhé.
- **Jak se používá**: `git merge <branch-name>`.
- **Jak zruším merging**: `git merge --abort`.
- **Co jsou merge conflicts**: Konflikty vznikají při pokusu o sloučení změn, které se navzájem odporují. Řeší se ručně.

## Git rebase
- **Co je git rebase**: Přenáší změny z jedné větve na jinou, čímž vytváří lineární historii.
- **Jak se používá**: `git rebase <branch-name>`.

## Git pull
- **Co je git pull**: Stáhne změny z remote repozitáře a sloučí je s lokálními změnami.
- **Jak se používá**: `git pull origin <branch-name>`.

## Git remote
- **Co je git remote**: Vzdálené úložiště (např. GitHub).
- **Jak se používá**: 
  - Přidání: `git remote add <name> <url>`.
  - Odebrání: `git remote remove <name>`.
  - Změna URL: `git remote set-url <name> <new-url>`.
- **Rozdíl mezi lokálním a remote repozitářem**: Lokální je na PC, remote je na serveru.

## Git push
- **Co je git push**: Uploaduje lokální změny na remote repozitář.
- **Jak se používá**: `git push origin <branch-name>`.

## Pull Request
- **Co je pull request**: Žádost o sloučení změn z jedné větve do druhé.
- **Jak se vytvoří v GitHubu**: Vytvořte novou branch, proveďte změny a klikněte na "New Pull Request".
- **Co pull request obsahuje**: Obsahuje změny a zprávu o tom, co bylo změněno.
- **Kdo jej schvaluje**: Obvykle jiný člen týmu nebo správce repozitáře.

## Soubor .gitignore
- **Co je .gitignore**: Určuje, které soubory a složky by měly být ignorovány Gitem.
- **Jak se používá**: Přidejte názvy souborů nebo složek do souboru `.gitignore`.
- **Syntaxe**: Každý řádek obsahuje cestu k souboru nebo složce.
- **Jak se používá hvězdička**: Hvězdička (`*`) reprezentuje libovolné znaky (např. `*.log`).
- **Jak ignoruji soubory**: Přidejte název souboru do `.gitignore`.
- **Jak ignoruji složky**: Přidejte název složky (s lomítkem na konci) do `.gitignore`.

