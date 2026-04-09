namespace WebApplication.Praxe;

/// <summary>
/// This class represents a simple calculator class
/// </summary>
public class Calculator: ICalculator
{
    /// <summary>
    /// This is custom property for examination (just to represent syntax of property)
    /// </summary>
    public string Property { get; set; }
    /// <summary>
    /// This is custom private field for examination (just to represent syntax of property)
    /// </summary>
    private int _num1 { get; set; }

    public Calculator()
    {
        
    }
    /// <summary>
    /// This method is for making a simple mathematical operation (x+y)
    /// </summary>
    /// <param name="x">First number</param>
    /// <param name="y">Second number</param>
    /// <returns>x+y</returns>
    public int Sum(int x, int y)
    {
        return x + y;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int MultiplyNumbers(int x, int y)
    {
        return x * y;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="DivideByZeroException">There can be problem</exception>
    public int Diff(int x, int y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Nelze dělit nulou");
        }
        return x / y;
    }
    
    
    
}