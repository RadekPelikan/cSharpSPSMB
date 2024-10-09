using System;

namespace DruhaHodinaIGuess
{
    class Manager : Employee
    {
        public int Bonus;

        public Manager(string name, int salary, Department department, int bonus) : base(name, salary, department)
        {
            this.Bonus = bonus;
            
        }

        public int CalculateMonthlySalary()
        {
            return (this.Salary + this.Bonus) / 12;
        }

        public void DisplayInformation()
        {
            Console.WriteLine($"Jmeno: {this.Name}");
            Console.WriteLine($"Department: {this.Department}");
            Console.WriteLine($"Roční plat: {this.Salary}");
            Console.WriteLine($"Bonus: {this.Bonus}");
            Console.WriteLine($"Měsíční plat: {base.CalculateMonthlySalary()}");
        }

    }
}