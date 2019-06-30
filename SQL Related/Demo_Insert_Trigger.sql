--1) Create a table for logging the changes
--The following statement creates a table named production.product_audits to record 
-- information when an INSERT or DELETE event occurs against the production.products table:

DROP TABLE products;
CREATE TABLE products(
    product_id  INT IDENTITY PRIMARY KEY,
    product_name VARCHAR(255) NOT NULL
);

DROP TABLE product_audits;
CREATE TABLE product_audits(
    change_id INT IDENTITY PRIMARY KEY,
    product_id INT NOT NULL,
    product_name VARCHAR(255) NOT NULL,
    updated_at DATETIME NOT NULL,
    operation CHAR(3) NOT NULL,
    CHECK(operation = 'INS' or operation='DEL')
);

--2) Creating an after DML trigger

DROP TRIGGER trg_product_audit
CREATE TRIGGER trg_product_audit
ON products
AFTER INSERT, DELETE
AS
BEGIN
	-- set the SET NOCOUNT to ON to suppress the number of rows affected messages 
	-- from being returned whenever the trigger is fired
    SET NOCOUNT ON;

    INSERT INTO product_audits(
        product_id, 
        product_name, 
        updated_at, 
        operation
    )
    SELECT
        i.product_id,
        product_name,
        GETDATE(),
        'INS'
    FROM
        inserted i
    UNION ALL
    SELECT
        d.product_id,
        product_name,
        GETDATE(),
        'DEL'
    FROM
        deleted d;
END

-- 3) Testing the trigger
-- The following statement inserts a new row into the production.products table:
INSERT INTO products(
    product_name
)
VALUES (
    'Test product 3'
);

--Because of the DELETE event, the production.trg_product_audit trigger of 
-- production.products table was fired.
-- Let’s examine the contents of the production.product_audits table:
-- Shows a record with "INS" in audit.
SELECT 
    * 
FROM 
    product_audits;

--The following statement deletes a row from the production.products table:
DELETE FROM 
    products
WHERE 
    product_id = 2;
-- As expected, the trigger was fired and inserted the deleted row into the 
-- production.product_audits table:
-- Shows records with "INS" and "DEL" in audit.
SELECT 
    * 
FROM 
    product_audits;
