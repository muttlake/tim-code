

create database weatherappdb;
GO

use  weatherappdb;

select * from dbo.Users;

select * from dbo.Posts;

select * from dbo.Posts as p
where p.UserID = 4;




