CREATE TABLE sales.EmployeeLog (
	ID INT IDENTITY PRIMARY KEY,
    EmployeeId INT,
    Action VARCHAR(50),
    ActionDate DATETIME
)
GO

CREATE TRIGGER TRG_EmployeeLog
ON sales.Employees
AFTER INSERT
AS
BEGIN
    INSERT INTO EmployeeLog (EmployeeId, Action, ActionDate)
    SELECT i.Id, 'INSERT', GETDATE()
    FROM INSERTED i
END
GO