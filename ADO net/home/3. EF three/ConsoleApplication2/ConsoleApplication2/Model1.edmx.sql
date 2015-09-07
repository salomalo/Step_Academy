
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/03/2015 21:46:33
-- Generated from EDMX file: E:\Databases\ConsoleApplication2\ConsoleApplication2\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [very_new];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomersTypeCustomers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomersSet] DROP CONSTRAINT [FK_CustomersTypeCustomers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CustomersTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomersTypeSet];
GO
IF OBJECT_ID(N'[dbo].[CustomersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomersSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CustomersTypeSet'
CREATE TABLE [dbo].[CustomersTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(64)  NOT NULL
);
GO

-- Creating table 'CustomersSet'
CREATE TABLE [dbo].[CustomersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [CustomersTypeId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CustomersTypeSet'
ALTER TABLE [dbo].[CustomersTypeSet]
ADD CONSTRAINT [PK_CustomersTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomersSet'
ALTER TABLE [dbo].[CustomersSet]
ADD CONSTRAINT [PK_CustomersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomersTypeId] in table 'CustomersSet'
ALTER TABLE [dbo].[CustomersSet]
ADD CONSTRAINT [FK_CustomersTypeCustomers]
    FOREIGN KEY ([CustomersTypeId])
    REFERENCES [dbo].[CustomersTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomersTypeCustomers'
CREATE INDEX [IX_FK_CustomersTypeCustomers]
ON [dbo].[CustomersSet]
    ([CustomersTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------