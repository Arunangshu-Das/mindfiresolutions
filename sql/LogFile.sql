CREATE TABLE logtable (
    LogId int IDENTITY(1,1) primary key,
    LogName varchar(1900),
    Date DateTime
);

drop table log_table

select * from logtable;