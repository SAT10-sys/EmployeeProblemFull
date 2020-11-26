using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeProblemFull
{
    public class EmployeeOperations
    {
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
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
        public void ComputeWage(string companyName, int wagePerHour, int numOfWorkingDays, int maximumWorkingHours)
        {
            int empWage = 0;
            int totalEmpHours = 0;
            int i = 0;
            while(i<numOfWorkingDays && totalEmpHours<=maximumWorkingHours)
            {
                totalEmpHours = totalEmpHours + GetEmployeeHours();
                i++;
            }
            empWage = totalEmpHours * wagePerHour;
            Console.WriteLine("Company Name: "+companyName+"\n");
            Console.WriteLine("Total Hours worked: "+totalEmpHours+"\nMonthly Wage: "+empWage+"\n");

        }                            
    }
}
