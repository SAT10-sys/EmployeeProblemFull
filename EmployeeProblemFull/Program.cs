using System;

namespace EmployeeProblemFull
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Management Problem");
            const int IS_FULL_TIME = 2;
            const int IS_PART_TIME = 1;
            const int WAGE_PER_HOUR=20;
            Random random = new Random();
            int empCheck = random.Next(0, 3); //generates a random number between 0 and 2 where 0 is inclusive but 2 is exclusive
            int empHours = 0;
            int empWage = 0;
            /*
            // UC1_Checking for attendance
            if(empCheck==IS_FULL_TIME)
                Console.WriteLine("Employee is Present");
            else
                Console.WriteLine("Employee is Absent");            
            //UC2 Calculating wage for part time and full time employee
            if (empCheck == IS_FULL_TIME)
                empHours = 8;
            else
                empHours = 0;
            //UC3 Added Part time employee details
            if (empHours == IS_FULL_TIME)
            {
                Console.WriteLine("Full time Employee");
                empHours = 8;
            }
            else if (empHours == IS_PART_TIME)
            {
                Console.WriteLine("Part time Employee");
                empHours = 4;
            }
            else
            {
                Console.WriteLine("Employee is Absent");
                empHours = 0;
            }*/

            //UC4 Implemented Using Switch Case
            switch(empCheck)
            {
                case 0:
                    Console.WriteLine("Employee is absent");
                    empHours = 0;
                    break;
                case IS_PART_TIME:
                    Console.WriteLine("Part Time Employee");
                    empHours = 4;
                    break;
                case IS_FULL_TIME:
                    Console.WriteLine("Full Time Employee");
                    empHours = 8;
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    break;
            }
            empWage = empHours * WAGE_PER_HOUR;
            Console.WriteLine("Total hours worked today: " + empHours + "\nTotal Wage today: " + empWage); 
        }
    }
}
