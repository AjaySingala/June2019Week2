SELECT * FROM Orders
SELECT * FROM OrderDetails

DECLARE @id AS int

INSERT INTO Orders(OrderDate, CustomerId)
VALUES ('2019-10-24', 8)

SELECT @id = @@IDENTITY
INSERT INTO OrderDetails(OrderId, ProductId, Quantity, Price)
VALUES(@id, 3, 2, 10.99)
