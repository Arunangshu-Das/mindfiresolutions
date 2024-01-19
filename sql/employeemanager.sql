select * from manager_employee_relation;
select 25-count(*) as totalRecord from manager_employee_relation where mgrid is NULL;
select min(salary) as MIN_SALARY_IN_COMPANY from employee;
select max(salary) as MAX_SALARY_IN_COMPANY from employee;
select mgr.name as manager, client.name as client 
from employee as mgr 
inner join manager_employee_relation mer on mgr.id=mer.mgrid
inner join employee as client on client.id=mer.clientid
select name from employee where age between 40 and 45;
select name, desg from employee where name like '[a-f]%' order by name desc,desg asc;
select * from employee;
select * from employee_60;
select * from employee;
create table employee_60 (id int, name varchar(50), age int, salary int, desg varchar(50));
insert into employee_60 select * from employee where salary>60000;
