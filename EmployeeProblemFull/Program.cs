using System;

namespace EmployeeProblemFull
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Management Problem");
            EmployeeOperations reliance = new EmployeeOperations("Reliance",20,25,100);
            EmployeeOperations tata = new EmployeeOperations("Tata", 30, 25, 120);
            reliance.ComputeWage();
            tata.ComputeWage();
        }
    }
}
           
