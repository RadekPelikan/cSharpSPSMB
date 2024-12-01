# Delegáty

Co to je delegát?: datový typ ,který představuje odkazy na metody s konkrétním seznamem parametrů a návratovým typem. Pokud vytvoříte instanci delegátu, můžete příslušnou instanci přidružit s jakoukoli metodou s 
    kompatibilním podpisem a návratovým typem. Metodu můžete vyvolat (nebo volat) prostřednictvím instance delegátu.

    jak to může vypadat:
    
 ![Snímek obrazovky 2024-10-22 220453](https://github.com/user-attachments/assets/ba96ac9c-c99c-4e1a-b2d1-d675747318cb)

Delegáty se používají pro předávání metod jako argumentů jiným metodám.

# Deklarace a použití delegátů

  Delegáty se deklarují pomocí slova delegate, např:
![Snímek obrazovky 2024-10-22 221539](https://github.com/user-attachments/assets/415cd5bb-cef0-4cf0-8081-8a3453162dcc)

Vytvoření instance delegátu:
1) přímí přiřazení(kratší způsob)-----       ![Snímek obrazovky 2024-10-22 221823](https://github.com/user-attachments/assets/e99af27c-fe90-41d0-9b98-27e75c94d6d9)
2) Přiřazení pomocí anonymní metody---- ![Snímek obrazovky 2024-10-22 221856](https://github.com/user-attachments/assets/144d66fa-1b9c-498f-ae69-fda29130f6ae)
3) přiřazení pomocí lambda výrazu---- ![Snímek obrazovky 2024-10-22 221921](https://github.com/user-attachments/assets/82a3c1c2-928e-4245-8c5a-773e437fcdc5)

Volání delegátu----
![Snímek obrazovky 2024-10-22 222148](https://github.com/user-attachments/assets/7747576d-01c8-47ca-af6c-c6510973add5)

# Pojmenované vs. Anonymní metody
  Pojmenované metody:  samostatné bloky kódu, které vykonávají určitou činnost a mají přiřazený název. Tímto názvem je můžeme volat kdekoli v našem programu.
  vstup a výstup:  mohou přijímat vstupní parametry (např. čísla, řetězce) a mohou vracet hodnoty. Mohou mít také výstupní parametry nebo nemusí vracet nic (typicky označováno jako void).
  ![Snímek obrazovky 2024-10-22 222914](https://github.com/user-attachments/assets/63f38d07-f6c7-4f62-8671-2a7fbded1175)

  Přiklad----
![Snímek obrazovky 2024-10-22 222943](https://github.com/user-attachments/assets/a6a876fc-df71-4e2d-a12d-351993b7ffa5)
Vysvětlení:
1)Deklarace Delegáta:

delegate void MultiplyCallback(int i, double j);
Tento řádek definuje typ delegáta, který může odkazovat na jakoukoli metodu, která přijímá dva parametry (int a double) a nevrací žádnou hodnotu (void).

2)Pojmenovaná Metoda:

void MultiplyNumbers(int m, double n) {...}
Tato metoda provádí násobení dvou čísel a vypisuje výsledek. Je to pojmenovaná metoda, protože má jasný název (MultiplyNumbers).

3)Přiřazení a Volání Delegátu:

MultiplyCallback d = m.MultiplyNumbers;
Tímto přiřazujeme instanci delegáta d k pojmenované metodě MultiplyNumbers.
d(i, 2); volá delegáta, který následně zavolá metodu MultiplyNumbers s aktuální hodnotou i a číslem 2 jako argumenty.

4)Výstup:

Výstupem budou násobky čísel od 1 do 5 a čísla 2:


# Jak kombinovat delegáty
Delegáty v C# umožňují kombinaci více metod do jednoho delegáta, což se nazývá vícesměrové vysílání (multicast delegates). To znamená, že jeden delegát může odkazovat na více než jednu metodu. Můžete použít operátor + k přidání metod a operátor - k odstranění metod z kombinovaného delegáta.



![Snímek obrazovky 2024-10-22 222943](https://github.com/user-attachments/assets/97de04a9-76c3-4eab-8e91-81b76cc67105)

Vysvětlení Kódu
1)Definice Delegáta: delegate void CustomCallback(string s);

Tímto se definuje delegát, který může odkazovat na metody s jedním parametrem typu string a bez návratové hodnoty.
2)Pojmenované Metody: Hello a Goodbye

Tyto metody mají stejný podpis jako delegát CustomCallback a vykonávají jednoduché výpisy na konzoli.
3)Deklarace Delegátů:

Zde deklarujeme čtyři delegáty.
CustomCallback hiDel, byeDel, multiDel, multiMinusHiDel;

4)Inicializace Delegátů:
hiDel = Hello;
byeDel = Goodbye;
Tyto řádky přiřazují metody Hello a Goodbye k delegátům hiDel a byeDel.
5)Kombinace Delegátů:
multiDel = hiDel + byeDel;
Při kombinaci hiDel a byeDel vznikne nový delegát multiDel, který při vyvolání zavolá obě metody v pořadí, v jakém byly přidány.
6)Odebrání Delegátů:
multiMinusHiDel = multiDel - hiDel;
Tento příkaz odebere hiDel z multiDel, takže multiMinusHiDel nyní volá pouze metodu Goodbye.
7)Volání Delegátů:
Každý delegát je poté volán s různými argumenty, což výsledně vypíše:
Invoking delegate hiDel:
  Hello, A!
Invoking delegate byeDel:
  Goodbye, B!
Invoking delegate multiDel:
  Hello, C!
  Goodbye, C!
Invoking delegate multiMinusHiDel:
  Goodbye, D!

