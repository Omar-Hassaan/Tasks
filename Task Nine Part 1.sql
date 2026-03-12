CREATE TABLE sales.employees
(
    employee_id INT IDENTITY PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    salary DECIMAL(10, 2)
);
GO

CREATE  PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT * FROM sales.employees
END
GO
EXECUTE GetAllEmployees
GO

CREATE  PROCEDURE GetHighSalaryEmployees (@MinSalary DECIMAL(10,2))
AS
BEGIN
    SELECT * FROM sales.employees
    WHERE salary > @MinSalary
END
GO
EXECUTE GetHighSalaryEmployees @MinSalary = 50000
GO

CREATE  PROCEDURE AddEmployee (@FirstName VARCHAR(50), @LastName VARCHAR(50), @Salary DECIMAL(10,2))
AS
BEGIN
    INSERT INTO sales.employees (first_name, last_name, salary)
    VALUES (@FirstName, @LastName, @Salary)
END
GO
EXECUTE AddEmployee @FirstName = 'John', @LastName = 'Doe', @Salary = 60000
GO