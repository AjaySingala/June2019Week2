-- Syntax for SQL Server:  
--RAISERROR ( { msg_id | msg_str | @local_variable }  
--    { ,severity ,state }  
--    [ ,argument [ ,...n ] ] )  
--    [ WITH option [ ,...n ] ]  

--option
--Is a custom option for the error and can be one of the values in the following table.
--Value		Description
--LOG		Logs the error in the error log and the application log for the instance 
--			of the Microsoft SQL Server Database Engine. Errors logged in the error log are currently limited to a maximum of 440 bytes. Only a member of the sysadmin fixed server role or a user with ALTER TRACE permissions can specify WITH LOG.
--NOWAIT	Sends messages immediately to the client.
--SETERROR	Sets the @@ERROR and ERROR_NUMBER values to msg_id or 50000, 
--			regardless of the severity level.



RAISERROR (15600,-1,-1, 'mysp_CreateCustomer'); 

--RAISERROR (N'This is message %s %d.', -- Message text.  
--           10, -- Severity,  
--           1, -- State,  
--           N'number', -- First argument.  
--           5); -- Second argument.  
---- The message text returned is: This is message number 5.  
GO  
