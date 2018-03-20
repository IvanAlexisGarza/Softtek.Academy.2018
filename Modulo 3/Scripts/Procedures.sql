/* Ejercicios */

/********************************************/*
/*
*	Ivan Alexis Garza Tapia
*	1/26/2018
*	Ejercicios de SQL academia
*/
--*******************************************
--1
--Insert data into option text
use [Survey]
go

create procedure InsertOption
(
	@insert varchar (50) 
)
as
insert into options (text)
values( @insert)
go
--**************************************
exec InsertOption 'Twitter'
--**************************************


--2
--Insert data into QuestionType Text
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

--3
--Get Data in Option
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

--4
--Get Data in QuestionType
--**************************************
use [Survey]
go

create procedure GetQuestionTypes

as
select * 
from QuestionTypes
go
--**************************************
exec GetQuestionTypes
--**************************************


--5
--Update data in option (id, text)
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


--6
--Update data in QuestionType (id, text)
--**************************************
use [survey]
go

create procedure UpdateQuestionType
(
	@index int,
	@insert varchar(50)
)
as

update QuestionTypes
set Description = @insert
where QuestionTypes.QuestionTypeId = @index
go
--**************************************
exec UpdateQuestionType  1, 'Mistake'
--**************************************


--7
--Erase data in Option (id)
--**************************************
use [Survey]
go

create procedure DeleteOption
(
	@Index int
)
as

delete Options
where @Index = OptionId
go

--**************************************
exec DeleteOption 1



--8
--Erase data in QuestionType (id)
--**************************************
use [Survey]
go

create procedure DeleteQuestionType
(
	@Index int
)
as

delete QuestionTypes
where @Index = QuestionTypeId
go

--**************************************
exec DeleteQuestionType 1


--9
--Insert data into question (Text, TypeId)
--**************************************
use [Survey]
go

create procedure InsertQuestion
(
	@Insert varchar (50),
	@Type int
)
as

insert into Questions(QuestionTypeId, Text)
Values (@Type, @Insert)
go

--**************************************
exec InsertQuestion @Insert = 'Wich one is the one?', @Type = 2


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


--11
--get all data in Question and their options (by questionID)
--**************************************
use [Survey]
go

create procedure uspGetQuestionOptions
(
	@QID int
)
as

select qu.Text as 'Question', op.Text as 'Assigned Options'
from Questions qu
inner join QuestionOptions qo on qo.QuestionId = @QID
inner join Options op on op.OptionId = qo.OptionId
go

--**************************************
exec uspGetQuestionOptions 4
--**************************************



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



--13
--get data in Answer (id)
--**************************************
use [Survey]
go

create procedure uspGetAnswers
(
	@AID int
)
as

select *
from Answers
where AnswerId = @AID
go

--*************************************
exec uspGetAnswers 1
--*************************************



--14
--all data in Question and their Answers (by questionID)
--**************************************
use [Survey]
go

create procedure GetQuestionAnswers
(
	@QID int
)
as

select qu.Text, an.OpenValue, an.OptionId
from Questions qu
inner join Answers an on an.QuestionId = qu.QuestionId
go

--*************************************
exec GetQuestionAnswers 1
--*************************************
