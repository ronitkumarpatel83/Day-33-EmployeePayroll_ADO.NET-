using System;

namespace Day33EmployeePayrollDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ADO.NET Program");
            EmployeePayroll Payroll = new EmployeePayroll();
            Payroll.Name = "Terissa";
            Payroll.EmployeeID = 6;
            Payroll.BasicPay = 3000000;
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.GetAllEmployees();
            employeeRepository.AddEmployee(Payroll);
            employeeRepository.UpdateEmployee(Payroll);
            Console.ReadLine();
        }
    }
}
