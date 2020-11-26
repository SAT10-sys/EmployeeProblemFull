using System;

namespace EmployeeProblemFull
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Management Problem");
            EmployeeOperations employeeOperations = new EmployeeOperations();
            int totEmpHrs = employeeOperations.GetEmployeeHours();
            employeeOperations.ComputeWage(totEmpHrs);
        }
    }
}
           
