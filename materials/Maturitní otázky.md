## 1. Algoritmizace a složitost algoritmů

- **Definice algoritmu**
	- Co je algoritmus a jaké jsou jeho základní vlastnosti?
	- Jaké jsou způsoby zápisu algoritmu?
	- Jaký je rozdíl mezi algoritmem a programem?
- **Struktura algoritmu**
	- Popište základní struktury algoritmu (sekvenční, podmíněná, cyklická)
	- Jak se liší deterministické a nedeterministické algoritmy?
- **Časová a prostorová složitost**
	- Co znamená časová a prostorová složitost a proč je důležitá?
	- Jak se používá asymptotická notace Big-O?
	- Porovnání různých časových složitostí (O(1), O(n), O(log n), O(n²)) a jejich dopad na výkon algoritmu.
- **Třídicí algoritmy**
	- Co jsou třídící algoritmy?
	- Jak fungují algoritmy Bubble Sort, Selection Sort a Insertion Sort?

---

## 2. Základy programování v jazyce C\#

- **Programování a jazyky**
	- Co je program a co je programovací jazyk?
	- Jak dělíme programovací jazyky podle abstrakce?
	- Jaký je rozdíl mezi kompilátorem a interpretem?
	- Co je rozdíl mezi zdrojovým a IL (Intermediate Language) kódem?
- **Nástroje a IDE**
	- Jaké IDE se nejčastěji používají pro C# (Visual Studio, Rider, VS Code)?
	- Jak probíhá kompilace a spuštění C# programu?
- **Paradigmata**
	- Co znamená pojem programovací paradigma?
	- Jaké jsou různé paradigmata a jaké jsou jejich výhody či nevýhody?
	- Jaká programovací paradigmata C# podporuje?
- **Vlastnosti jazyka C#**
	- Jaké jsou hlavní vlastnosti C# oproti jiným jazykům (statická typovost, CLR)?
	- K čemu se C# používá v praxi (desktop, web, hry, mobilní aplikace)?

---

## 3. Strukturování kódu

- **Projekty a řešení**
	- Jaký je rozdíl mezi projektem a solution ve Visual Studiu?
- **Obory názvů (namespaces)**
	- K čemu slouží namespace a jak se používají?
	- Jaký je význam klíčového slova `using`?
- **Soubory a třídy**
	- Jak se strukturuje kód do souborů a tříd?
- **Konvence a styl kódu**
	- Jaké jsou základní konvence v C# (pojmenovávání, PascalCase, camelCase)?
- **Komentáře**
	- Proč je důležité či nedůležité komentovat zdrojový kód?
	- Jaké máme typy komentářů a jak vypadá jejich syntaxe?

---

## 4. Pokročilý syntax jazyka C#

- **Rozšířené konstrukce**
	- Co je `switch expression` a jak se liší od klasického `switch`?
	- Jak funguje `using` pro správu prostředků?
- **Moderní prvky jazyka**
	- Co je interpolace řetězců?
	- Jak fungují `records` a `tuples`?
	- Jak funguje getter, setter?
- **Pattern matching**
	- Jaké jsou typy patternů v C# a k čemu se používají?
- **Atributy**
	- Jak fungují atributy a k čemu slouží?
	- Jak mohu vytvořit vlastní atribut?
- **Null safety**
	- Co je nullable reference type a proč se zavádí?

---

## 5. Objektově orientované programování (OOP)

- **Základy OOP**
	- Co je objekt, třída, properties, field a metoda?
	- Jaké výhody přináší OOP oproti procedurálnímu programování?
- **Konstruktor a instance**
	- Jak funguje konstruktor v C#?
	- Jak se vytváří instance třídy a jak k ní přistupovat?
- **Zapouzdření**
	- Jak fungují modifikátory přístupu (public, private, protected, internal)?
	- Co znamená zapouzdření a proč je důležité?
- **Dědičnost a polymorfismus**
	- Jak funguje dědičnost v C#?
	- Jaký je rozdíl mezi `virtual`, `override` a `new`?
	- Co je polymorfismus a jak se využívá v praxi?
- **Speciální metody**
	- Co jsou to destruktory a kdy se používají?
	- Co znamenají klíčová slova `static`, `sealed`, `abstract`?

---

## 6. Kolekce a práce s iteracemi

- **Základní kolekce**
	- Jaké kolekce nabízí C# (`List`, `Dictionary`, `HashSet`)?
	- Jaký je rozdíl mezi polem (`array`) a `List<T>`?
- **Iterace**
	- Jak funguje `foreach` v C#?
	- Jak použít `yield return` v iterátoru?
- **LINQ**
	- Co je LINQ a jak zjednodušuje práci s kolekcemi?
	- Jak funguje deferred execution?
	- Jak funguje IQueryable a k čemu slouží?

---

## 7. Formátování textu, řetězce a regulární výrazy

- **Řetězce**
	- Jak se zapisuje řetězec v C#?
	- Jak funguje string interpolation a string.Format()?
- **Metody řetězců**
	- Jaké běžné metody nabízí `string` (`Substring`, `Replace`, `Split`)?
