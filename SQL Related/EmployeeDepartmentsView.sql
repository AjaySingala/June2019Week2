DROP VIEW [dbo].[EmployeeDepartmentsView]
GO

CREATE VIEW [dbo].[EmployeeDepartmentsView]
AS
	SELECT 
		e.EmployeeID,
		e.Firstname,
		e.Lastname,
		e.DepartmentID,
		d.ID,
		d.Name
	FROM Employees as e
	INNER JOIN Departments as d
		ON e.DepartmentID = d.Id
GO


