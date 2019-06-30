--Select query in Session2 executes after update Emp table in transaction and before transaction
--rolled back. Hence new value is returned instead of old.

-- Session #2.
set transaction isolation level read uncommitted
select Salary from Salaries where EmployeeID=1

