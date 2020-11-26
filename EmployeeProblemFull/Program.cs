using System;

namespace EmployeeProblemFull
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Management Problem");
            EmployeeOperations employeeOperations = new EmployeeOperations();
            employeeOperations.ComputeWage("Reliance", 20, 25, 120);
            employeeOperations.ComputeWage("Tata", 30, 25, 120);
        }
    }
}
           
