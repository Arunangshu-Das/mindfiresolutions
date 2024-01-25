Insert into student values('arunangshu', 'a@gmail.com', '20000');

select * from student;

with cte as (select row_number() over (
	partition by name, email, salary order by id desc
	) as RowNum from student
)
delete from cte where RowNum>1;