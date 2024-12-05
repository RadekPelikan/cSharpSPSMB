# Generika

## Úvod do Generiky

V jazyce C# poskytuje generika efektivní mechanismus pro tvorbu opakovaně použitelného kódu s podporou různých typů, což zvyšuje flexibilitu a typovou bezpečnost. Generika se využívá především tam, kde je potřeba pracovat s více datovými typy, aniž by docházelo ke ztrátě bezpečnosti nebo efektivity. Spolu s dědičností tvoří dva hlavní mechanismy pro psaní znovupoužitelného kódu.

## Příklad s Objektovým Zásobníkem

Před zavedením generik bylo běžné pracovat s objekty typu `ObjectStack`, kde se pro každý prvek muselo provádět přetypování a kontrola typu. Následující ukázka ilustruje práci s takovým zásobníkem:

```csharp
public class ObjectStack {
    int position;
    object[] data = new object[100];
    
    public void Push(object obj) => data[position++] = obj;
    public object Pop() => data[--position];
}
```
# Příklad s Generickým Zásobníkem

Generický zásobník (`Stack<T>`) umožňuje definovat typ, se kterým bude zásobník pracovat, což eliminuje potřebu přetypování a minimalizuje chyby.

## Příklad implementace

```csharp
public class Stack<T> {
    int position;
    T[] data = new T[100];

    public void Push(T obj) => data[position++] = obj;
    public T Pop() => data[--position];
}
```
Zavedením generiky tedy získáváme zásobník, který je bezpečný a efektivní. Typ `T` slouží jako "placeholder" pro libovolný typ určený uživatelem.

# Typové Parametry a Otevřené vs. Uzavřené Typy

Generické typy mohou být otevřené nebo uzavřené. 

## Otevřené Typy

Otevřený typ, jako `Stack<T>`, funguje jako šablona, která umožňuje definovat libovolný typ při použití zásobníku.

## Uzavřené Typy

Uzavřený typ, jako `Stack<int>`, je konkrétní instance se specifikovaným typem `int`. Tímto způsobem se generické typy přizpůsobují různým datovým typům.

## Typová Bezpečnost

V době běhu jsou všechny generické typy uzavřené, což umožňuje typovou bezpečnost a prediktivní chování aplikace. To zajišťuje, že aplikace funguje správně a bez typových chyb.

# Generické Metody

Generické metody umožňují implementovat algoritmy, které jsou nezávislé na konkrétním typu. Typové parametry jsou uvedeny přímo v podpisu metody.

## Příklad Implementace

Následující příklad ukazuje, jak implementovat generickou metodu pro výměnu dvou hodnot:

```csharp
static void Swap<T>(ref T a, ref T b) {
    T temp = a;
    a = b;
    b = temp;
}
```
Tato metoda `Swap` může pracovat s libovolným typem, což z ní činí univerzální algoritmus. Díky použití generik lze snadno provádět operace bez nutnosti přetypování, což zvyšuje efektivitu a bezpečnost kódu.

# Omezování Generických Typů

Omezení definují, jaké typy lze použít jako parametry generických tříd a metod. Tato omezení zvyšují typovou bezpečnost a usnadňují práci s generiky.

## Typy Omezení

Následující omezení mohou být použita v generických typech:

- **`where T : struct`**  
  T musí být hodnotový typ.

- **`where T : class`**  
  T musí být referenční typ.

- **`where T : new()`**  
  T musí mít veřejný konstruktor bez parametrů.

Díky těmto omezením lze přesněji specifikovat, jaké typy jsou přijímány, což zvyšuje bezpečnost a použitelnost kódu.

# Kovariance a Kontravariance

Kovariance a kontravariance umožňují flexibilní použití typů v generických rozhraních a delegátech. Tyto koncepty jsou klíčové pro efektivní práci s generickými kolekcemi a delegáty.

## Kovariance

Kovariance umožňuje použít odvozený typ na místě základního typu. To znamená, že můžete použít typ, který je odvozen od základního typu, v kontextu, kde se očekává základní typ.

## Kontravariance

Kontravariance dovoluje použít základní typ na místě odvozeného typu. Tento princip umožňuje flexibilněji definovat parametry v generických typech, což je užitečné při předávání dat mezi metodami a objekty.

## Použití v Delegátech a Kolekcích

Tyto koncepty jsou klíčové zejména při práci s delegáty a kolekcemi, protože umožňují efektivnější a bezpečnější manipulaci s typy, aniž by došlo k porušení typové bezpečnosti.

# Význam Generik

Generika představuje efektivní způsob, jak vytvářet znovupoužitelný a bezpečný kód. Díky možnosti práce s typy bez nutnosti přetypování přinášejí generické třídy několik klíčových výhod.

## Hlavní Výhody Generik

- **Znovupoužitelnost**: Generické typy umožňují vytváření algoritmů a datových struktur, které mohou pracovat s různými datovými typy, což výrazně zvyšuje znovupoužitelnost kódu.

- **Bezpečnost**: Generika poskytuje typovou bezpečnost, což znamená, že chyby způsobené nesprávným přetypováním mohou být odhaleny během kompilace namísto běhu programu.

- **Efektivita**: Generické třídy a metody jsou rychlejší a efektivnější než starší techniky s objektovými typy, protože eliminují potřebu přetypování a zbytečné balení hodnot.

Generika tedy představuje moderní přístup k vývoji softwaru, který usnadňuje práci s typy a zvyšuje kvalitu kódu.

