--4
--all data in QuestionType
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