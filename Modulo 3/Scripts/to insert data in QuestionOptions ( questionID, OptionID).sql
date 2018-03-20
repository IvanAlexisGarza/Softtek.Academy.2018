--10
--to insert data in QuestionOptions ( questionID, OptionID)
--**************************************
use [Survey]
go

create procedure uspInsertQuestionOption
(
	@OID int,
	@QID int
)
as

insert into QuestionOptions(OptionId, QuestionId)
Values (@OID, @QID)
go

--**************************************
exec uspInsertQuestionOption 2, 4
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

alter procedure [dbo].[uspInsertQuestionOption]
(
	@OID int,
	@QID int
)
as
begin transaction

begin try
	insert into QuestionOptions(OptionId, QuestionId)
	Values (@OID, @QID)
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
exec uspInsertQuestionOption 2, 4
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