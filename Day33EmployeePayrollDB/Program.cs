using System;

namespace Day33EmployeePayrollDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ADO.NET Program");
            EmployeePayroll Payroll = new EmployeePayroll();
            Payroll.Name = "Abhilash";
            Payroll.Address = "Patnagarh";
            Payroll.Phone = 896465465;
            Payroll.BasicPay = 700000;
            Payroll.Gender = "M";
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.GetAllEmployees();
            employeeRepository.AddEmployee(Payroll);
            Console.ReadLine();
        }
    }
}
