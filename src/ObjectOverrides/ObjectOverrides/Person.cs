public class Person : IEquatable<Person>
{
    public string Name;

    public Person(string name)
    {
        Name = name;
    }
    
    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name;
    }
    
    public static bool operator ==(Person obj1, Person obj2)
    {
        
        if (ReferenceEquals(obj1, obj2)) 
            return true;
        if (ReferenceEquals(obj1, null)) 
            return false;
        if (ReferenceEquals(obj2, null))
            return false;
        return obj1.Equals(obj2);
    }
    
    public static bool operator !=(Person obj1, Person obj2)
    {
        return !(obj1 == obj2);
    }
}


