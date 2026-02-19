CREATE DATABASE Data_Definition_Questions;
GO
USE Data_Definition_Questions;
GO

--1.Create a table named "Employees" with columns for ID (integer), Name (varchar), and Salary (decimal).
CREATE TABLE Employees
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL
)
GO
--2.Add a new column named "Department" to the "Employees" table with data type varchar(50).
ALTER TABLE Employees
ADD Department VARCHAR(50);
GO
--3.Remove the "Salary" column from the "Employees" table.
ALTER TABLE Employees
DROP COLUMN Salary;
GO
--4.Rename the "Department" column in the "Employees" table to "DeptName".
EXEC sp_rename 'Employees.Department', 'DeptName', 'COLUMN';
GO
--5.Create a new table called "Projects" with columns for ProjectID (integer) and ProjectName (varchar).
CREATE TABLE Projects
(
	ProjectID INT PRIMARY KEY IDENTITY(1,1),
	ProjectName VARCHAR(50) NOT NULL
)
GO
--6.Add a primary key constraint to the "Employees" table for the "ID" column.
ALTER TABLE Employees
ADD CONSTRAINT Employees_ID PRIMARY KEY (ID);
GO
--7.Add a unique constraint to the "Name" column in the "Employees" table.
ALTER TABLE Employees
ADD CONSTRAINT Employees_Name UNIQUE (Name);
GO
--8.Create a table named "Customers" with columns for CustomerID (integer), FirstName (varchar), LastName (varchar), and Email (varchar), and Status (varchar).
CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	[Status] VARCHAR(20) NOT NULL
)
GO
--9.Add a unique constraint to the combination of "FirstName" and "LastName" columns in the "Customers" table.
ALTER TABLE Customers
ADD CONSTRAINT Customers_Name UNIQUE (FirstName, LastName);
GO
--10.Create a table named "Orders" with columns for OrderID (integer), CustomerID (integer), OrderDate (datetime), and TotalAmount (decimal).
CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY(1,1),
	CustomerID INT NOT NULL,
	OrderDate DATETIME2 NOT NULL,
	TotalAmount DECIMAL(10, 2) NOT NULL,
)
GO
--11.Add a check constraint to the "TotalAmount" column in the "Orders" table to ensure that it is greater than zero.
ALTER TABLE Orders
ADD CONSTRAINT CHK_Orders_TotalAmount CHECK (TotalAmount > 0);
GO
--12.Create a schema named "Sales" and move the "Orders" table into this schema.
CREATE SCHEMA Sales;
GO
ALTER SCHEMA Sales
TRANSFER dbo.Orders;
GO
--13.Rename the "Orders" table to "SalesOrders."
EXEC sp_rename 'Sales.Orders', 'SalesOrders';
GO