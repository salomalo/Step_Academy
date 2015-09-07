USE [master]
GO

DROP DATABASE [DB_Shop_bud_mater]
GO

CREATE DATABASE [DB_Shop_bud_mater]
GO

USE [DB_Shop_bud_mater]
GO


CREATE TABLE [CustomersType]
(
Id int identity primary key
,Name nvarchar (512) not NULL
)

CREATE TABLE [Customers]
(
Id int identity primary key
,Name nvarchar (512) not NULL
,Address nvarchar (1024) not NULL
,Phone nvarchar (64) not NULL
,TypeId int references [CustomersType] (Id)
)

-----------------------

CREATE TABLE [Categorys]
(
Id int identity primary key
,Name nvarchar(512) not NULL
,ParentId int  references [Categorys] (Id)
)

CREATE TABLE [Producers]
(
Id int identity primary key
,Name nvarchar (512)
,Address nvarchar (1024)
,Phone nvarchar (64) not NULL
)

CREATE TABLE [Products]
(
Id int identity primary key
,Name nvarchar (512) not NULL
,ProducerId int  references [Producers] (Id)
,CategoryId int  references [Categorys] (Id)
)

---

CREATE TABLE [Measures]
(
Id int identity primary key
,Name nvarchar (128) not NULL
,SmallName nvarchar (16) not NULL
)

CREATE TABLE [Packeges]
(
Id int identity primary key
,ProductId int  references [Products] (Id)
,Volume int
,VolumeMeasureID int  references [Measures] (Id)
,MeasureID int  references [Measures] (Id)
)

CREATE TABLE [Prices]
(
Id int identity primary key
,PackegeId int  references [Packeges] (Id)
,PriceTime DATETIME
,UnitCost NUMERIC
)

-------

CREATE TABLE [Status]
(
Id int identity primary key
,Name  nvarchar (512) not NULL
)

--

CREATE TABLE [OutputOrders]
(
Id int identity primary key
,CustumerId int  references [Customers] (Id)
,CreationTime DATETIME
,Cost NUMERIC
,Status int references [Status] (Id)
)


CREATE TABLE [OutputOrderItem]
(
Id int identity primary key
,OutputOrderId int  references [OutputOrders] (Id)
,PackegeId int  references [Packeges] (Id)
,Quantity NUMERIC
,UnitCost NUMERIC
)

--

CREATE TABLE [InputOrders]
(
Id int identity primary key
,CustumerId int  references [Customers] (Id)
,CreationTime DATETIME
,Cost NUMERIC
,Status int references [Status] (Id)
)

CREATE TABLE [InputOrderItem]
(
Id int identity primary key
,InputOrderId int  references [InputOrders] (Id)
,PackegeId int  references [Packeges] (Id)
,Quantity NUMERIC
,UnitCost NUMERIC
)

---

CREATE TABLE [Warehouses]
(
Id int identity primary key
,Address nvarchar (1024) not NULL
)

CREATE TABLE [WarehouseItem]
(
Id int identity primary key
,WarehousId int  references [Warehouses] (Id)
,PackegeId int  references [Packeges] (Id)
,Quantity NUMERIC
)

-----------------  INSERT  -------------------------------------

INSERT INTO [CustomersType](Name)
VALUES
('ФОП')
,('Юридична особа')


INSERT INTO Customers ( Name, Address,Phone, TypeId)
VALUES
('Хороша фірма','Англія',123456,1)
,('Прекрасна фабрика','Іспанія',767676,1)
,('Кольорова фірма','Україна',565656,2)

INSERT INTO [Producers] (Name,Address,Phone)
VALUES
('Світляшка','Китай',546778)
,('Відкривашка','Італія',646773)
,('Завод металу','Польща',595899)
,('шка',NULL,546778)
,('new producers',NULL,007009)


INSERT INTO [Measures] (Name,SmallName)
VALUES
('Метри','м')
,('Кілограми','кг')
,('Літри','л')
,('Штуки','шт')
,('Упаковка','уп')


INSERT INTO Status (Name)
VALUES
('reject')
,('pending')
,('approved')

--

