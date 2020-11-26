using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeProblemFull
{
    public class EmployeeOperations
    {
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
        int numOfCompanies = 0;
        Company[] companyList;
        public EmployeeOperations()
        {
            companyList = new Company[5];
        }
        public void AddCompanyToArray(string companyName, int wagePerHour, int numOfWorkingDays, int maximumWorkingHours)
        {
            companyList[numOfCompanies] = new Company(companyName, wagePerHour, numOfWorkingDays, maximumWorkingHours);
            numOfCompanies++;
        }
        public int GetEmployeeHours()
        {
            Random random = new Random();
            int empCheck = random.Next(0, 3);
            int empHrs = 0;
            switch(empCheck)
            {
                case 0:
                    empHrs = 0;
                    break;
                case IS_PART_TIME:
                    empHrs = 4;
                    break;
                case IS_FULL_TIME:
                    empHrs = 8;
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    empHrs = 0;
                    break;
            }
            return empHrs;
        }
        public void GetWage()
        {
            for (int i = 0; i < numOfCompanies; i++)
                companyList[i].SetEmpWage(ComputeWage(companyList[i]));
        }
        public int ComputeWage(Company company)
        {
            int empWage = 0;
            int totalEmpHours = 0;
            int i = 0;
            while(i<company.numOfWorkingDays && totalEmpHours<=company.maximumWorkingHours)
            {
                totalEmpHours = totalEmpHours + GetEmployeeHours();
                i++;
            }
            empWage = totalEmpHours * company.wagePerHour;
            Console.WriteLine("Company Name: "+company.companyName+"\n");
            Console.WriteLine("Total Hours worked: "+totalEmpHours+"\nMonthly Wage: "+empWage+"\n");
            return empWage;
        }                            
    }
}
