# OOP cheatsheet

## 1. Principy OOP
### 1.1 Encapsulation (zapouzdření)
Enkapsulace schovává detaily pomocí přístupových modifikátorů a poskytuje přístup pouze pomocí veřejných metod.

```csharp
class Person
{
    private string name; // skrytý field
    public string Name   // veřejná properta
    {
        get { return name; }
        set { name = value; }
    }
}
```

### 1.2 Inheritance (dědičnost)
Každá třída dědí od rodičovské třídy metody a vlastnosti
```csharp
public class Animal
{
    public void Speak() => Console.WriteLine("Sound");
}

class Dog : Animal // třída Dog dědí od třídy Animal (má k dispozici metodu Speak)
{
    public void Bark() => Console.WriteLine("Woof!");
}
```

### 1.3 Polymorphism
Polymorfismus umožňuje to, že jedna metoda může mít více podob
#### 1.3.1 Method Overloading (přetížení metody)
Metoda může jiný více parametrů nebo jiné datové typy parametrů
```csharp
public class MathUtils
{
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;
}
```

#### 1.3.2 Method Overriding (přepsání metody)
```csharp
public class Animal
{
    public virtual void Speak() => Console.WriteLine("Some sound."); // Virtual umožňuje danou metodu přepsat
}

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Woof!"); // Tato přepsaná metoda Speak() vypíše něco jiného než metoda Speak() ve třídě Animal 
}
```

---

## 2. Reference types a value types (Referenční typy a hodnotové typy)
Referenční typy se ukládají v Heapě, hodnotové typy ve Stacku

- **Příklady value types:** `int`, `double`, `bool`, `struct`.
- **Příklady reference types:** `string`, `class`, `interface`.
  
