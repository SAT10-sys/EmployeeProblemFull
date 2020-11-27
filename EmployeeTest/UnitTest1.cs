using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeProblemFull;

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
    }
}
