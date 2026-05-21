// See https://aka.ms/new-console-template for more information

/**
 * Vytvořte record Car
 * - string Color
 * - string Brand
 * - string Model
 * - int ProductionYear
 *
 * Vytvořte funkci PrintCarProperties()
 * za pomocí reflexe
 * metoda bude vypisovat všechny public property daného auta s jejími hodnotami
 *
 * Výstup:
 * Color = blue
 * Brand = Skoda
 * Model = Kamiq
 * ProductionYear = 2024
 */


var car = new Car()
{
    Color = "blue",
    Brand = "Skoda",
    Model = "Kamiq",
    ProductionYear = 2024,
    PowerKw = 100,
};

car.PrintCarProperties();