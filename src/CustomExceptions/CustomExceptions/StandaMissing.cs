namespace CustomExceptions;

public class StandaMissing
{
    public List<string> Names;
    public const string Standa = "Standa";

    public StandaMissing(params string[] names)
    {
        Names = names.ToList();
    }

    public bool IsStandaMissing()
    {
        if(!Names.Contains(Standa))

        {
            throw new TiCoViException("standa chybi");
            return true;
        }
        else
        {
            return false;
        }
    }
}