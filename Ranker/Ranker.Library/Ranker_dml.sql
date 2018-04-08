

create database rankerdb;
GO

use  rankerdb;

select * from dbo.Users;
select * from dbo.FoodTypes;

delete
from dbo.FoodTypes
where FoodTypeID = 3;

