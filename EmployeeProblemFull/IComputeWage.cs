using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeProblemFull
{
    public interface IComputeWage
    {
        public void AddCompanyToList(string companyName, int wagePerHour, int numOfWorkingDays, int maximumWorkingHours);
        public int GetEmployeeHours();
        public void GetWage();
    }
}
