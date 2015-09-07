--DROP DATABASE [Poliklinika]


CREATE DATABASE [Poliklinika]
GO

USE [Poliklinika]
GO

CREATE SCHEMA People
GO

CREATE SCHEMA Polik
GO

CREATE TABLE [People].[Towns]
(
	TownId int identity(2, 2)
	, TownName varchar(40) not null
	, constraint PK_Town primary key (TownId)
)

CREATE TABLE [People].[Streets]        
(
	StreetId int identity primary key
	, StreetName varchar(60) not null
)

CREATE TABLE [People].[Jobs]
(
	JobId int identity 
	, JobName varchar(200) not null
)

ALTER TABLE [People].[Jobs]
ADD CONSTRAINT PK_Jobs PRIMARY KEY (JobId)

--DROP TABLE [People].[Patients]
CREATE TABLE [People].[Patients]
(
	PatientId int identity primary key
	, PatientName varchar(50) not null
	, PatientSName varchar(60) not null
	, Birthday date default '01.01.1990'
	, TownIdRef int not null references [People].[Towns](TownId) --на яку таблицю ссилаємся і яке поле
	, StreetIdRef int not null references [People].[Streets](StreetId)
	, House varchar(10) 
	, Apartments varchar(10)  
	, JobIdRef int not null references [People].[Jobs](JobId) on delete cascade--foreighn key
)

--DROP TABLE [People].[Jobs]

--DML
INSERT INTO [People].[Towns] (TownName)
VALUES
('Rivne'),
('Kiev'),
('Lutsk')
GO

INSERT INTO [People].[Streets]
VALUES
('Shevchenka'),
('Bandery'),
('Lvivska')
GO

INSERT INTO [People].[Jobs]
VALUES
('NUVGP'),
('Azot'),
('Step')
GO


INSERT INTO [People].[Patients] (PatientName, PatientSName, Birthday, TownIdRef, StreetIdRef, House, Apartments,JobIdRef)
VALUES
('Tom', 'Kerry', '01.01.1950', 2, 1,'20a', null, 2)


INSERT INTO [People].[Patients] 
VALUES
('Renata', 'Kerry', '01.01.1955', 2, 1,'20a', null, 1)


INSERT INTO [People].[Patients] (PatientName,  Birthday, PatientSName, TownIdRef, StreetIdRef, House, Apartments,JobIdRef)
VALUES
('Peter',  '01.01.1950', 'Perror',2, 1,'20', '44', 2)

INSERT INTO [People].[Patients] (PatientName,  PatientSName, TownIdRef, StreetIdRef,JobIdRef)
VALUES
('Dima',  'Dmutrenko',4, 1, 2)

UPDATE [People].[Patients]
SET Birthday = '12.12.1986'
WHERE PatientId=5

UPDATE [People].[Patients]
SET Birthday = '12.12.1900'
WHERE PatientSName='Kerry'




SELECT * FROM [People].[Towns]
SELECT * FROM [People].[Streets]
SELECT * FROM [People].[Jobs]
SELECT * FROM [People].[Patients]


SELECT * FROM [People].[Patients]
WHERE PatientSName= 'Kerry' AND PatientName LIKE 'T%' --OR , NOT NULL, 

SELECT * FROM [People].[Patients]
WHERE PatientSName != 'Kerry'