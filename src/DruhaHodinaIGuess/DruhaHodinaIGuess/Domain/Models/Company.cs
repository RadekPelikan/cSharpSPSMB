using System.Collections.Generic;

namespace DruhaHodinaIGuess
{
    public class Company
    {
        public readonly Boss Boss;
        public readonly List<Employee> Employees;
        public readonly CompanyType CompanyType;


        
        public Company( Boss boss, List<Employee> employees, CompanyType companyType )
        {
            Boss = boss;
            Employees = employees;
            CompanyType = companyType;
        }
    }
}