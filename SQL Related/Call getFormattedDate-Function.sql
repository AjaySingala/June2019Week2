SELECT EmployeeID,
	Firstname,
	DOB,
	[dbo].[getFormattedDate](DOB)
FROM Employees

