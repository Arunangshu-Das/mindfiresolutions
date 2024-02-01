CREATE PROCEDURE SelectAllCreditCard @CardType nvarchar(30)
AS
begin
SELECT * FROM sales.CreditCard WHERE CardType = @CardType
end

EXEC SelectAllCreditCard @CardType = 'Distinguish';

CREATE PROCEDURE SelectAllCreditCardCount
AS
begin
SELECT count(*) FROM sales.CreditCard group by CardType
end

Alter PROCEDURE SelectAllCreditCardCount
AS
begin
SELECT CardType, count(*) FROM sales.CreditCard group by CardType
end

exec SelectAllCreditCardCount;