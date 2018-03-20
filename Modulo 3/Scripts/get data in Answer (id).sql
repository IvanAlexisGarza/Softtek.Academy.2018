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