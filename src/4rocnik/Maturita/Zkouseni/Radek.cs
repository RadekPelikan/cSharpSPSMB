namespace Zkouseni;

public class Radek
{
    public string Name { get; set; }
    public EDrogy RadekFet = EDrogy.FENT;

    private int _aura = 99999;

    // dokumentace
    public Radek(string name = "Nejlepsi nejuzasnejsi Radek", int aura = Int32.MaxValue)
    {
        _aura = aura;
        Name = name;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public string RadeksFavoriteThingInTheWholeBeautifulWorld(int a)
    {
        Console.WriteLine(RadekFet);
        return "ahoj";
    }
    
    
}