- **Regulární výrazy**
	- Jak funguje třída `Regex` v C#?
	- K čemu slouží metody `Match`, `Matches`, `Replace`?

---

## 8. Funkce, generické programování

- **Metody**
	- Jak se definuje metoda v C#?
	- Co jsou parametry a návratová hodnota?
- **Přetížení metod**
	- Jak funguje overloading?
- **Generika**
	- Co jsou generické typy a metody?
	- Jaký je rozdíl mezi `List<object>` a `List<T>`?
	- Co znamenají generické omezení (`where T : class`)?
	- Co je typ `dynamic`

---

## 9. Práce se soubory

- **Základní práce**
	- Jak funguje třída `File` a `FileStream`?
	- Jaký je rozdíl mezi textovým a binárním souborem?
- **Čtení a zápis**
	- Jak číst a zapisovat soubory pomocí `StreamReader` a `StreamWriter`?
	- Jak bezpečně pracovat se soubory pomocí `using`?
- **CSV soubory**
	- Co znamená CSV a jaká je struktura tohoto typu souboru?
	- Jak můžeme s CSV souborem pracovat při běhu C# programu?
- **JSON soubory**
	- K čemu slouží formát JSON a kdy se používá?
	- Jak pracovat s JSON daty pomocí `System.Text.Json`

---

## 10. Výjimky, ladění a kontrola kódu

- **Výjimky**
	- Jak funguje konstrukce `try`, `catch`, `finally`?
	- Jaké jsou typy výjimek ve standardní knihovně?
	- Jak vytvořit vlastní výjimku?
- **Ladění**
	- Jak funguje ladicí režim v Jetbrains Rider?
	- Co je krokování (step over, step into)?
- **Analýza kódu**
	- Co je Roslyn a jak pomáhá s analýzou kódu?
	- Jaký je význam pravidel stylu (StyleCop, .editorconfig)?
- **Unit testing**
	- Co je jednotkový test a proč se používá?
	- Jak se v C# používá balíček Xunit?
	- Jak napsat jednoduchý testovací případ a jak ho spustit?

---

## 11. Práce s databází

- **Základní pojmy databází**
	- Co je databáze a jaký je její účel?
	- Jaký je rozdíl mezi databází a entitou?
	- Jaký je rozdíl mezi SQL a NoSQL databázemi?
- **Základní SQL příklady**
	- Jak vytvořit tabulku a vložit do ní data?
	- Jak upravit, smazat nebo vybrat data?
	- Jak omezit a řadit výsledky pomocí WHERE, ORDER BY a LIMIT?
- **Databázový návrh a struktura**
	- Co je primární a cizí klíč a k čemu slouží?
	- Jaké jsou nejpoužívanější datové typy v MySQL?
- **ADO.NET**
	- Jak vytvořit připojení k databázi?
	- Jak spustit SQL dotaz pomocí `SqlCommand`?
	- Jak bezpečně pracovat s databází (parametrizace dotazů, uzavírání spojení)?

---

## 12. Standardní knihovna, NuGet balíčky

- **Argumenty při spouštění programu**
	- Jak dostat přístup k argumentům (command line arguments)?
	- Jak zpracovat CLI vlajky? Jaký balíček se k tomu může použít?
- **Standardní knihovna**
	- Jaké základní třídy poskytuje .NET (`System.IO`, `System.Text`, `System.Net`)?
- **NuGet**
	- Co je NuGet a jak funguje správa balíčků?
	- Jak přidat balíček do projektu a jak spravovat závislosti?
- **.NET reflexe**
	- Co je reflexe a k čemu slouží?
	- Praktické otázky/reflexe.
	- Jaké populární nuget balíčky využívají reflexi?

---

## 13. Vlákna, asynchronní programování, externí linkování

- **Vlákna**
	- Jak vytvořit nové vlákno pomocí `Thread` a `ThreadPool`?
	- Co je `lock` a proč se používá?
- **Task a async/await**
	- Co je `Task` a jak se liší od vlákna?
	- Jak funguje klíčové slovo `async` a `await`?
	- Jak se řeší deadlocky?
- **Externí knihovny**
	- Co jsou linkové soubory a k čemu slouží?
	- Jak funguje atribut DllImport?
	- Jaké je praktické využítí externích knihoven?

---

## 14. Vývoj her v MonoGame

- **Úvod**
	- Co je MonoGame a k čemu slouží?
	- Jaké typy her lze v MonoGame vytvářet?
- **Základní smyčka hry**
	- Jak funguje metoda `Update()` a `Draw()`?
- **Grafika a vstup**
	- Jak načíst a vykreslit sprite?
	- Jak vykreslit text na obrazovce?
	- Jak detekovat vstupy z klávesnice a myši?

---

## 15. Návrhové vzory

- **Typy návrhových vzorů**
	- Jaké jsou základní kategorie návrhových vzorů?
	- Jaký je rozdíl mezi jednotlivými typy návrhových vzorů?
	- Kdy volit jaký typ návrhového vzoru podle potřeby aplikace?
