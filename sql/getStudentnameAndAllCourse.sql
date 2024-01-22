USE [DemoDB]
GO
/****** Object:  StoredProcedure [dbo].[getStudentNameAndAllCourse]    Script Date: 22-01-2024 12:36:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[getStudentNameAndAllCourse] @ids varchar(50), @delimiter varchar(20)
AS
begin
	declare @mytable table(value varchar(50));
	insert into @mytable (Value) SELECT trim(value) as value from STRING_SPLIT(replace(@ids,@delimiter,','),',');
	select e.id, e.name from employee e join @mytable m on m.value=e.id;
end