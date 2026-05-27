

/**
 * Vytvořte databázi otazka11.rp
 *
 * Vytvořte tabulku User, která má sloupce:
 * Id, Name, Age, CreatedAt, UpdatedAt
 *
 * Vytvořte tabulku Item, která obsahuje:
 * Id, Name, Count, UserId, CreatedAt, UpdatedAt
 *
 * Vytořte metodu pro vypisování všech uživatelů s jejich košíkem
 * void PrintUsers()
 * Fanda(1): [rohlík: 5, Jablko: 3, mouka: 1]
 * Lukáš(2): [cukr: 3, bramobry: 50, ocet: 4]
 *
 * Vytvořte metodu na přidání položky do košiku uživateli
 * void AddToCart(int userId, Item item)
 */


using MySqlConnector;
using otazka11;

Run.Task01();