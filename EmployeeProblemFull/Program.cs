using System;
using System.Collections.Generic;

namespace EmployeeProblemFull
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EmployeeDetails> empList = new List<EmployeeDetails>();
            Console.WriteLine("Welcome to Employee Problem");
            RegStart:
            Console.WriteLine("Enter a choice between 1 and 5");
            Console.WriteLine("1.RETRIEVE FROM DATABASE\n2.ADD NEW EMPLOYEE TO DATABASE\n3.UPDATE SALARY IN THE DATABASE\n4.GET EMPLOYEES JOINED IN A DATE RANGE\n5.GET AGGREGATE SALARY DETAILS");
            int choice = Convert.ToInt32(Console.ReadLine());
            EmployeeRepo employeeRepo = new EmployeeRepo();
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Retrieving values");
                    employeeRepo.RetrieveFromDataBase();
                    break;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("Enter the following details seperated by comma");
                        Console.WriteLine("Name, BasicPay, StartDate(in DD/MM/YYYY), Gender, Phone Number, Address, Department");
                        string[] detailsOfEmployee = Console.ReadLine().Split(",");
                        EmployeeDetails employee = new EmployeeDetails();
                        employee.EmployeeName = detailsOfEmployee[0];
                        employee.BasicPay = Convert.ToDecimal(detailsOfEmployee[1]);
                        employee.StartDate = Convert.ToDateTime(detailsOfEmployee[2]);
                        employee.Gender = Convert.ToChar(detailsOfEmployee[3]);
                        employee.PhoneNumber = detailsOfEmployee[4];
                        employee.Address = detailsOfEmployee[5];
                        employee.Department = detailsOfEmployee[6];
                        employee.Deductions = 0.2M * employee.BasicPay;
                        employee.TaxablePay = employee.BasicPay - employee.Deductions;
                        employee.IncomeTax = 0.1M * employee.TaxablePay;
                        employee.NetPay = employee.BasicPay - employee.IncomeTax;
                        empList.Add(employee);
                        Console.WriteLine("Do You want to add more employees:- Yes/No");
                        string answer = Console.ReadLine();
                        if (answer.ToUpper() == "NO")
                            break;                        
                    }
                    employeeRepo.AddMultipleEmployee(empList);
                    break;
                case 3:
                    Console.WriteLine("Enter name of the employee whose salary is to be updated");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter new salary");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    employeeRepo.UpdateSalary(name, salary);
                    Console.WriteLine("Salary updated");
                    break;
                case 4:
                    Console.WriteLine("Enter the start-dates range in the following format:- dd/mm/yyyy");
                    DateTime date1 = Convert.ToDateTime(Console.ReadLine());
                    DateTime date2 = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("List of employees joined in the given date range and their details:- ");
                    employeeRepo.GetEmployeesInADateRange(date1, date2);
                    break;
                case 5:
                    Console.WriteLine("Printing details");
                    employeeRepo.GetAggregateSalaryDetails();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Enter choice between 1 and 5");
                    goto RegStart;
            }
        }
    }
}
           
