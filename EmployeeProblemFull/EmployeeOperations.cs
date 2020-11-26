using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace EmployeeProblemFull
{
    public class EmployeeOperations:IComputeWage
    {
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;    
        List<Company> companyList;
        Dictionary<string, Company> dictionary = new Dictionary<string, Company>();
        public EmployeeOperations()
        {
            companyList = new List<Company>();
            dictionary = new Dictionary<string, Company>();
        }
        public void AddCompanyToList(string companyName, int wagePerHour, int numOfWorkingDays, int maximumWorkingHours)
        {
            Company company = new Company(companyName, wagePerHour, numOfWorkingDays, maximumWorkingHours);
            companyList.Add(company);
            dictionary.Add(companyName, company);
        }
        public void GetWagesByCompany(string companyName)
        {
            int totalWage;
            try
            {
                totalWage = dictionary[companyName].totalEmpWage;
                Console.WriteLine(totalWage);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }            
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
            for (int i = 0; i < companyList.Count; i++)
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
