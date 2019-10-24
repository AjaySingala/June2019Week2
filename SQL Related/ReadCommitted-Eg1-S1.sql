DROP TABLE [dbo].[Salaries]
GO

CREATE TABLE [dbo].[Salaries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [decimal](18, 2) NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_Salaries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

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
