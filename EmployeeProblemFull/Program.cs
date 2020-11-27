using System;

namespace EmployeeProblemFull
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Problem");
            RegStart:
            Console.WriteLine("Enter a choice between 1 and 4");
            Console.WriteLine("1.RETRIEVE FROM DATABASE\n2.ADD NEW EMPLOYEE TO DATABASE\n3.UPDATE SALARY IN THE DATABASE\n4.GET EMPLOYEES JOINED IN A DATE RANGE");
            int choice = Convert.ToInt32(Console.ReadLine());
            EmployeeRepo employeeRepo = new EmployeeRepo();
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Retrieving values");
                    employeeRepo.RetrieveFromDataBase();
                    break;
                case 2:
                    Console.WriteLine("Enter the following details seperated by comma");
                    Console.WriteLine("Name, BasicPay, StartDate(in DD/MM/YYYY), Gender, Phone Number, Address, Department, Deductions, Taxable Pay, Income Tax, NetPay");
                    string[] detailsOfEmployee = Console.ReadLine().Split(",");
                    EmployeeDetails employee = new EmployeeDetails();
                    employee.EmployeeName = detailsOfEmployee[0];
                    employee.BasicPay = Convert.ToDecimal(detailsOfEmployee[1]);
                    employee.StartDate = Convert.ToDateTime(detailsOfEmployee[2]);
                    employee.Gender = Convert.ToChar(detailsOfEmployee[3]);
                    employee.PhoneNumber = detailsOfEmployee[4];
                    employee.Address = detailsOfEmployee[5];
                    employee.Department = detailsOfEmployee[6];
                    employee.Deductions = Convert.ToDecimal(detailsOfEmployee[7]);
                    employee.TaxablePay = Convert.ToDecimal(detailsOfEmployee[8]);
                    employee.IncomeTax = Convert.ToDecimal(detailsOfEmployee[9]);
                    employee.NetPay = Convert.ToDecimal(detailsOfEmployee[10]);
                    employeeRepo.AddEmployee(employee);
                    Console.WriteLine("Employee added successfully");
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
                default:
                    Console.WriteLine("Invalid choice. Enter choice between 1 and 4");
                    goto RegStart;
            }
        }
    }
}
           
