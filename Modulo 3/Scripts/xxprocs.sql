use [inventory]
go
create proc uspGetDeviceNames

begin
	select Name from [dbo].[Device]
	go




	/*



	*/
	------------------------------------------------
	--------------------------------------------

use [inventory]
go
alter proc uspGetDeviceByDescription
(
	@Description nvarchar(50) = null
)
as
	select * from [dbo].[Device]
	where Description like '%' + @Description + '%'
	go

	--**************************************************
	exec uspGetDeviceByDescription 

	-------------------------------------------------------------
	-----------------------------------------------------
/*****************************************************************************/
use [inventory]
go
create proc uspGetDeviceByDescription
(
	@Description nvarchar(50) = null
)
as
	select * from [dbo].[Device]
	where Description like '%' + @Description + '%'
	go
--****************************************************************************
	exec uspGetDeviceByDescription 'ap'




