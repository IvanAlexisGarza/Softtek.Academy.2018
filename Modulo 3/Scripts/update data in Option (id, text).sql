--5
--update data in Option (id, text)
--**************************************
use [survey]
go

create procedure UpdateOption
(
	@index int,
	@insert varchar(50)
)
as

update Options
set Text = @insert
where Options.OptionId = @index
go
--**************************************
exec UpdateOption  1, 'Mistake'
--**************************************


--Moded with try catch for errors
-- Ivan Alexis Garza
-- 1/29/2018
use [Survey]
go

set ANSI_NULLS on
go

set QUOTED_IDENTIFIER on 
go

alter procedure [dbo].[UpdateOption]
(
	@index int,
	@insert varchar(50)
)
as
begin transaction

begin try
	update Options
	set Text = @insert
	where Options.OptionId = @index
end try

begin catch
		execute GetError
		select @@TRANCOUNT as 'Transaction Count', 'Failed, need rollback' as 'Transaction location'
		if @@TRANCOUNT > 0
		ROLLBACK TRANSACTION
end catch

if @@TRANCOUNT > 0
	commit transaction;
go

--**************************************
exec UpdateOption  4, null
--**************************************


--USE [Survey]
--GO
--alter PROCEDURE GetError
--AS
---- Check the error code in a catch statement

--    SELECT ERROR_NUMBER() AS ErrorNumber
--     ,ERROR_SEVERITY() AS ErrorSeverity
--     ,ERROR_STATE() AS ErrorState
--     ,ERROR_PROCEDURE() AS ErrorProcedure
--     ,ERROR_LINE() AS ErrorLine
--     ,ERROR_MESSAGE() AS ErrorMessage;


--EXEC GetError