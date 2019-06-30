--In second session, it returns the result only after execution of complete transaction in 
-- first session because of the lock on the table. We have used wait command to delay 
-- 15 seconds after updating the Emp table in transaction.

-- SESSION #2
set transaction isolation level read committed
select Salary from Salaries where EmployeeID=1
