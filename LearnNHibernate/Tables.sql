drop table Orders
drop table Users
drop table UserTypes
go

create table UserTypes
(
	Number int not null primary key clustered,
	Name varchar(32) not null,
)
go

create table Users
(
	Number int identity not null primary key clustered,
	UserTypeNumber int not null foreign key references UserTypes,
	Name nvarchar(128) not null,
)
go

create table Orders
(
	Number int identity not null primary key clustered,
	Cost int not null,
	ProductName nvarchar(1000) not null,
	SaleDateAndTime datetime2 not null,
	UserNumber int not null foreign key references Users,
)
go