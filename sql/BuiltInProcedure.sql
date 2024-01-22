create procedure getStudentNameAndAllCourse @ids varchar(50), @delimiter varchar(20)
AS
begin
	declare @mytable table(value varchar(50));
	insert into @mytable (Value) SELECT trim(value) as value from STRING_SPLIT(replace(@ids,@delimiter,','),',');
	select e.id, e.name from employee e join @mytable m on m.value=e.id;
end

exec getStudentNameAndAllCourse @ids= "1,&2,&24" , @delimiter= ",&" ;

SELECT value as value from STRING_SPLIT(replace('a,&b,&c',',&',','),',');

