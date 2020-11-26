using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeProblemFull
{
    public class EmployeeOperations
    {
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
        public const int WAGE_PER_HOUR = 20;
        public const int WORKING_DAYS_PER_MONTH = 20;
        public const int TOTAL_WORKING_HOURS = 100;     
        public int GetEmployeeHours()
        {
            Random random = new Random();
            int i = 0;
            int totalEmpHours = 0;
            int empHours = 0;
            while(i<WORKING_DAYS_PER_MONTH && totalEmpHours<TOTAL_WORKING_HOURS)
            {
                int empCheck = random.Next(0, 3);
                switch(empCheck)
                {
                    case 0:
                        Console.WriteLine("Employee is Absent");
                        empHours = 0;
                        break;
                    case IS_PART_TIME:
                        Console.WriteLine("Part time employee");
                        empHours = 4;
                        break;
                    case IS_FULL_TIME:
                        Console.WriteLine("Full time employee");
                        empHours = 8;
                        break;
                    default:
                        Console.WriteLine("Invalid Result");
                        break;
                }
                i++;
                totalEmpHours = totalEmpHours + empHours;                
            }
            return totalEmpHours;
        }
        public void ComputeWage(int totalEmpHours)
        {
            int empWage = 0;
            empWage = totalEmpHours * WAGE_PER_HOUR;
            Console.WriteLine("Total hours worked: "+totalEmpHours+"\nTotal wage for the month: "+empWage);
        }
    }
}
