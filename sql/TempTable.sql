CREATE PROCEDURE ProcTemp 
AS
BEGIN
CREATE TABLE #EmpDetails ( id int primary key, name varchar(50))
INSERT INTO #EmpDetails VALUES ( 01, 'Lalit'), ( 02, 'Atharva');
SELECT * FROM #EmpDetails;
END

exec ProcTemp

CREATE TABLE #EmpDetails ( id int primary key, name varchar(50));
INSERT INTO #EmpDetails VALUES ( 01, 'Lalit'), ( 02, 'Atharva');
SELECT * FROM #EmpDetails;

exec uspGetBillOfMaterials @StartProductID = 893, @CheckDate = '2010-05-26 00:00:00.000';