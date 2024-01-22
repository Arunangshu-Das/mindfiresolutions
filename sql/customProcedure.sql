create procedure getStudentNameAndAllCourseCustom @ids varchar(50), @delimiter varchar(20)
AS
begin
	declare @mytable table(value varchar(50));
	insert into @mytable (Value) SELECT trim(value) as value from splitstring(@ids,@delimiter);
	select e.id, e.name from employee e join @mytable m on m.value=e.id;
end

exec getStudentNameAndAllCourseCustom @ids= '1,&2,&24' , @delimiter= ',&' ;



