# Ukoly


## FizzBuzz

- Když číslo je dělitelné 3, vypište fizz
- Když číslo je dělitelné 5, vypište buzz
- Když číslo je dělitelné 3 a 5, vypiště fizzbuzz
- Když číslo není dělitelné ničím, vypište to číslo

Udělejte loop 1 - 100 a aplikujte fizzbuzz algoritmus.

Udělejte si pro fizzbuzz fuknci, která bude vyhodnocovat jedno číslo a vrátí `fizz` `buzz` `fizzbuzz` nebo číslo

## Hádání čísla

Program vypíše, že má napsat číslo mezi spodní a horní hranicí. Například 0 až 100
Program vygeneruje náhodné číslo mezi spodní a horní hranicí
Program zažádá o user input 

Pokud číslo není stejné, tak program  vypíše, jestli je číslo větší nebo menší.
Pokud je číslo stejné, tak vypíše, že správně uhádl číslo s počtem pokusů

## Vytvořte kalkulačku

Zažádejte o user input a user input bude vypadat následovně:
```
4 + 5
```
Zažádá o new line a převede přechozí string na tyto tokeny (promněnné:
- firstNumber = 4
- secondNumber = 5
- operator = "+"

Operator bude switch statementem.
- Pokud bude "+", čísla se sečtou
- Pokud bude "-", čísla se odečtou
- Pokud bude "/", čísla se vydělí
- Pokud bude "*", čísla se vynásobí
- Pokud bude "**", čísla se umocní

Tokeny mohou být rozděleny více mezerami a čísla musí podporovat destinnou čárku. Desetinné číslo je dané tečkou

Poté se vyprintuje výsledek výpočtu v následujícím formátu:

user zadá `4 +     5`<br/>
a vyprintuje se: `4 + 5 = 9`

Validní user input:

```
1 * 6
4.5 + 6
-5   / 2
+6   ** 2
7  -  5.444
```

