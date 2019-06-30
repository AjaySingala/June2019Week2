-- Session #1
begin tran
	select * from Salaries
	waitfor delay '00:00:15'
commit
