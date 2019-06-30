DROP FUNCTION [dbo].[getFormattedDate]
GO

CREATE FUNCTION [dbo].[getFormattedDate]
 (
 @DateValue AS DATETIME
 )
RETURNS VARCHAR(MAX)
AS
BEGIN
	RETURN
	  DATENAME(DW, @DateValue)+ ', '+
	  DATENAME(DAY, @DateValue)+ ' '+
	  DATENAME(MONTH, @DateValue) +', '+
	  DATENAME(YEAR, @DateValue)
END
GO


