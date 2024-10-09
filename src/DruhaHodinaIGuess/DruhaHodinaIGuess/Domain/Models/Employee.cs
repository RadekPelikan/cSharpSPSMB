using System;

namespace DruhaHodinaIGuess
{
    public class Employee
    {
        public string Name;
        public int Salary;
        public Department Department;

        public Employee(string name, int salary, Department department)
        {
            var splittedName = name.Split(' ');
            if (name.Length > 0 && name != null && splittedName.Length == 2)
            {
                this.Name = name;
            }
            else
            {
                this.Name = "Franta Novák";
            }
            this.Salary = salary;
            this.Department = department;
        }

        public int CalculateMonthlySalary()
        {
            return this.Salary / 12;
        }
        public void DisplayInformation()
        {
            Console.WriteLine($"Jmeno: {this.Name}");
            Console.WriteLine($"Department: {this.Department}");
            Console.WriteLine($"Roční plat: {this.Salary}");
            Console.WriteLine($"Měsíční plat: {CalculateMonthlySalary()}");
        }
    }
}