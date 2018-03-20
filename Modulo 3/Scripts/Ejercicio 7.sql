--With a JOB
SELECT        dbo.Person.Names as NAME,  dbo.Person.LastName AS LASTNAME, dbo.State.Name AS STATE, dbo.Job.Title AS JOB
FROM            dbo.EmployedPersons INNER JOIN
                         dbo.Job ON dbo.EmployedPersons.JobId = dbo.Job.JobId INNER JOIN
                         dbo.Person ON dbo.EmployedPersons.PersonId = dbo.Person.PersonId INNER JOIN
                         dbo.State ON dbo.Person.StateId = dbo.State.StateId


--Without a JOB
select		p.Names, p.LastName
from		Person p
				inner join State as s on p.StateId = s.StateId
				left join EmployedPersons as ep on ep.PersonId = p.PersonId
				where ep.PersonId is null


--vista 1 Seleccionar nombre y numero de empleos
SELECT        dbo.Person.Names as NAME, COUNT(dbo.EmployedPersons.JobId) as [number of jobs]
FROM            dbo.EmployedPersons INNER JOIN
                         dbo.Job ON dbo.EmployedPersons.JobId = dbo.Job.JobId INNER JOIN
                         dbo.Person ON dbo.EmployedPersons.PersonId = dbo.Person.PersonId INNER JOIN
                         dbo.State ON dbo.Person.StateId = dbo.State.StateId
						 group by dbo.Person.Names
						 order by COUNT(dbo.EmployedPersons.JobId)

--Vista 2 vw_PersonaEstado muestra nombre persona, edad y nombre estado
SELECT        dbo.Person.Names, dbo.Person.LastName, dbo.State.Name, dbo.Person.Age
FROM            dbo.Person INNER JOIN
                         dbo.State ON dbo.Person.StateId = dbo.State.StateId

--Vista 3 mostrar estado y edad promerdio
SELECT        AVG(age) as [Average Age], dbo.State.Name
FROM            dbo.Person 
				INNER JOIN dbo.State ON dbo.Person.StateId = dbo.State.StateId
				group by dbo.State.Name








