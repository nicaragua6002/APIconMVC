
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/20/2024 20:54:40
-- Generated from EDMX file: C:\Users\spg-admin\source\repos\APIconMVC\Models\TallerAndroid.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TallerAndroidBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MallCustomers'
CREATE TABLE [dbo].[MallCustomers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Age] smallint  NOT NULL,
    [AnnualIncome] smallint  NOT NULL,
    [SpendingScore] smallint  NOT NULL
);
GO

-- Creating table 'Denuncias'
CREATE TABLE [dbo].[Denuncias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodCategoria] nvarchar(max)  NOT NULL,
    [Tipologia] nvarchar(max)  NOT NULL,
    [Departamento] nvarchar(max)  NOT NULL,
    [Cantidad] smallint  NOT NULL,
    [CasosResuelto] smallint  NOT NULL,
    [Annio] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MallCustomers'
ALTER TABLE [dbo].[MallCustomers]
ADD CONSTRAINT [PK_MallCustomers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Denuncias'
ALTER TABLE [dbo].[Denuncias]
ADD CONSTRAINT [PK_Denuncias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------