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