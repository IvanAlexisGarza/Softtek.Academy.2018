use [inventory]
go

set ANSI_NULLS on
go

set QUOTED_IDENTIFIER on 
go

alter procedure [dbo].[uspTryCatchTest]
as
begin transaction

begin try
	insert into color values ('Block', '#334455')
	select 1/0
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


exec [uspTryCatchTest]

/***************************************************************************/
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

/*
* add transaction blocks and try catch the survey stored procedures
*/
