namespace BasicOpakovani.Domain
{
    public class Person
    {
        public Gender PersonGender;
        public Marriage PersonMarriage;
        public string Name;
        public int Age;
        public int Weight;
        public string? HairColor;

        public Person(string name, int age, int weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
            
        }
    }
}