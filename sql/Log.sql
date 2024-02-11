create table usernote (id int primary key IDENTITY(1,1), noteid varchar(100), note varchar(1000), notetype varchar(1000), datetimes datetime);



select * from usernote

SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY [note] asc) AS RowNum, * FROM [usernote] WHERE notetype='contact') AS Temp WHERE notetype='contact' and RowNum BETWEEN 0 AND 3