SET IDENTITY_INSERT Categorys ON
INSERT INTO [Categorys] (Id,Name,ParentId)
VALUES
(1,'Вікна', NULL)
,(2,'Підвіконня',1)
,(3,'Відливи',1)
,(4,'Метал',NULL)
,(5,'Огорожі',4)
,(6,'Труби',4)
,(7,'Покрівля',NULL)
,(8,'Шифер',7)
,(9,'Черепиця',7)
,(10,'Бетонні вироби',NULL)
,(11,'Цегла',10)
,(12,'Колодязі',10)
,(13,'Кріплення',NULL)
,(14,'Цвяхи',13)
,(15,'Гайки',13)
,(16,'Будівельні суміші',NULL)
,(17,'Цемент',16)
,(18,'Гіпс',16)
,(19,'Дерево',NULL)
,(20,'Рейки',19)
,(21,'Брус',19)
,(22,'Ізоляційні матеріали',NULL)
,(23,'Вата',22)
,(24,'Пінопласт',22)
,(25,'Сайдинг',NULL)
,(26,'Сайдинг base',25)
,(27,'Профілі для сайдингу',25)
,(28,'Системи водостоків',NULL)
,(29,'Системи водостоків base',28)
,(30,'Системи водовідведення',28)
,(31,'Полікарбонат',NULL)
,(32,'Полікарбонат',31)
,(33,'Профілі',31)
SET IDENTITY_INSERT Categorys OFF

--

INSERT INTO [Products] (Name,ProducerId,CategoryId)
VALUES
('Підвіконня пластикове Brilliant 6000х200 мм білий',1,2)
,('Підвіконня пластикове Brilliant 6000х400 мм мармур',1,2)
,('Підвіконня пластикове Brilliant 6000х400 мм дуб',1,2)
,('Відлив оцинкований 140х2000 мм',1,3)
,('Відлив віконний з полімерним покриттям 160х2000 мм',1,3)
,('Відлив віконний ПВХ 200х1500мм',1,3)
,('Ворота металеві Fijo 180x400 см чорні',1,5)
,('Грати віконні Альтмет 160x150 см',1,5)
,('Хвіртка металева Fijo 180x90 cм чорна',1,5)
,('Труба профільна 20х20х2 мм 2 м',1,6)
,('Труба профільна 50х50х2 мм 2 м',1,6)
,('Труба зварна ДУ 20х2.5 мм 2 м',1,6)
,('Шифер 8 хвиль 1750x1150x5',2,8)
,('Шифер 9 хвиль 1850x1250x5',2,8)
,('Шифер 10 хвиль 1950x1350x5',2,8)
,('Черепиця бітумна Фінська Соната 3 м.кв зелена',2,9)
,('Металочерепиця Європрофіль 1190x2125 мм коричнева',2,9)
,('Черепиця бітумна Фінська Соната 3 м.кв червона',2,9)
,('Цегла Клінкерам Онікс',1,11)
,('Цегла Євротон керамічна облицювальна червоний',1,11)
,('Цегла Фагот мармурова 60 жовта',1,11)
,('Люк для колодязів зелений',1,12)
,('Єврокільце для колодязів КС 10.9',1,12)
,('Днище колодязя ПН-10',1,12)
,('Цвяхи будівельні Expert DIN1151 1.2x20 мм оцинковані 0.5 кг',1,14)
,('Цвяхи столярні Expert DIN1152 1.2x20 мм обміднені 0.25 кг',1,14)
,('Цвяхи будівельні Expert DIN1151 2.2x50 мм без покриття 1 кг',1,14)
,('Гайка DIN 934 М 6 оцинкована 1 кг',1,15)
,('Гайка шестигранна DIN 934 М 12 оцинкована',1,15)
,('Гайка шестигранна ковпачкова DIN 1587 М 8 оцинкована 4 шт',1,15)
,('Цемент ПЦ I 500 25 кг Подільський цемент',1,17)
,('Цемент ПЦ II/АШ-400 25 кг',1,17)
,('Цемент білий Adana 25 кг',1,17)
,('Гіпс будівельний Арістей 20 кг',1,18)
,('Гіпс будівельний white 30 кг',1,18)
,('Гіпс будівельний black 50 кг',1,18)
,('Рейка монтажна 15x28 мм 3 м',1,20)
,('Рейка монтажна 30x40 мм 2 м 80502508',1,20)
,('Рейка монтажна цільна 40x50 мм 3 м 4 шт',1,20)
,('Брус будівельний 50x50 мм 2 м сухий',1,21)
,('Брус будівельний Дебо 15x15 мм 2.5 м',1,21)
,('Брус будівельний Ліра 50x100 мм 2 м',1,21)
,('Ізоляція Ursa Geo M-11 звукозахист',3,23)
,('Ізоляція Termolife Фасад 100 мм',3,23)
,('Ізоляція Rockwool РокСлаб Акустик 50 мм',3,23)
,('Пінопласт ПСБ-С-35 1000-500-20',2,24)
,('Пінопласт ПСБ-С-25 1000x500x100 мм',2,24)
,('Пінопласт ПСБ-С-25 1000х500х100 мм BauGut',3,24)
,('Панель стельова Alta-Profil 270x3000 мм біла',3,26)
,('Панель софіт Bryza 4х0.31 м коричнева',3,26)
,('Панель стельова Bryza 310х4000 мм біла',3,26)
,('Профіль J Bryza 4 м білий',3,27)
,('Кут BlockHouse внутрішній 3.05 м бежевий',3,27)
,('Профіль J 3.66 м коричневий',3,27)
,('Муфта ринви Bryza 125 мм зелена',3,29)
,('Кут внутрішній Bryza 125 мм зелений',3,29)
,('Труба водостічна Bryza 90x3000 мм зелена',3,29)
,('Лоток водовідвідний з решіткою PolyMax Basic ЛВ-10.16.12-ПП 1 м',3,30)
,('Канал водовідвідний ACO Self Hexaline 319200 1 м',3,30)
,('Решітка композитна ACO 319251 0.5 м',3,30)
,('Лист полікарбонатний сотовий 6H 3000x1050x6 мм прозорий',3,32)
,('Лист полікарбонатний сотовий ug-Standart Plastik 3000x1050x8 мм зелений',3,32)
,('Лист полікарбонатний сотовий 4H 2000x1050 бронзовий',3,32)
,('Профіль для зєднання H 4 мм 3000 мм',3,33)
,('Профіль торцевий алюмінієвий 8017 6 мм 2100 мм',3,33)
,('Профіль для зєднання ПСН-6 6000 мм',3,33)
,('pinoplast cool',NULL,22)

