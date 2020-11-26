using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeProblemFull
{
    public class Company
    {
        public string companyName;
        public int wagePerHour;
        public int numOfWorkingDays;
        public int maximumWorkingHours;
        public int totalEmpWage;
        public Company(string companyName, int wagePerHour, int numOfWorkingDays, int maximumWorkingHours)
        {
            this.companyName = companyName;
            this.wagePerHour = wagePerHour;
            this.numOfWorkingDays = numOfWorkingDays;
            this.maximumWorkingHours = maximumWorkingHours;
        }
        public void SetEmpWage(int totalEmpWage)
        {
            this.totalEmpWage = totalEmpWage;
        }
        public void DisplayWage()
        {
            Console.WriteLine("Total wage for company "+companyName+" is "+totalEmpWage);
        }
    }
}
