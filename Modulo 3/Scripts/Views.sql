--Views

alter view [dbo].[vw_DeviceStore]
as
select St.Name as Store, Dev.Name as Device, dev.Description, Co.Name as color, Si.Price, Si.Quantity
from dbo.Device as Dev 
inner join  dbo.color as Co on Co.ColorId = Dev.ColorId 
inner join dbo.StoreInventory as SI on SI.deviceId = Dev.DeviceId
inner join dbo.Store as St on St.StoreId = SI.StoreId
go

select * from [dbo].[vw_DeviceStore] where store <> 'BestBuy'
