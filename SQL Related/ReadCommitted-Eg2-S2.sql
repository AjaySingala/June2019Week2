--In session2, there won't be any delay in execution because in session1 table 
-- is used under transaction but it is not used update or delete command hence 
-- table is not locked.

-- Session #2
set transaction isolation level read committed
select * from Salaries