----------

INSERT INTO [Packeges] (ProductId,Volume, VolumeMeasureID, MeasureID  )
VALUES
(1,1,4,4)
,(2,1,4,4)
,(3,1,4,4)
,(4,1,4,4)
,(5,1,4,4)
,(6,1,4,4)
,(7,1,4,4)
,(8,1,4,4)
,(9,1,4,4)
,(10,1,4,4)
,(11,1,4,4)
,(12,1,4,4)
,(13,1 ,4 , 4)
,(14, 1,4 ,4 )
,(15,1 ,4 ,4 )
,(16, 1, 5,5)
,(17, 1,5 ,5)
,(18,1 ,5 ,5)
,(19,1000,4,4)
,(20,1000,4,4)
,(21,1000,4,4)
,(22,1,4,4)
,(23,1,4,4)
,(24,1,4,4)
,(25,0.5,2,2)
,(26,0.25,2,2)
,(27,0.5,2,2)
,(28,1,2,2)
,(29,20,4,4)
,(30,1,2,2)
,(31,25,2,2)
,(32,25,2,2)
,(33,25,2,2)
,(34,1,5,5)
,(35,1,5,5)
,(36,1,5,5)
,(37,1,4,4)
,(38,1,4,4)
,(39,1,4,4)
,(40,1,4,4)
,(41,1,4,4)
,(42,1,4,4)
,(43,1,4,4)
,(44,1,4,4)
,(45,1,4,4)
,(46,1,4,4)
,(47,1,4,4)
,(48,1,4,4)
,(49,1,4,4)
,(50,1,4,4)
,(51,1,4,4)
,(1,113,4,4)

