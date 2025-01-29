## Movie Manager

**Uživatelské rozhranní**
- uživatel mohl zobrazit všechny filmy (vypiš 3 fieldy. Název, lead studio, rating)
- uživatel mohl ukládat nový film
- uživatel mohl zobrazit film pomocí názvu (Movie slopec) (vypiš všechno o filmu)
- uživatel mohl aktualizovat film

**bonus**
- chci abych mohl z csv převést na json (movies.csv) -> (movies.json) (interní funkce, která nebude nijak používána)
    - `void WriteJsonFromCsv(string csvPath, string jsonPath)`
    - bude zapisovat data jako json soubor na dané cestě
    - data bude příjmat z předaného souboru
- ukládat data do souboru json (movies.json) a pracovat s ním v předchozích operacích

Filmová struktura bude převzatá a data z:
https://gist.githubusercontent.com/tiangechen/b68782efa49a16edaf07dc2cdaa855ea/raw/0c794a9717f18b094eabab2cd6a6b9a226903577/movies.csv

