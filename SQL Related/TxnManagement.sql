BEGIN TRANSACTION;  
  
BEGIN TRY  
    -- Generate a constraint violation error.  
    DELETE FROM Departments  
    WHERE ID = 1;  
END TRY  
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  
  
    IF @@TRANCOUNT > 0  
	BEGIN
		SELECT 'Rolling back the transaction'
        ROLLBACK TRANSACTION;
	END  
END CATCH;  
  
IF @@TRANCOUNT > 0 
BEGIN
	SELECT 'Committing txn...' 
    COMMIT TRANSACTION;  
END
GO  
