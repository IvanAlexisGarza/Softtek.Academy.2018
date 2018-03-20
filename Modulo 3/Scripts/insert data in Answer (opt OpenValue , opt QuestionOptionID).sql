--12
--insert data in Answer (opt OpenValue , opt QuestionOptionID)
-- Open Question = 3
--**************************************
use [Survey]
go

create procedure uspInsert2Answer
(
	@Insert varchar(50),
	@QOPID int,
	@QID varchar (50)
)
as

insert into Answers(QuestionId, OpenValue, QuestionOptionId)
Values(@QID, @QOPID,@Insert )

go

--**************************************
exec uspInsert2Answer 4,2,2
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

alter procedure [dbo].[uspInsert2Answer]
(
	@Insert varchar(50),
	@QOPID int,
	@QID varchar (50)
)
as
begin transaction

begin try
	insert into Answers(QuestionId, OpenValue, QuestionOptionId)
	Values(@QID, @QOPID,@Insert )
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
exec uspInsert2Answer 4,2,2
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