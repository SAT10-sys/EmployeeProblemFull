using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeProblemFull
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal TaxablePay { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetPay { get; set; }
        public DateTime StartDate { get; set; }
    }
}
