

create procedure spUpdateEmployee
@Name varchar(200),
@BasicPay float,
@EmployeeID int
As
Update employee_payroll_DB set BasicPay=@BasicPay where Name=@Name and @EmployeeID=@EmployeeID;

use payroll_service_DB;
select * from employee_payroll_DB;

select * from employee_payroll_DB where Startdate between CAST('2010-01-01' as Date) and GETDATE();