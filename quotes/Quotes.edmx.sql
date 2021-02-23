
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/22/2021 14:48:05
-- Generated from EDMX file: C:\Users\dschenck\source\repos\quotes\quotes\Quotes.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [quotesdatabase];
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

-- Creating table 'quotes'
CREATE TABLE [dbo].[quotes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [QuoteText] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'quotes'
ALTER TABLE [dbo].[quotes]
ADD CONSTRAINT [PK_quotes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------