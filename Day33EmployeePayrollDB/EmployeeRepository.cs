﻿using System;
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

       
    }
}