using System;
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
        public bool AddEmployee(EmployeeDetails employee)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    cmd.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", employee.Address);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Deductions",employee.Deductions);
                    cmd.Parameters.AddWithValue("@TaxableIncome", employee.TaxablePay);
                    cmd.Parameters.AddWithValue("@IncomeTax", employee.IncomeTax);
                    cmd.Parameters.AddWithValue("@NetPay", employee.NetPay);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                        return true;
                    else
                        return false;
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
            return false;
        }
        public bool UpdateSalary(string name, decimal salary)
        {
            try
            {
                using (this.connection)
                {                
                    SqlCommand cmd = new SqlCommand("SpUpdateSalary", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", name);
                    cmd.Parameters.AddWithValue("@BasicPay", salary);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                        return true;
                    else
                        return false;
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
            return false;
        }
        public bool GetEmployeesInADateRange(string date1, string date2)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpGetEmployeesInDateRange", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartDate1", date1);
                    cmd.Parameters.AddWithValue("@StartDate2", date2);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                        return true;
                    else
                        return false;
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
            return false;
        }
    }
}
