/*
* 1/30/2018
* Ivan Alexis Garza Tapia
* Softtek dotnet Academy - Module 3 Final Test
* Manually insert the first tree table rows
*/
--1
insert into ItemInfo 
values(
	'Read Harry Potter', 
	'Finish reading the first harry potter book to my kids' ,
	2 ,
	5 ,
	0 ,
	CONVERT (date, GETDATE()), 
	CONVERT (date, GETDATE()), 
	'2019-12-31')

--2
insert into ItemInfo 
values('Write film script', 
	'Start writing for the avengers age of Josue Fan fiction movie.',  
	1,
	1, 
	1,
	CONVERT (date, GETDATE()), 
	CONVERT (date, GETDATE()) , 
	'2018-02-01')

--3
insert into ItemInfo 
values('Ace Academy', 
	'Demonstrate my computer skills to achieve the ultime honor, work at softtek',
	4,
	2, 
	0,
	CONVERT (date, GETDATE()), 
	CONVERT (date, GETDATE()) , 
	'2018-02-01')