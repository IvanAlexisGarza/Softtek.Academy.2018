--Functions
/****************************************************/

create function svfReverseName(@string varchar(100))
returns varchar(100)
as 
begin
declare @Name varchar(100)
set @Name = REVERSE(@string)
return @name
end

select [dbo].[svfReverseName](Name) as reversed, Description
from Device
GO


create function tvfProductsCostingMoreThan(@Cost money)
returns table
as 
return
select Dev.Name, Dev.Description, Si.Price, Si.Quantity
from Device Dev
inner join StoreInventory Si on Si.DeviceId = Dev.DeviceId
where Price > @Cost

select* from [dbo].[tvfProductsCostingMoreThan](5000) 
	--where name = 'tv'
go

select* from [dbo].[tvfProductsCostingMoreThan](1000) 
	--where name = 'tv'
go

