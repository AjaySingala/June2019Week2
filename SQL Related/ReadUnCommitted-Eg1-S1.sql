--Read Uncommitted
--If any table is updated(insert or update or delete) under a transaction and same transaction is not
--completed that is not committed or roll backed then uncommitted values will displaly(Dirty Read) in
--select query of "Read Uncommitted" isolation transaction sessions. There won't be any delay in
--select query execution because this transaction level does not wait for committed values on table.

begin tran
	SELECT * FROM Salaries WHERE EmployeeID = 1
	update Salaries set Salary=859 where EmployeeID=1
	waitfor delay '00:00:15'
rollback
