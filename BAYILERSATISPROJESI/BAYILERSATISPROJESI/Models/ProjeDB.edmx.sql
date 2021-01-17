
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/16/2021 21:26:20
-- Generated from EDMX file: C:\Users\Perker\Documents\GitHub\PROJECTWEBI\BAYILERSATISPROJESI\BAYILERSATISPROJESI\Models\ProjeDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PROJE];
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

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KullaniciAdi] nvarchar(max)  NOT NULL,
    [Sifre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BayilerSet'
CREATE TABLE [dbo].[BayilerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ulke] nvarchar(max)  NOT NULL,
    [Sehir] nvarchar(max)  NOT NULL,
    [BayiId] int  NOT NULL,
    [Sifre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'urunSet'
CREATE TABLE [dbo].[urunSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Isim] nvarchar(max)  NOT NULL,
    [Fiyat] decimal  NOT NULL,
    [StokAdeti] int  NOT NULL,
    [Resim] nvarchar(max)  NULL,
    [Aciklama] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BayilerSet'
ALTER TABLE [dbo].[BayilerSet]
ADD CONSTRAINT [PK_BayilerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'urunSet'
ALTER TABLE [dbo].[urunSet]
ADD CONSTRAINT [PK_urunSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------