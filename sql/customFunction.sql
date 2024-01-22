create function splitstring(@inputstring varchar(90), @delimiter varchar(90)) returns @table table(value varchar(200))
as 
begin
 declare @dposition int
 declare @value varchar(50)
 while charindex(@delimiter,@inputstring)>0
 begin
	select @dposition = charindex(@delimiter,@inputstring)
	select @value = substring(@inputstring,1,@dposition-1)
	insert into @table (value) values (@value)
	select @inputstring = substring(@inputstring,@dposition+len(@delimiter),len(@inputstring))
  end
  insert into @table (value) values (@inputstring)
  return 
end;

select * from splitstring('a,b,c',',');

SELECT 
SUBSTRING('a,b,c', 1, 1) result;

select charindex(',','a,b,c')
