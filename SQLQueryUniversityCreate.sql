use University

create table Department(
	Name nvarchar(100) constraint PK_Department primary key,
	Office int,
	Addres nvarchar(100),
	PhoneNumber nvarchar(14)
)

create table Professor(
	Email nvarchar(100) constraint PK_Professor primary key,
	Name nvarchar(100),
	Subject nvarchar(100),
	DepartmentName nvarchar(100) constraint FK_Department_Professor references Department(Name)
)

create table StudentGroup(
	Name nvarchar(100) constraint PK_StudentGroup primary key,
	Email nvarchar(100),
	ProfessorEmail nvarchar(100) constraint FK_StudentGroup_Professor references Professor(Email)
)

create table Student(
	Id int identity(1,1) constraint PK_Student primary key,
	Name nvarchar(100),
	Email nvarchar(100),
	GroupId nvarchar(100) constraint FK_Student_Group references StudentGroup(Name)
)