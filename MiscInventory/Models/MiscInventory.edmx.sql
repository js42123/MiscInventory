
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/08/2018 13:13:34
-- Generated from EDMX file: c:\users\js42123\documents\visual studio 2012\Projects\MiscInventory\MiscInventory\Models\MiscInventory.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MISC_INVENTORY];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[T115_MISC_INVENTORY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T115_MISC_INVENTORY];
GO
IF OBJECT_ID(N'[dbo].[T115_MISC_TRAN_ARCHV]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T115_MISC_TRAN_ARCHV];
GO
IF OBJECT_ID(N'[dbo].[T115_MISC_TRANS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T115_MISC_TRANS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'T115_MISC_INVENTORY'
CREATE TABLE [dbo].[T115_MISC_INVENTORY] (
    [INV_TYPE] char(1)  NOT NULL,
    [DELETE_FLAG] char(1)  NOT NULL,
    [ID_R] char(16)  NOT NULL,
    [INV_DESC] char(24)  NOT NULL,
    [BUD] char(3)  NOT NULL,
    [SERIAL_NO] char(16)  NOT NULL,
    [REPLC_SERIAL_NO] char(16)  NOT NULL,
    [LOC] char(5)  NOT NULL,
    [SUB_LOC] char(3)  NOT NULL,
    [PURCH_YY] char(4)  NOT NULL,
    [PURCH_MM] char(2)  NOT NULL,
    [DOC_DATE] datetime  NULL,
    [COST] decimal(11,2)  NOT NULL,
    [DEPR] decimal(11,2)  NOT NULL,
    [FEDID] char(1)  NOT NULL,
    [SUB_TYPE] char(1)  NOT NULL,
    [REQ_NO] char(6)  NOT NULL,
    [VCHR_NO] char(5)  NOT NULL,
    [MANUFAC_MODL_NO] char(15)  NOT NULL,
    [MANUFAC_NAME] char(58)  NOT NULL,
    [COMMENT] char(63)  NOT NULL,
    [UT_VCHR_NO] char(5)  NOT NULL,
    [T115_MISC_INVENTORY_PRIMARY_KEY] varchar(17)  NOT NULL,
    [VALUE_STATUS] char(1)  NOT NULL
);
GO

-- Creating table 'T115_MISC_TRAN_ARCHV'
CREATE TABLE [dbo].[T115_MISC_TRAN_ARCHV] (
    [TRANS] char(1)  NOT NULL,
    [INV_TYPE] char(1)  NOT NULL,
    [INV_DATE] datetime  NULL,
    [INV_TIME] time  NULL,
    [TRANS_USERID] char(7)  NOT NULL,
    [ID_R] char(16)  NOT NULL,
    [INV_DESC] char(24)  NOT NULL,
    [BUD] char(3)  NOT NULL,
    [SERIAL_NO] char(16)  NOT NULL,
    [REPLC_SERIAL_NO] char(16)  NOT NULL,
    [LOC] char(5)  NOT NULL,
    [SUB_LOC] char(3)  NOT NULL,
    [PURCH_YY] char(4)  NOT NULL,
    [PURCH_MM] char(2)  NOT NULL,
    [DOC_DATE] datetime  NULL,
    [COST] decimal(11,2)  NOT NULL,
    [DEPR] decimal(11,2)  NOT NULL,
    [FEDID] char(1)  NOT NULL,
    [SUB_TYPE] char(1)  NOT NULL,
    [REQ_NO] char(6)  NOT NULL,
    [VCHR_NO] char(5)  NOT NULL,
    [MANUFAC_MODL_NO] char(15)  NOT NULL,
    [MANUFAC_NAME] char(58)  NOT NULL,
    [COMMENT] char(68)  NOT NULL,
    [T115_MISC_TRAN_ARCHV_PRIMARY_KEY] varchar(34)  NOT NULL,
    [VALUE_STATUS] char(1)  NOT NULL,
    [T115_MISC_INVENTORYT115_MISC_INVENTORY_PRIMARY_KEY] varchar(17)  NOT NULL
);
GO

-- Creating table 'T115_MISC_TRANS'
CREATE TABLE [dbo].[T115_MISC_TRANS] (
    [TRANS] char(1)  NOT NULL,
    [INV_TYPE] char(1)  NOT NULL,
    [INV_DATE] datetime  NULL,
    [INV_TIME] time  NULL,
    [TRANS_USERID] char(7)  NOT NULL,
    [ID_R] char(16)  NOT NULL,
    [INV_DESC] char(24)  NOT NULL,
    [BUD] char(3)  NOT NULL,
    [SERIAL_NO] char(16)  NOT NULL,
    [REPLC_SERIAL_NO] char(16)  NOT NULL,
    [LOC] char(5)  NOT NULL,
    [SUB_LOC] char(3)  NOT NULL,
    [PURCH_YY] char(4)  NOT NULL,
    [PURCH_MM] char(2)  NOT NULL,
    [DOC_DATE] datetime  NULL,
    [COST] decimal(11,2)  NOT NULL,
    [DEPR] decimal(11,2)  NOT NULL,
    [FEDID] char(1)  NOT NULL,
    [SUB_TYPE] char(1)  NOT NULL,
    [REQ_NO] char(6)  NOT NULL,
    [VCHR_NO] char(5)  NOT NULL,
    [MANUFAC_MODL_NO] char(15)  NOT NULL,
    [MANUFAC_NAME] char(58)  NOT NULL,
    [COMMENT] char(63)  NOT NULL,
    [UT_VCHR_NO] char(5)  NOT NULL,
    [T115_MISC_TRANS_PRIMARY_KEY] varchar(34)  NOT NULL,
    [VALUE_STATUS] char(1)  NOT NULL,
    [T115_MISC_INVENTORYT115_MISC_INVENTORY_PRIMARY_KEY] varchar(17)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [T115_MISC_INVENTORY_PRIMARY_KEY] in table 'T115_MISC_INVENTORY'
ALTER TABLE [dbo].[T115_MISC_INVENTORY]
ADD CONSTRAINT [PK_T115_MISC_INVENTORY]
    PRIMARY KEY CLUSTERED ([T115_MISC_INVENTORY_PRIMARY_KEY] ASC);
GO

-- Creating primary key on [T115_MISC_TRAN_ARCHV_PRIMARY_KEY] in table 'T115_MISC_TRAN_ARCHV'
ALTER TABLE [dbo].[T115_MISC_TRAN_ARCHV]
ADD CONSTRAINT [PK_T115_MISC_TRAN_ARCHV]
    PRIMARY KEY CLUSTERED ([T115_MISC_TRAN_ARCHV_PRIMARY_KEY] ASC);
GO

-- Creating primary key on [T115_MISC_TRANS_PRIMARY_KEY] in table 'T115_MISC_TRANS'
ALTER TABLE [dbo].[T115_MISC_TRANS]
ADD CONSTRAINT [PK_T115_MISC_TRANS]
    PRIMARY KEY CLUSTERED ([T115_MISC_TRANS_PRIMARY_KEY] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [T115_MISC_INVENTORYT115_MISC_INVENTORY_PRIMARY_KEY] in table 'T115_MISC_TRAN_ARCHV'
ALTER TABLE [dbo].[T115_MISC_TRAN_ARCHV]
ADD CONSTRAINT [FK_T115_MISC_INVENTORYT115_MISC_TRAN_ARCHV]
    FOREIGN KEY ([T115_MISC_INVENTORYT115_MISC_INVENTORY_PRIMARY_KEY])
    REFERENCES [dbo].[T115_MISC_INVENTORY]
        ([T115_MISC_INVENTORY_PRIMARY_KEY])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_T115_MISC_INVENTORYT115_MISC_TRAN_ARCHV'
CREATE INDEX [IX_FK_T115_MISC_INVENTORYT115_MISC_TRAN_ARCHV]
ON [dbo].[T115_MISC_TRAN_ARCHV]
    ([T115_MISC_INVENTORYT115_MISC_INVENTORY_PRIMARY_KEY]);
GO

-- Creating foreign key on [T115_MISC_INVENTORYT115_MISC_INVENTORY_PRIMARY_KEY] in table 'T115_MISC_TRANS'
ALTER TABLE [dbo].[T115_MISC_TRANS]
ADD CONSTRAINT [FK_T115_MISC_INVENTORYT115_MISC_TRANS]
    FOREIGN KEY ([T115_MISC_INVENTORYT115_MISC_INVENTORY_PRIMARY_KEY])
    REFERENCES [dbo].[T115_MISC_INVENTORY]
        ([T115_MISC_INVENTORY_PRIMARY_KEY])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_T115_MISC_INVENTORYT115_MISC_TRANS'
CREATE INDEX [IX_FK_T115_MISC_INVENTORYT115_MISC_TRANS]
ON [dbo].[T115_MISC_TRANS]
    ([T115_MISC_INVENTORYT115_MISC_INVENTORY_PRIMARY_KEY]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------