-------- Price forech PACKAGE --------

INSERT INTO Prices ( PackegeId, PriceTime,UnitCost )
VALUES
(1,'10/02/2015',86.80)
,(2,'10/02/2014',108.85)
,(3,'10/02/2014',201.55)
,(4,'11/02/2014',56.10)
,(5,'09/02/2015',71)
,(6,'09/02/2015',100.15)
,(7,'08/02/2015',3090)
,(8,'10/02/2015',1414)
,(9,'11/02/2015',1290)
,(10,'11/02/2015',44.25)
,(11,'11/02/2015',46.25)
,(12,'11/02/2015',57.45)
,(13,'10/02/2015',109)
,(14,'10/02/2015',209)
,(15,'10/02/2015',309)
,(16,'11/02/2015',255)
,(17,'11/02/2015',169)
,(18,'11/02/2015',255)
,(19,'12/02/2015',7580)
,(20,'12/02/2015',8954)
,(21,'12/01/2015',9000)
,(22,'12/02/2015',415)
,(23,'12/02/2015',585)
,(24,'12/02/2015',499)
,(25,'12/02/2015',30.90)
,(26,'01/12/2015',83.40)
,(27,'10/12/2015',62.15)
,(28,'12/02/2015',80.05)
,(29,'11/02/2015',3)
,(30,'11/02/2015',100)
,(31,'05/02/2015',2)
,(32,'07/02/2015',2)
,(33,'08/02/2015',2)
,(34,'03/02/2015',35)
,(35,'07/02/2015',35)
,(36,'01/02/2015',35)
,(37,'02/02/2015',8.20)
,(38,'11/02/2015',10.20)
,(39,'11/02/2015',20.20)
,(40,'11/02/2015',20.20)
,(41,'11/02/2015',20.20)
,(42,'11/02/2015',20.20)
,(43,'11/02/2015',20.20)
,(44,'11/02/2015',20.20)
,(45,'11/02/2015',20.20)
,(46,'11/02/2015',20.20)
,(47,'11/02/2015',20.20)
,(48,'11/02/2015',20.20)
,(49,'11/02/2015',20.20)
,(50,'11/02/2015',20.20)
,(51,'11/02/2015',20.20)
,(52,'11/02/2015',NULL)

--------------  BUY - SALE  --------------

INSERT INTO OutputOrders ( CustumerId,CreationTime,Cost,Status)
VALUES
(1,'10/02/2015',453,1)
,(2,'11/02/2015',410,2)
,(3,'11/02/2015',564,3)
GO

INSERT INTO OutputOrderItem (OutputOrderId,PackegeId,Quantity,UnitCost)
VALUES
( 1, 1, 10, 860)
,( 1, 4, 10, 560)
,( 1, 5, 1, 71)
,( 2, 10, 2, 88.50)
,( 2, 11, 2, 92.50)
,( 2, 12, 1, 57.45)
,( 3, 1, 1 ,45)
,( 3, 12, 1 ,57.45)
,( 3, 4, 10 ,560)

---------------------------

INSERT INTO InputOrders ( CustumerId,CreationTime,Cost,Status)
VALUES
(1,'10.02.2015',453,1)
,(2,'11.02.2015',410,2)
,(3,'02.02.2015',564,3)


INSERT INTO InputOrderItem (InputOrderId,PackegeId,Quantity,UnitCost)
VALUES
( 1, 1, 10, 860.10)
,( 1, 4, 10, 560)
,( 1, 5, 1, 71)
,( 2, 10, 2, 88.50)
,( 2, 11, 2, 92.50)
,( 2, 12, 1, 57.45)
,( 3, 1, 1 ,45)
,( 3, 12, 1 ,57.45)
,( 3, 4, 10 ,560)


INSERT INTO Warehouses (Address)
values
('new addreses1')
,('good addreses2')
,('long addreses3')

INSERT INTO WarehouseItem (WarehousId,PackegeId,Quantity)
values
(1,1,2)
,(1,1,2)
,(2,1,2)
,(2,1,2)
,(3,1,2)
,(3,1,2)

