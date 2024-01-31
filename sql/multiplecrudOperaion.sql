-- Creating Student table
CREATE TABLE Student (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL
);

-- Creating Course table
CREATE TABLE Course (
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    CourseName VARCHAR(255) NOT NULL
);

-- Creating Class table with foreign keys
CREATE TABLE Class (
    ClassID INT IDENTITY(1,1) PRIMARY KEY,
    ClassName VARCHAR(255) NOT NULL,
);

create table StudentClass(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    ClassID INT FOREIGN KEY REFERENCES Class(ClassID),
)

create table CourseClass(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	CourseID INT FOREIGN KEY REFERENCES Course(CourseID),
    ClassID INT FOREIGN KEY REFERENCES Class(ClassID),
)

drop table Class, Course, Student;

select * from CourseClass;

SELECT CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='StudentClass';

alter table StudentClass drop constraint FK__StudentCl__Class__5629CD9C;

ALTER TABLE StudentClass
ADD CONSTRAINT FK_StudentID_Student
FOREIGN KEY (StudentID) REFERENCES Student(StudentID) on delete cascade;