using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeProblemFull;
using System;

namespace EmployeeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OnEnteringNameAndSalaryShouldReturnTrueAfterUpdation()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            string name = "Kate";
            decimal salary = 750000;
            bool result = employeeRepo.UpdateSalary(name, salary);
            Assert.AreEqual(result, true);
        }       
        [TestMethod]
        public void OnaddingEmployeeShouldSyncWithDB()
        {
            EmployeeDetails employee = new EmployeeDetails();
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employee.EmployeeName = "Harry";
            employee.Department = "Finance";
            employee.PhoneNumber = "9999999999";
            employee.Address = "Kolkata";
            employee.Gender = Convert.ToChar("M");
            employee.StartDate = DateTime.Today;
            employee.BasicPay = Convert.ToDecimal(800000);
            employee.Deductions = Convert.ToDecimal(80000);
            employee.TaxablePay = Convert.ToDecimal(720000);
            employee.IncomeTax = Convert.ToDecimal(7200);
            employee.NetPay = Convert.ToDecimal(712800);
            bool result = employeeRepo.AddEmployee(employee);
            Assert.AreEqual(result, true);
        }
    }
}
