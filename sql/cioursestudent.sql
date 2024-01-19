create table student (sid int primary key, sname varchar(50));
create table courses(cid int primary key, cname varchar(50));
create table stduentandcourse(cid int,sid int, constraint pk primary key (cid, sid));

ALTER TABLE stduentandcourse
ADD CONSTRAINT FK_sid
FOREIGN KEY (sid) REFERENCES student(sid);

ALTER TABLE stduentandcourse
ADD CONSTRAINT FK_cid
FOREIGN KEY (cid) REFERENCES courses(cid);

INSERT INTO Student (sid, sname)
VALUES
  (1, 'John Doe'),
  (2, 'Jane Smith'),
  (3, 'Alice Johnson'),
  (4, 'Robert Brown'),
  (5, 'Emily White'),
  (6, 'Michael Davis'),
  (7, 'Sophia Miller'),
  (8, 'David Wilson'),
  (9, 'Olivia Taylor'),
  (10, 'William Moore'),
  (11, 'Emma Lee'),
  (12, 'Christopher Hall'),
  (13, 'Ella Harris'),
  (14, 'Matthew Robinson'),
  (15, 'Ava Clark');

INSERT INTO courses(cid, cname)
VALUES
  (1, 'Hindi'),
  (2, 'English'),
  (3, 'Bengali'),
  (4, 'CS'),
  (5, 'Blockchain');

INSERT INTO stduentandcourse (sid, cid)
VALUES
  (1, 1), 
  (1, 3), 
  (1, 5),
  (2, 2), 
  (2, 4),
  (3, 1), 
  (3, 2), 
  (3, 3),
  (4, 4), 
  (4, 5),
  (5, 1), 
  (5, 3), 
  (5, 5),
  (6, 2),
  (7, 1), 
  (7, 4),
  (8, 3),
  (9, 1), 
  (9, 5),
  (10, 2), 
  (10, 4),
  (11, 1), 
  (11, 2), 
  (11, 3),
  (12, 4),
  (13, 5),
  (14, 1), 
  (14, 3),
  (15, 2), 
  (15, 5);

select s.sname, STRING_AGG(c.cname,',') as courses from student s inner join stduentandcourse sc on s.sid=sc.sid  inner join courses c on sc.cid=c.cid group by s.sname order by s.sname;

select s.sname, count(c.cname) as courses from student s inner join stduentandcourse sc on s.sid=sc.sid  inner join courses c on sc.cid=c.cid group by s.sname order by count(c.cname) desc;