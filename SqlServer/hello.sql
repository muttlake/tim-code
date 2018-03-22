exec msdb.dbo.rds_restore_database 
        @restore_db_name='adventureworksdb', 
        @s3_arn_to_restore_from='arn:aws:s3:::1803-mar12-net-44/AdventureWorks2017.bak';


USE adventureworksdb;
go 
select * from Person.Person;