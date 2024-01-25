IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[student]') AND type in (N'U'))

BEGIN 
	create table student (id int primary key identity(1,1), name varchar(100), email varchar(50), salary varchar(50)) 
end