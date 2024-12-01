# Co to je delegát?
Delegát je datový typ, který představuje odkazy na metody s konkrétním seznamem parametrů a návratovým typem. Pokud vytvoříte instanci delegátu, můžete příslušnou instanci přidružit s jakoukoli metodou s kompatibilním podpisem a návratovým typem. Metodu můžete vyvolat (nebo volat) prostřednictvím instance delegátu.

Delegáty se používají pro předávání metod jako argumentů jiným metodám.

# Deklarace a použití delegátů
Delegáty se deklarují pomocí slova delegate, např:

   
   ```csharp

delegate void MultiplyCallback(int i, double j);
 ```
Vytvoření instance delegátu
Přímé přiřazení (kratší způsob):

   
   ```csharp

MultiplyCallback d = MultiplyNumbers;
 ```
Přiřazení pomocí anonymní metody:

   
   ```csharp

MultiplyCallback d = delegate(int x, double y) {
    Console.WriteLine(x * y);
};
 ```
Přiřazení pomocí lambda výrazu:

   
   ```csharp

MultiplyCallback d = (x, y) => Console.WriteLine(x * y);
 ```
# Volání delegátu
 ```csharp

d(5, 2.0); // Vyvolá delegáta, který následně zavolá metodu MultiplyNumbers
 ```
Pojmenované vs. Anonymní metody
Pojmenované metody
Pojmenované metody jsou samostatné bloky kódu, které vykonávají určitou činnost a mají přiřazený název. Tímto názvem je můžeme volat kdekoli v našem programu.

# Vstup a výstup:
Mohou přijímat vstupní parametry (např. čísla, řetězce) a mohou vracet hodnoty. Mohou mít také výstupní parametry nebo nemusí vracet nic (typicky označováno jako void).

Příklad
   
   ```csharp

delegate void MultiplyCallback(int i, double j);

void MultiplyNumbers(int m, double n) {
    Console.WriteLine(m * n);
}
 
# Přiřazení a volání delegátu
MultiplyCallback d = MultiplyNumbers;
d(5, 2.0); 
 ```
# Výstup:
Výstupem budou násobky čísel od 1 do 5 a čísla 2.

# Jak kombinovat delegáty
Delegáty v C# umožňují kombinaci více metod do jednoho delegáta, což se nazývá vícesměrové vysílání (multicast delegates). To znamená, že jeden delegát může odkazovat na více než jednu metodu. Můžete použít operátor + k přidání metod a operátor - k odstranění metod z kombinovaného delegáta.

# Vysvětlení kódu
Definice Delegáta:

   
   ```csharp

delegate void CustomCallback(string s);
 ```
Tento řádek definuje delegát, který může odkazovat na metody s jedním parametrem typu string a bez návratové hodnoty.

# Pojmenované Metody:

   
   ```csharp
void Hello(string name) {
    Console.WriteLine($"Hello, {name}!");
}

void Goodbye(string name) {
    Console.WriteLine($"Goodbye, {name}!");
}
 ```
Tyto metody mají stejný podpis jako delegát CustomCallback a vykonávají jednoduché výpisy na konzoli.

# Deklarace Delegátů:

   
   ```csharp

CustomCallback hiDel, byeDel, multiDel, multiMinusHiDel;
 ```
# Inicializace Delegátů:

   
   ```csharp

hiDel = Hello;
byeDel = Goodbye;
 ```
# Kombinace Delegátů:

   
   ```csharp

multiDel = hiDel + byeDel;
 ```
Při kombinaci hiDel a byeDel vznikne nový delegát multiDel, který při vyvolání zavolá obě metody v pořadí, v jakém byly přidány.

# Odebrání Delegátů:

   
   ```csharp

multiMinusHiDel = multiDel - hiDel;
 ```
Tento příkaz odebere hiDel z multiDel, takže multiMinusHiDel nyní volá pouze metodu Goodbye.

# Volání Delegátů:

   
   ```csharp

hiDel("A");
byeDel("B");
multiDel("C");
multiMinusHiDel("D");
 ```
# Výstup bude:

   
   ```csharp

Invoking delegate hiDel:
Hello, A!
Invoking delegate byeDel:
Goodbye, B!
Invoking delegate multiDel:
Hello, C!
Goodbye, C!
Invoking delegate multiMinusHiDel:
Goodbye, D!
 ```