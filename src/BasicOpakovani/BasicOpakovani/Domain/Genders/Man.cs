namespace BasicOpakovani.Domain
{
    public class Man : Person
    {
        public float Salary;
        
        public Man(string name, int age, int weight, float salary) : base(name, age, weight)
        {
            Salary = salary;
        }

        public float CalculateMonthlySalary()
        {
            return Salary / 12;
        }
        
    }
}