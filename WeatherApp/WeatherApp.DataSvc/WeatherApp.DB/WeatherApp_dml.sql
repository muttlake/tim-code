

create database weatherappdb;
GO

use  weatherappdb;

select * from [dbo].Users;

select * from [dbo].Posts;


delete
from [dbo].Posts
--where PostID = 190;

delete
from [dbo].Users
where UserID = 38;

update [dbo].Posts
set WeatherJson = '{"coord":{"lon":-95.37,"lat":32.21},"weather":[{"id":800,"main":"Clear","description":"clear sky","icon":"01n"}],"base":"stations","main":{"temp":286.49,"pressure":1016,"humidity":58,"temp_min":285.15,"temp_max":287.15},"visibility":16093,"wind":{"speed":2.6,"deg":300},"clouds":{"all":1},"dt":1523751300,"sys":{"type":1,"id":2632,"message":0.0039,"country":"US","sunrise":1523793141,"sunset":1523839863},"id":420034734,"name":"Tyler","cod":200}';



select distinct WeatherType
From [dbo].Posts;








