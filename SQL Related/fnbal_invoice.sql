CREATE FUNCTION fnbal_invoice()  
RETURNS MONEY  
BEGIN  
RETURN(SELECT SUM(invoicetotal-paymenttotal-creadittotal)  
        FROM dbo.mcninvoices  
        WHERE invoicetotal-paymenttotal-creadittotal > 0 )  
END

-- Usage:
-- PRINT 'Outstanding balance of company is: ' + CONVERT(VARCHAR, dbo.fnbal_invoice(), 1)
