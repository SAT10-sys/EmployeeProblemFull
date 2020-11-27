using System;

namespace EmployeeProblemFull
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Management Problem");
            /*EmployeeOperations employeeOperations = new EmployeeOperations();
            employeeOperations.AddCompanyToList("Reliance", 20, 25, 100);
            employeeOperations.AddCompanyToList("Tata", 25, 30, 120);
            employeeOperations.AddCompanyToList("Adani", 20, 20, 140);
            employeeOperations.GetWage();
            Console.WriteLine("Enter name of company to find wage");
            string companyName = Console.ReadLine();
            Console.WriteLine("Wage of " + companyName + " is ");
            employeeOperations.GetWagesByCompany(companyName);*/
            Console.WriteLine("Retrieving all employees from the database");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //employeeRepo.RetrieveFromDataBase();
            Console.WriteLine("Enter name and salary");
            string name = Console.ReadLine();
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            employeeRepo.UpdateSalary(name, salary);
        }
    }
}
           
