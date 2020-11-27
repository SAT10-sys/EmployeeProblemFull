﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace EmployeeProblemFull
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=.;Initial Catalog=EmployeePayrollFull;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void RetrieveFromDataBase()
        {
            try
            {
                EmployeeDetails employeeModel = new EmployeeDetails();
                using (this.connection)
                {
                    string query = @"select * from EmployeePayroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeId = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.BasicPay = dr.GetDecimal(2);
                            employeeModel.StartDate = dr.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.PhoneNumber = dr.GetString(5);
                            employeeModel.Address = dr.GetString(7);
                            employeeModel.Department = dr.GetString(6);
                            employeeModel.Deductions = dr.GetDecimal(8);
                            employeeModel.TaxablePay = dr.GetDecimal(9);
                            employeeModel.IncomeTax = dr.GetDecimal(10);
                            employeeModel.NetPay = dr.GetDecimal(11);
                            Console.WriteLine(employeeModel.EmployeeId + " " + employeeModel.EmployeeName + " " + employeeModel.BasicPay + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.PhoneNumber + " " + employeeModel.Address + " " + employeeModel.Department + " " + employeeModel.Deductions + " " + employeeModel.TaxablePay + " " + employeeModel.IncomeTax + " " + employeeModel.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else                    
                        System.Console.WriteLine("No data found");                    
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
