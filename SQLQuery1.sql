

create procedure spUpdateEmployee
@Name varchar(200),
@BasicPay float,
@EmployeeID int
As
Update employee_payroll_DB set BasicPay=@BasicPay where Name=@Name and @EmployeeID=@EmployeeID;

use payroll_service_DB;
select * from employee_payroll_DB;

select * from employee_payroll_DB where Startdate between CAST('2010-01-01' as Date) and GETDATE();

select SUM(BasicPay) as Total_Salary from employee_payroll_DB;
select AVG(BasicPay) as Average_Salary from employee_payroll_DB;
select MIN(BasicPay) as Minimum_Salary from employee_payroll_DB;
select MAX(BasicPay) as Maximum_Salary from employee_payroll_DB;
select COUNT(BasicPay) as NUmber_of_Employee from employee_payroll_DB;
select SUM(BasicPay)as Total_Group_Of_Female from employee_payroll_DB WHERE Gender = 'F' GROUP BY gender;