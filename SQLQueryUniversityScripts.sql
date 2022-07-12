use University

insert into Department values
('Linguistics', 105, 'Straight Street 1', '+7(111)1111111'),
('Philosophy', 207, 'Straight Street 3', '+7(222)2222222'),
('Mathematics', 302, 'Straight Street 1', '+7(333)3333333'),
('Software Engineering', 206, 'Straight Street 10', '+7(444)4444444'),
('Psychology', 105, 'Straight Street 3', '+7(555)5555555')

insert into Professor values
('professor1@gmail.com', '������ ���� ��������', 'French', 'Linguistics'),
('professor2@gmail.com', '������ ���� ��������', 'German', 'Linguistics'),
('professor3@gmail.com', '������ ������ ������������', 'Ethics', 'Philosophy'),
('professor4@gmail.com', '�������� ����� ����������', 'Linear Algebra', 'Mathematics'),
('professor5@gmail.com', '����� ������� ����������', 'Databases', 'Software Engineering'),
('professor6@gmail.com', '��������� ������ ��������', 'Artificial Intelligence', 'Software Engineering'),
('professor7@gmail.com', '�������� ��������� ��������', 'Clinical Psychology', 'Psychology')

insert into StudentGroup values
('19��-1', 'group1@gmail.com', 'professor6@gmail.com'),
('19��-2', 'group2@gmail.com', 'professor6@gmail.com'),
('19����-1', 'group3@gmail.com', 'professor1@gmail.com'),
('19����-2', 'group4@gmail.com', 'professor2@gmail.com'),
('19�', 'group5@gmail.com', 'professor4@gmail.com'),
('18�', 'group6@gmail.com', 'professor7@gmail.com'),
('21�', 'group7@gmail.com', 'professor3@gmail.com')

insert into Student values
('���������� ������ ����������', 'student1@gmail.com', '19��-1'),
('������� ���� �������������', 'student2@gmail.com', '19��-1'),
('������� ������ �����', 'student3@gmail.com', '19��-2'),
('������� ����� ����������', 'student4@gmail.com', '19����-1'),
('������� �������� ��������', 'student5@gmail.com', '19����-2'),
('���������� ����� ���������', 'student6@gmail.com', '19�'),
('������� ������ ��������', 'student7@gmail.com', '18�'),
('���������� �������� ����������', 'student8@gmail.com', '21�'),
('��������� ���� ���������', 'student9@gmail.com', '21�'),
('�������� ����� �����������', 'student10@gmail.com', '19��-2')

select * from Department
select * from Professor
select * from StudentGroup
select * from Student

select * from Student where GroupId like '19%'
select Name from Student where Name like '%��%'
select top(1) Name, Addres from Department where Addres like 'Straight Street 1'
select * from StudentGroup where Name like '19%' order by Name asc
select distinct ProfessorEmail from StudentGroup

update top(1) Department set Office = 101 where Addres like 'Straight Street 1'
update top(1) Professor set Email = 'professor1@yandex.ru' where DepartmentName like 'Linguistics'

delete top(1) from Professor where Name like '����� ������� ����������'

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