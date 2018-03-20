--3
-- get all data in Option
--**************************************
use [Survey]
go

create procedure GetOptions

as
select * 
from Options
go
--**************************************
exec GetOptions
--**************************************