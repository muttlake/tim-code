

create database foodrankerdb;
GO

use  foodrankerdb;

select * from dbo.Users;
select * from dbo.FoodTypes;

delete
from dbo.FoodTypes
where FoodTypeID = 3;

