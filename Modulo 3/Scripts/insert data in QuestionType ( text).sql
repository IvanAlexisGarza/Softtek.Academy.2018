--2
--insert data in QuestionType ( text)
--**************************************

use [Survey]
go

create procedure InsertQuestionType
(
	@insert varchar (50) 
)
as
insert into QuestionTypes(Description)
values( @insert)
go
--**************************************
exec InsertQuestionType 'Open Question'
exec InsertQuestionType 'Single Option Question'
exec InsertQuestionType 'Multiple Option Question'
--*******************************************


--Moded with try catch for errors
-- Ivan Alexis Garza
-- 1/29/2018
use [Survey]
go

set ANSI_NULLS on
go

set QUOTED_IDENTIFIER on 
go

alter procedure [dbo].[InsertQuestionType]
(
	@insert varchar (50) 
)
as
begin transaction

begin try
	insert into QuestionTypes(Description)
	values( @insert)
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
exec InsertQuestionType 'Open Question'
exec InsertQuestionType 'Single Option Question'
exec InsertQuestionType 'Multiple Option Question'
--*******************************************


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