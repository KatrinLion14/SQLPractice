use University

insert into Department values
('Linguistics', 105, 'Straight Street 1', '+7(111)1111111'),
('Philosophy', 207, 'Straight Street 3', '+7(222)2222222'),
('Mathematics', 302, 'Straight Street 1', '+7(333)3333333'),
('Software Engineering', 206, 'Straight Street 10', '+7(444)4444444'),
('Psychology', 105, 'Straight Street 3', '+7(555)5555555')

insert into Professor values
('professor1@gmail.com', 'Иванов Иван Иванович', 'French', 'Linguistics'),
('professor2@gmail.com', 'Петров Петр Иванович', 'German', 'Linguistics'),
('professor3@gmail.com', 'Иванов Сергей Владимирович', 'Ethics', 'Philosophy'),
('professor4@gmail.com', 'Сидорова Мария Максимовна', 'Linear Algebra', 'Mathematics'),
('professor5@gmail.com', 'Попов Алексей Эдуардович', 'Databases', 'Software Engineering'),
('professor6@gmail.com', 'Кузнецова Марина Олеговна', 'Artificial Intelligence', 'Software Engineering'),
('professor7@gmail.com', 'Васильев Александр Петрович', 'Clinical Psychology', 'Psychology')

insert into StudentGroup values
('19ПИ-1', 'group1@gmail.com', 'professor6@gmail.com'),
('19ПИ-2', 'group2@gmail.com', 'professor6@gmail.com'),
('19ФИПЛ-1', 'group3@gmail.com', 'professor1@gmail.com'),
('19ФИПЛ-2', 'group4@gmail.com', 'professor2@gmail.com'),
('19М', 'group5@gmail.com', 'professor4@gmail.com'),
('18П', 'group6@gmail.com', 'professor7@gmail.com'),
('21Ф', 'group7@gmail.com', 'professor3@gmail.com')

insert into Student values
('Козловский Максим Михайлович', 'student1@gmail.com', '19ПИ-1'),
('Баженов Иван Станиславович', 'student2@gmail.com', '19ПИ-1'),
('Новиков Матвей Ильич', 'student3@gmail.com', '19ПИ-2'),
('Кузьмин Тимур Родионович', 'student4@gmail.com', '19ФИПЛ-1'),
('Соколов Владимир Иванович', 'student5@gmail.com', '19ФИПЛ-2'),
('Пономарева Алиса Андреевна', 'student6@gmail.com', '19М'),
('Ефимова Николь Марковна', 'student7@gmail.com', '18П'),
('Парамонова Виктория Данииловна', 'student8@gmail.com', '21Ф'),
('Кузнецова Анна Ильинична', 'student9@gmail.com', '21Ф'),
('Ковалева Амира Арсентьевна', 'student10@gmail.com', '19ПИ-2')

select * from Department
select * from Professor
select * from StudentGroup
select * from Student

select * from Student where GroupId like '19%'
select Name from Student where Name like '%Ко%'
select top(1) Name, Addres from Department where Addres like 'Straight Street 1'
select * from StudentGroup where Name like '19%' order by Name asc
select distinct ProfessorEmail from StudentGroup

update top(1) Department set Office = 101 where Addres like 'Straight Street 1'
update top(1) Professor set Email = 'professor1@yandex.ru' where DepartmentName like 'Linguistics'

delete top(1) from Professor where Name like 'Попов Алексей Эдуардович'

select ProfessorEmail, count(*) as Count from StudentGroup group by ProfessorEmail
select Addres, count(*) as Count from Department group by Addres
select Addres, max(Office) as MaxOffice from Department group by Addres

select ProfessorEmail, count(*) as Count from StudentGroup group by ProfessorEmail having count(*) > 1
select Addres, max(Office) as MaxOffice from Department group by Addres having count(*) >= 2
select GroupId as 'Group', count(*) as StudentCount from Student group by GroupId having count(*) >= 2

select s.Name, s.Email as 'Student Email', s.GroupId as 'Group Name', g.Email as 'Group Email'
from Student s join StudentGroup g on s.GroupId = g.Name
select g.Name as 'Group Name', g.Email as 'Group Email', p.Name, p.Subject, p.DepartmentName as 'Department', p.Email
from Professor p join StudentGroup g on p.Email = g.ProfessorEmail
