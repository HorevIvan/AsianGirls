drop table Orders
drop table Users
drop table UserTypes
go

create table UserTypes
(
	Name varchar(32) not null primary key clustered,
)
go

create table Users
(
	Number int identity not null primary key clustered,
	UserTypeName varchar(32) not null foreign key references UserTypes,
	Name nvarchar(128) not null,
)
go

create table Orders
(
	Number int identity not null primary key clustered,
	Cost decimal(10,2) not null,
	ProductName nvarchar(1000) not null,
	SaleDateAndTime datetime2 not null,
	UserNumber int not null foreign key references Users,
)
go