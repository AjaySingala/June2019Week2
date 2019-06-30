--In select query it will take only committed values of table. If any transaction is opened and
--incomplete on table in others sessions then select query will wait till no transactions 
-- are pending on same table.
--Read Committed is the default transaction isolation level.

-- SESSION #1
begin tran
	select Salary from Salaries where EmployeeID=1
	update Salaries set Salary=999 where EmployeeID=1
	waitfor delay '00:00:15'
commit
