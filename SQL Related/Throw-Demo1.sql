--Syntax:
--THROW [ { error_number | @local_variable },  
--        { message | @local_variable },  
--        { state | @local_variable } ]   
--[ ; ] 

--Arguments
--error_number:
--Is a constant or variable that represents the exception. error_number is int and 
-- must be greater than or equal to 50000 and less than or equal to 2147483647.
--message:
--Is an string or variable that describes the exception. message is nvarchar(2048).
--state:
--Is a constant or variable between 0 and 255 that indicates the state to associate with the message. 
-- state is tinyint.

--Differences Between RAISERROR and THROW
--The following table lists differences between the RAISERROR and THROW statements.
--RAISERROR statement															THROW statement
--If a msg_id is passed to RAISERROR, the ID must be defined in sys.messages.	The error_number parameter does not have to be defined in sys.messages.
--The msg_str parameter can contain printf formatting styles.					The message parameter does not accept printf style formatting.
--The severity parameter specifies the severity of the exception.				There is no severity parameter. The exception severity is always set to 16.

THROW 51000, 'The record does not exist.', 1;  

--Using THROW to raise an exception again:
--CREATE TABLE dbo.TestRethrow  
--(    ID INT PRIMARY KEY  
--);  
--BEGIN TRY  
--    INSERT dbo.TestRethrow(ID) VALUES(1);  
----  Force error 2627, Violation of PRIMARY KEY constraint to be raised.  
--    INSERT dbo.TestRethrow(ID) VALUES(1);  
--END TRY  
--BEGIN CATCH  
  
--    PRINT 'In catch block.';  
--    THROW;  
--END CATCH;  
