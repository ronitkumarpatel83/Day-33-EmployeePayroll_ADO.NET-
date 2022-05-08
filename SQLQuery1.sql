

create procedure spUpdateEmployee
@Name varchar(200),
@BasicPay float,
@EmployeeID int
As
Update employee_payroll_DB set BasicPay=@BasicPay where Name=@Name and @EmployeeID=@EmployeeID;