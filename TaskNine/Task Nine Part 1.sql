CREATE TABLE sales.Employees
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Salary DECIMAL(10,2)
);
GO

CREATE PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT * FROM sales.Employees
END
GO
EXECUTE GetAllEmployees
GO

CREATE PROCEDURE GetHighSalaryEmployees (@MinSalary DECIMAL(10,2))
AS
BEGIN
    SELECT * FROM sales.Employees
    WHERE Salary > @MinSalary
END
GO
EXECUTE GetHighSalaryEmployees 50000
GO

CREATE PROCEDURE AddEmployee (@FirstName NVARCHAR(50), @LastName NVARCHAR(50), @Salary DECIMAL(10,2))
AS
BEGIN
    INSERT INTO sales.Employees (FirstName, LastName, Salary)
    VALUES (@FirstName, @LastName, @Salary);
END
GO
EXECUTE AddEmployee 'Omar', 'Hassaan', 60000
GO