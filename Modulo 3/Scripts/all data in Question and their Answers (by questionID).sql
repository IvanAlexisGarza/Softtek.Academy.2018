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