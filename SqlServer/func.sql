

use adventureworksdb;
GO


create view Person.vw_FullName
AS
Select (firstname + coalesce(middleName, '') + lastname) as fml
FROM Person.Person;