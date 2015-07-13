CREATE DATABASE BS_3V
GO

USE BS_3V
GO

--Module 1
CREATE TABLE Categories
(
	  Id int identity
	, Name nvarchar(60) not null
	, ParentId int references Categories(Id)
	, isActive bit default 1
	, constraint PK_Category PRIMARY KEY (Id)
)

CREATE TABLE Producers
(
	  Id int identity
	, Name nvarchar(100) not null
	, Adress nvarchar(100) not null 
	, Phone nvarchar(60) not null
	, constraint PK_Producer PRIMARY KEY (Id)
)

CREATE TABLE Products
(
	Id int identity
	, Name nvarchar(80) not null
	, CategoryId int not null references Categories(Id)
	, ProducerId int not null references Producers(Id)
	, constraint PK_Product PRIMARY KEY (Id)
)

CREATE TABLE Measures
(
	Id int identity
	, Name nvarchar(50) not null
	, ShortName nvarchar(10) not null
	, constraint PK_Measure PRIMARY KEY (Id)
)

CREATE TABLE Packages
(
	Id int identity
	, ProductId int not null references Products(Id)
	, Volume numeric not null
	, VolumeMeasureId int not null references Measures(Id)
	, MeasureId int not null references Measures(Id)
	, constraint PK_Package PRIMARY KEY (Id)
)

CREATE TABLE Prices
(
	Id int identity
	, PackageId int not null references Packages(Id)
	, PriceTime datetime not null
	, UnitCost smallmoney not null
	, constraint PK_Price PRIMARY KEY (Id)
)


--Module 2
CREATE TABLE Customers
(
	Id int identity
	, Name nvarchar(100) not null
	, Adress nvarchar(100) not null
	, Phone nvarchar(60) not null	
	, constraint PK_Customer PRIMARY KEY (Id)
)

CREATE TABLE Statuses
(
	Id int identity
	, Name nvarchar(25) not null
	, constraint PK_Status PRIMARY KEY (Id)
)

CREATE TABLE InputOrders
(
	Id int identity
	, CustomerId int not null references Customers(Id)
	, CreationTime datetime not null
	, Cost smallmoney not null
	, StatusId int not null references Statuses(Id)
	, constraint PK_IO PRIMARY KEY (Id)
)

CREATE TABLE OutputOrders
(
	Id int identity
	, CustomerId int not null references Customers(Id)
	, CreationTime datetime not null
	, Cost smallmoney not null
	, StatusId int not null references Statuses(Id)
	, constraint PK_OO PRIMARY KEY (Id)
)

CREATE TABLE InputOrderItems
(
	Id int identity
	, InputOrderId int not null references InputOrders(Id)
	, PackageId int not null references Packages(Id)
	, Quantity numeric not null
	, UnitCost smallmoney not null
	, constraint PK_IOI PRIMARY KEY (Id)
)

CREATE TABLE OutputOrderItems
(
	Id int identity
	, OutputOrderId int not null references OutputOrders(Id)
	, PackageId int not null references Packages(Id)
	, Quantity numeric not null
	, UnitCost smallmoney not null
	, constraint PK_OOI PRIMARY KEY (Id)
)


--Module 3
CREATE TABLE WareHouses
(
	Id int identity
	, Adress nvarchar(100) not null
	, constraint PK_WareHouse PRIMARY KEY (Id)
)

CREATE TABLE WareHouseItems
(
	Id int identity
	, WareHouseId int not null references WareHouses(Id)
	, PackageId int not null references Packages(Id)
	, Quantity numeric not null
	, constraint PK_WHI PRIMARY KEY (Id)
)