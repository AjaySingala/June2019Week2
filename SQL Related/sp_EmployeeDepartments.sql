DROP PROCEDURE [dbo].[sp_EmployeeDepartments]
GO

CREATE PROCEDURE [dbo].[sp_EmployeeDepartments]
	(@empId int)
AS
BEGIN
	SELECT 
		e.EmployeeID,
		e.Firstname,
		e.Lastname,
		e.DOB,
		e.DepartmentID,
		d.ID,
		d.Name
	FROM Employees as e
	INNER JOIN Departments as d
		ON e.DepartmentID = d.Id
	WHERE e.EmployeeID = @empId

	-- SELECT * FROM OrderDetails
END
GO


