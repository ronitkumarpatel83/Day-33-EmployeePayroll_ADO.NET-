using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day33EmployeePayrollDB
{
    public class EmployeeRepository
    {
        public static string ConnectingString = @"Data Source=LAPTOP-5KJG784B;Initial Catalog=payroll_service_DB;User ID=RonitKP;Password=password;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection Connection = null;
        public void GetAllEmployees()
        {
            try
            {
                using (Connection = new SqlConnection(ConnectingString))
                {
                    EmployeePayroll Payroll = new EmployeePayroll();
                    string query = "select * from employee_payroll_DB";
                    SqlCommand cmd = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Payroll.EmployeeID = Convert.ToInt32(reader["ID"] == DBNull.Value ? default : reader["ID"]);
                            Payroll.Phone = Convert.ToInt32(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                            Payroll.BasicPay = Convert.ToDouble(reader["BasicPay"] == DBNull.Value ? default : reader["BasicPay"]);
                            Payroll.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                            Payroll.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                            Payroll.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                            Payroll.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                            Payroll.Startdate = (DateTime)((reader["Startdate"] == DBNull.Value ? default(DateTime) : reader["Startdate"]));
                            Payroll.TaxablePay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                            Payroll.NetPay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                            Payroll.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                            Payroll.Deduction = Convert.ToDouble(reader["Deduction"] == DBNull.Value ? default : reader["Deduction"]);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Payroll.EmployeeID, Payroll.Phone, Payroll.BasicPay, Payroll.Address, Payroll.Name, Payroll.Department, Payroll.Gender, Payroll.Startdate, Payroll.TaxablePay, Payroll.NetPay, Payroll.IncomeTax, Payroll.Deduction);
                            Console.WriteLine("\n");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddEmployee(EmployeePayroll Payroll)
        {
            try
            {
                Connection = new SqlConnection(ConnectingString);
                SqlCommand cmd = new SqlCommand("dbo.spAddEmployee", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Payroll.Name);
                cmd.Parameters.AddWithValue("@Address", Payroll.Address);
                cmd.Parameters.AddWithValue("@BasicPay", Payroll.BasicPay);
                cmd.Parameters.AddWithValue("@Phone", Payroll.Phone);
                cmd.Parameters.AddWithValue("@Gender", Payroll.Gender);
                Connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result != 0)
                    Console.WriteLine("Employee inserted successfully into table");
                else
                    Console.WriteLine("Not Insertes");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }
        
        public void UpdateEmployee(EmployeePayroll payroll)
        {
            try
            {
                using (Connection = new SqlConnection(ConnectingString))
                {
                    EmployeePayroll payrollUpdate = new EmployeePayroll();
                    SqlCommand command = new SqlCommand("dbo.spUpdateEmployee",Connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeID", payroll.EmployeeID);
                    command.Parameters.AddWithValue("@Name", payroll.Name);
                    command.Parameters.AddWithValue("@BasicPay", payroll.BasicPay);
                    Connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        Console.WriteLine("Update Successfully");
                    else
                        Console.WriteLine("Unsuccessfull");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

    }
}
