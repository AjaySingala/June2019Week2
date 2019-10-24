--An INSTEAD OF trigger is a trigger that allows you to skip an INSERT,
-- DELETE, or UPDATE statement to a table or a view and execute other
-- statements defined in the trigger instead. The actual insert, delete, or
-- update operation does not occur at all.
-- In other words, an INSTEAD OF trigger skips a DML statement and execute
-- other statements.

CREATE TRIGGER production.trg_vw_brands 
ON production.vw_brands
INSTEAD OF INSERT
AS
BEGIN
	-- Statements
END
