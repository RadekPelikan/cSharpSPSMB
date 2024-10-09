using System;

namespace DruhaHodinaIGuess
{
    public class Boss : Employee
    {
        protected int StockOptions;
        public Boss(string name, int salary, Department department, int stockOptions) : base(name, salary, department)
        {
            StockOptions = stockOptions;
        }
        public int CalculateMonthlySalary()
        {
            return (this.Salary + this.StockOptions) / 12;
        }

        public void DisplayInformation()
        {
            Console.WriteLine($"Jmeno: {this.Name}");
            Console.WriteLine($"Department: {this.Department}");
            Console.WriteLine($"Roční plat: {this.Salary}");
            Console.WriteLine($"StockOptions: {this.StockOptions}");
            Console.WriteLine($"Měsíční plat: {base.CalculateMonthlySalary()}");
        }


    }
}