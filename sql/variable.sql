select * from HumanResources.Department

Declare @id int =5
print @id

SET @id = 15
print @id

declare @dates date =(select ModifiedDate from HumanResources.Department where Department.DepartmentID=5)
print @dates

Declare @@id int =5
print @@id

SET @@id = 15
print @@id

