
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/17/2021 16:00:08
-- Generated from EDMX file: C:\Users\Perker\Documents\GitHub\PROJECTWEBi\BAYILERSATISPROJESI\BAYILERSATISPROJESI\Models\PROJE.edmx
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

IF OBJECT_ID(N'[dbo].[BayilerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BayilerSet];
GO
IF OBJECT_ID(N'[dbo].[urunSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[urunSet];
GO
IF OBJECT_ID(N'[dbo].[UsersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BayilerSets'
CREATE TABLE [dbo].[BayilerSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ulke] nvarchar(max)  NOT NULL,
    [Sehir] nvarchar(max)  NOT NULL,
    [BayiId] int  NOT NULL,
    [Sifre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'urunSets'
CREATE TABLE [dbo].[urunSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Isim] nvarchar(max)  NOT NULL,
    [Fiyat] decimal(18,0)  NOT NULL,
    [StokAdeti] int  NOT NULL,
    [Resim] nvarchar(max)  NULL,
    [Aciklama] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersSets'
CREATE TABLE [dbo].[UsersSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KullaniciAdi] nvarchar(max)  NOT NULL,
    [Sifre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Siparislers'
CREATE TABLE [dbo].[Siparislers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BayiId] int  NOT NULL,
    [UrunId] int  NOT NULL,
    [Tarih] datetime  NOT NULL,
    [Tutar] decimal  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BayilerSets'
ALTER TABLE [dbo].[BayilerSets]
ADD CONSTRAINT [PK_BayilerSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'urunSets'
ALTER TABLE [dbo].[urunSets]
ADD CONSTRAINT [PK_urunSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersSets'
ALTER TABLE [dbo].[UsersSets]
ADD CONSTRAINT [PK_UsersSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Siparislers'
ALTER TABLE [dbo].[Siparislers]
ADD CONSTRAINT [PK_Siparislers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------