- **Tvořivé návrhové vzory**
	- Co je Singleton a proč se používá?
	- Jak funguje Builder a jak umožňuje sestavovat složité objekty?
	- Jak funguje návrhový vzor Factory a jaké jsou jeho alternativy?
- **Strukturální návrhové vzory**
	- Co je Facade a jak pomáhá zjednodušit používání složitých knihoven?
	- Co je repozitář a jakou abstrakci přináší při práci s externími zdroji?
	- Jaké další vzory patří mezi strukturální?
- **Návrhový vzor MVC**
	- Co znamená zkratka MVC?
	- Jaká je úloha jednotlivých částí MVC v aplikaci?
	- Jaké výhody přináší použití MVC pro větší projekty?

---

## 16. Tvorba webových aplikací pomocí ASP.NET

- **Základy webu**
	- Jaký je rozdíl mezi frontendem a backendem?
	- Co je HTTP a jaké používáme metody požadavků?
	- Jaký je rozdíl mezi stavovými kódy v HTTP?
	- V čem se liší HTTPS oproti HTTP?
- **ASP.NET Core**
	- Jak vytvořit základní projekt v ASP.NET Core?
	- Co je Controller?
	- Jak funguje routování?
- **MVC v ASP.NET**
	- Co jsou controllery a view?
	- Jak se pracuje s modelem a databází?
- **Formuláře a zpracování dat**
	- Jak vytvořit formulář pohled a odeslat ho na server?
	- Jak validovat data a vracet chyby?

---

## 17. Okenní aplikace WinForms

- **Úvod**
	- Co je WinForms a k čemu slouží?
	- Jaký je rozdíl mezi konzolovou a okenní aplikací?
	- Co znamená GUI a jaké výhody přináší pro uživatele?
- **Základní prvky UI**
	- Jak přidáme tlačítko a reagovat na jeho událost?
	- Jak přidáme text do okna?
	- Co je event handler?
- **Stylování a pokročilé možnosti**
	- Jak můžeme upravit vzhled aplikace (barvy, fonty, velikosti)?
	- Jak můžeme vytvořit nový User Control a čemu slouží?

---

## 18. Real-time komunikace a SignalR

- **Základy real-time komunikace**
	- Co je real-time komunikace a kdy se s ní můžeme setkat?
	- Jaký je rozdíl mezi klasickým HTTP požadavkem a SignalR / WebSocket komunikací?
	- Jaké výhody má použití real-time komunikace (např. chat, notifikace)?
- **WebSocket a protokol komunikace**
	- Co je WebSocket a jaký je jeho princip?
	- Jak funguje obousměrná komunikace mezi klientem a serverem?
	- V čem se liší WebSocket / SignalR od běžného HTTP požadavku?
- **SignalR a jeho použití v .NET**
	- Co je SignalR a jak zjednodušuje práci s WebSockety v .NET aplikacích?
	- Jak vypadá základní aplikace v C# s použitím ASP.NET Core SignalR?
	- Jak se definuje obsluha událostí (hub metody, Clients.All.SendAsync, Groups)?
- **Použití SignalR**
	- Jaké události je možné zachytávat (připojení, odpojení, zpráva)?
	- Jak zpracovat data přijatá od klienta a rozeslat je ostatním klientům?
	- Jak používat skupiny (Groups) pro cílené vysílání zpráv?
- **SignalR a frontend**
	- Jak spolupracuje C# backend se SignalR na straně klienta (JavaScript/TypeScript)?
	- Jak vypadá jednoduchý JavaScript klient pro SignalR?
	- Jak zajistit přenos dat mezi více klienty přes společný SignalR hub?

---

## 19. Práce s Entity Framework Core

- **Základy ORM**
	- Co je ORM a proč se používá?
	- Jak funguje EF Core jako ORM nástroj?
	- Jak pracuje EF Core s IQueryable?
- **Modely a migrace**
	- Jak definovat entitu a relační vazby?
	- Co jsou migrace a jak se používají?
- **Konfigurace entit**
	- Jak se konfigurují entity a jejich relace?
	- Jak se definují ON DELETE constraints?
	- K čemu slouží `IEntityTypeConfiguration`?
- **Mapování**
	- Co znamená mapování a k čemu slouží?
	- Jakými způsoby můžeme docílit mapování mezi entitami a modely
	- Jaké nuget balíčky se využívají k mapování?

---

## 20. Keycloak identity

- **Základy identity**
	- Co je identity management a proč je důležitý?
	- Jak funguje autentizace a autorizace?
- **Tokeny a bezpečnost**
	- Jak funguje OAuth2 a OpenID Connect?
	- Co je JWT token a jak se používá?
- **Keycloak**
	- Co je Keycloak a k čemu slouží?
	- Jaké jsou alternativy Keycloak a jaké jsou jejich výhody a nevýhody?
	- Jak Keycloak podporuje více realmů a klientů?
	- Jak nastavit Keycloak pro různé typy klientů: web, mobile, API?
- **ASP.NET integrace**
	- Jak napojt ASP.NET na keycloak?