![ReferenceXValueTypes](https://github.com/user-attachments/assets/b9693c94-35f8-4848-af25-73b2f1c4349a)

---

## 3. `const` vs `readonly`
- `const`: Musí být inicializována při deklaraci, neměnná.
- `readonly`: Lze inicializovat při deklaraci nebo v konstruktoru.

```csharp
public class Example
{
    public const double Pi = 3.14159;
    public readonly int Id;

    public Example(int id)
    {
        Id = id;
    }
}
```

---

## 4. Konstruktor
 - Konstruktor je speciální metoda, která se používá k inicializaci nových instancí třídy
 - Automaticky se volá při vytváření objektu

### 4.1 Návratová hodnota
Konstruktor nemá návratovou hodnotu.

### 4.2 Modifikátory přístupu
Může být `public`, `private`, `protected`, `internal`.

### 4.3 Počet konstruktorů
Třída může mít nekonečně mnoho konstruktorů (`overloading / přetížení`).

### 4.4 Volání z téže třídy
Volání pomocí `this`.
```csharp
public Example() : this(0) {}
public Example(int id) { }
```

### 4.5 Volání ze zděděné třídy
Volání pomocí `base`.
```csharp
public class Parent
{
    public Parent(int id) { }
}

public class Child : Parent
{
    public Child() : base(1) { }
}
```

---

## 5. Pořadí inicializace členů
1. Statické členy.
2. Instance členy v pořadí deklarace.
3. Konstruktor.
```csharp
using System;

class MyClass
{
    // 1. Statický člen
    static int staticVar = 10;
    
    // 2. Instance členy
    int instanceVar1 = 20;
    int instanceVar2 = 30;

    // Konstruktor
    public MyClass()
    {
        Console.WriteLine("Konstruktor");
        Console.WriteLine($"instanceVar1: {instanceVar1}, instanceVar2: {instanceVar2}");
    }

    // Statická metoda pro demonstraci
    public static void ShowStaticVar()
    {
        Console.WriteLine($"staticVar: {staticVar}");
    }

    // Hlavní metoda
    static void Main()
    {
        Console.WriteLine("Před vytvořením instance:");
        ShowStaticVar(); // Ukázka statického členu
        
        Console.WriteLine("\nVytvoření instance třídy MyClass:");
        MyClass obj = new MyClass(); // Vytvoření instance, volání konstruktoru
    }
}
```

---

## 6. Interface
### 6.1 Více interfaces
Třída může implementovat více interfaces.
```csharp
public interface IFirst { void MethodA(); }
public interface ISecond { void MethodB(); }
public class Example : IFirst, ISecond
{
    public void MethodA() { }
    public void MethodB() { }
}
```

### 6.2 Dědění interfaces
Interface může dědit od jiného interface.
```csharp
public interface IBase { void Method(); }
public interface IDerived : IBase { }
```

### 6.3 Generické interfaces
Interface může být generický.
```csharp
public interface IRepository<T> { void Add(T item); }
```

### 6.4 Implementace v interface
Od C# 8.0 mohou interfaces obsahovat výchozí implementaci.
```csharp
public interface IExample
{
    void MethodA();
    void MethodB() => Console.WriteLine("Default implementation.");
}
```

---

## 7. Metody
### 7.1 Návratová hodnota
Metoda může mít jakýkoliv typ návratové hodnoty nebo být `void` = nic nevrací.

### 7.2 Parametry
- `out`: Výstupní parametr
- `ref`: Odkaz na původní hodnotu
- `in`: Pouze pro čtení
```csharp
public void Example(out int x, ref int y, in int z) { x = z + y; }
```

### 7.3 Extension methods
 - Umožňují přidávat nové funkce existujícím typům
 - Používají klíčové slovo `this`
```csharp
public static class Extensions
{
    public static int Square(this int value) => value * value;
}
```

### 7.4 Přetížení metod
Podle:
1. Počtu parametrů:
```csharp
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}
```
2. Typu parametrů:
```csharp
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }
}
```
---

## 8. `abstract`, `virtual`, `override`, `new`
- `abstract`: Musí být implementována v podtřídě.
- `virtual`: Lze přepsat, není nutné.
- `override`: Přepisuje metodu rodičovské třídy.
- `new`: Skrývá metodu rodičovské třídy.

---

## 9. `sealed`
- **Třída**: Nelze dědit.
- **Metoda**: Nelze přepsat.

---

## 10. `struct`, `record`, `class`
- `struct`: Hodnotový typ
- `record`: Immutable (neměnný) referenční typ
- `class`: Referenční typ

---

## 11. Abstraktní třída vs interface
- Abstraktní třída může obsahovat implementaci
- Interface definuje pouze kontrakt (s výjimkou default methods)

---

## 12. Statické vs instanční proměnné
- **Statické**: Sdílené mezi instancemi
- **Instanční**: Jedinečné pro každou instanci

---

## 13. Inheritance vs Composition
- **Inheritance**: vyjadřuje vztah mezi třídami, kde podtřída (dědící třída) je speciálním případem nadtřídy (základní třídy). Tento vztah se často označuje jako `"Is-a"` vztah. Třída, která dědí, je typem třídy, ze které dědí, a může tedy využívat její metody a vlastnosti, případně je přepsat nebo rozšířit.
- **Composition**: vyjadřuje vztah, kde třída obsahuje jinou třídu jako svůj člen. Tento vztah se označuje jako `"Has-a"`. Třída, která obsahuje jinou třídu, má tuto třídu jako součást svého stavu. Kompozice umožňuje větší flexibilitu, protože třídy nemusí být přímo navzájem propojené prostřednictvím dědičnosti.

# Příklad kompozice
```csharp
class Engine
{
    public void Start() => Console.WriteLine("wruum wruum");
}

class Car 
{
    public Engine CarEngine { get; set; }

    public Car()
    {
        CarEngine = new Engine();
    }

    public void Drive() => CarEngine.Start();
}

Car car = new Car();
car.Drive(); // Car má Engine a může volat jeho metodu Start bez nutnosti dědičnosti
```

---

## 14. Readonly datové struktury
 - Readonly datové struktury v C# pomáhají zajistit, že data zůstanou neměnná po jejich inicializaci
 - Mezi nejběžnější příklady patří readonly pole, imutabilní (neměnné) kolekce a readonly struct


### Readonly pole
```csharp
class Example
{
    public readonly int[] numbers = new int[] { 1, 2, 3 };
}
```

---

### Neměnné kolekce - příklady nejčastějších kolekcí
 - `ImmutableList<T>` – Neměnný seznam
 - `ImmutableArray<T>` – Neměnné pole
 - `ImmutableDictionary<TKey, TValue>` – Neměnný slovník
 - `ImmutableQueue<T>` – Neměnná fronta
 - `ImmutableSortedSet<T>` – Neměnná seřazená množina
 - `ImmutableSortedDictionary<TKey, TValue>` – Neměnný seřazený slovník
   
### Readonly struct
```csharp
public readonly struct Point
{
    public int X { get; }
    public int Y { get; }
    public Point(int x, int y) => (X, Y) = (x, y);
}
```

