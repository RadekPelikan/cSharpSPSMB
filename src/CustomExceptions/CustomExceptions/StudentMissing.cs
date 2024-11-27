namespace CustomExceptions;

public class StudentMissing
{
    public List<string> Names;
    

    public StudentMissing(params string[] names)
    {
        Names = names.ToList();
    }

    public bool IsStudentMissing(string studentName)
    {
        if(!Names.Contains(studentName))

        {
            throw new TiCoViException(studentName);
            return true;
        }
        else
        {
            return false;
        }
    }
}