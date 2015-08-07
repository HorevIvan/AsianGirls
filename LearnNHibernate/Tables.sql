create table Customers
(
	Number int identity not null primary key clustered,
	Name nvarchar(128) not null,
)
go

create table Orders
(
	Number int identity not null primary key clustered,
	Cost decimal(10,2) not null,
	ProductName nvarchar(1000) not null,
	SaleDateAndTime datetime2 not null,
	CustomerNumber int not null foreign key references Customers,
)
go