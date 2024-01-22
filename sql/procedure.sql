create procedure getStudentNameAndAllCourse
AS
begin
	set nocount on
	select s.sname, STRING_AGG(c.cname,',') as courses 
	from student s 
		inner join stduentandcourse sc on s.sid=sc.sid  
		inner join courses c on sc.cid=c.cid 
	group by s.sname 
	order by s.sname
end;

exec getStudentNameAndAllCourse;

select * from employee;
set nocount on;
update employee set desg=NULL where id=5;

update employee set desg='he''l"lo' where id=5;
update employee set desg='he"l''lo' where id=5;


