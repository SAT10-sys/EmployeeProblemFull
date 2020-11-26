using System;

namespace EmployeeProblemFull
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Management Problem");
            EmployeeOperations employeeOperations = new EmployeeOperations();
            employeeOperations.AddCompanyToArray("Reliance", 20, 25, 100);
            employeeOperations.AddCompanyToArray("Tata", 25, 30, 120);
            employeeOperations.AddCompanyToArray("Adani", 20, 20, 140);
            employeeOperations.GetWage();
        }
    }
}
           
