
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/29/2014 01:32:33
-- Generated from EDMX file: C:\Users\Denis\Documents\Visual Studio 2013\Projects\LoLFight\Tim-814repo\Tim-814repo\LolFightProjekat\LolFightProjekat\Models\lolfightmodels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [lolfighdatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Champion__IdCham__182C9B23]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Champion] DROP CONSTRAINT [FK__Champion__IdCham__182C9B23];
GO
IF OBJECT_ID(N'[dbo].[FK__Ranking__IdRanki__31EC6D26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ranking] DROP CONSTRAINT [FK__Ranking__IdRanki__31EC6D26];
GO
IF OBJECT_ID(N'[dbo].[FK__Skill__IdSkill__34C8D9D1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Skill] DROP CONSTRAINT [FK__Skill__IdSkill__34C8D9D1];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AdminMail_dbo_Admin_IdAdmin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdminMail] DROP CONSTRAINT [FK_dbo_AdminMail_dbo_Admin_IdAdmin];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AdminMail_dbo_Champion_IdChampion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdminMail] DROP CONSTRAINT [FK_dbo_AdminMail_dbo_Champion_IdChampion];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Champion_dbo_ChampionType_IdChampionType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Champion] DROP CONSTRAINT [FK_dbo_Champion_dbo_ChampionType_IdChampionType];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Inventory_dbo_Champion_IdChampion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventory] DROP CONSTRAINT [FK_dbo_Inventory_dbo_Champion_IdChampion];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Inventory_dbo_Item_IdItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventory] DROP CONSTRAINT [FK_dbo_Inventory_dbo_Item_IdItem];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_LogBattle_IdAttacker_dbo_Champion_IdChampion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogBattle] DROP CONSTRAINT [FK_dbo_LogBattle_IdAttacker_dbo_Champion_IdChampion];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_LogBattle_IdDefender_dbo_Champion_IdChampion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogBattle] DROP CONSTRAINT [FK_dbo_LogBattle_IdDefender_dbo_Champion_IdChampion];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_LogBattle_IdWinner_dbo_Champion_IdChampion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogBattle] DROP CONSTRAINT [FK_dbo_LogBattle_IdWinner_dbo_Champion_IdChampion];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_LogFarm_dbo_Champion_IdChampion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogFarm] DROP CONSTRAINT [FK_dbo_LogFarm_dbo_Champion_IdChampion];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_LogJungle_dbo_Champion_IdChampion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogJungle] DROP CONSTRAINT [FK_dbo_LogJungle_dbo_Champion_IdChampion];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Mail_IdReceiver_dbo_Champion_IdChampion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mail] DROP CONSTRAINT [FK_dbo_Mail_IdReceiver_dbo_Champion_IdChampion];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Mail_IdSender_dbo_Champion_IdChampion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mail] DROP CONSTRAINT [FK_dbo_Mail_IdSender_dbo_Champion_IdChampion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Admin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admin];
GO
IF OBJECT_ID(N'[dbo].[AdminMail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminMail];
GO
IF OBJECT_ID(N'[dbo].[Champion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Champion];
GO
IF OBJECT_ID(N'[dbo].[ChampionType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChampionType];
GO
IF OBJECT_ID(N'[dbo].[Inventory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inventory];
GO
IF OBJECT_ID(N'[dbo].[Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item];
GO
IF OBJECT_ID(N'[dbo].[LogBattle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogBattle];
GO
IF OBJECT_ID(N'[dbo].[LogFarm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogFarm];
GO
IF OBJECT_ID(N'[dbo].[LogJungle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogJungle];
GO
IF OBJECT_ID(N'[dbo].[Mail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mail];
GO
IF OBJECT_ID(N'[dbo].[News]', 'U') IS NOT NULL
    DROP TABLE [dbo].[News];
GO
IF OBJECT_ID(N'[dbo].[Ranking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ranking];
GO
IF OBJECT_ID(N'[dbo].[Skill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Skill];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [IdAdmin] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(45)  NULL,
    [Password] nvarchar(45)  NULL,
    [eMail] nvarchar(200)  NULL,
    [ImageURL] varbinary(max)  NULL
);
GO

-- Creating table 'AdminMails'
CREATE TABLE [dbo].[AdminMails] (
    [IdAdminMail] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(45)  NULL,
    [Text] nvarchar(200)  NULL,
    [IdAdmin] int  NOT NULL,
    [IdChampion] int  NOT NULL
);
GO

-- Creating table 'Champions'
CREATE TABLE [dbo].[Champions] (
    [IdChampion] int  NOT NULL,
    [IdChampionType] int  NOT NULL,
    [Gold] int  NULL,
    [BanCooldown] int  NULL
);
GO

-- Creating table 'ChampionTypes'
CREATE TABLE [dbo].[ChampionTypes] (
    [IdChampionType] int IDENTITY(1,1) NOT NULL,
    [Nation] nvarchar(45)  NULL,
    [Name] nvarchar(45)  NULL,
    [ImageLink] nvarchar(500)  NULL,
    [HP] int  NULL,
    [AttackDamage] int  NULL,
    [AbilityDamage] int  NULL,
    [AttackSpeed] int  NULL,
    [Armor] int  NULL,
    [MagicResist] int  NULL,
    [ImageURL] varbinary(max)  NULL
);
GO

-- Creating table 'Inventories'
CREATE TABLE [dbo].[Inventories] (
    [IdInventory] int IDENTITY(1,1) NOT NULL,
    [IdChampion] int  NOT NULL,
    [IdItem] int  NOT NULL,
    [Activated] int  NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [IdItem] int IDENTITY(1,1) NOT NULL,
    [Price] int  NULL,
    [HP] int  NULL,
    [AttackDamage] int  NULL,
    [AbilityDamage] int  NULL,
    [AttackSpeed] int  NULL,
    [Armor] int  NULL,
    [MagicResist] int  NULL,
    [Critical] int  NULL,
    [ArmorPenetration] int  NULL,
    [MagicPenetration] int  NULL,
    [Heal] int  NULL,
    [ImageURL] varbinary(max)  NULL,
    [Name] nvarchar(100)  NULL
);
GO

-- Creating table 'LogBattles'
CREATE TABLE [dbo].[LogBattles] (
    [IdLogBattle] int IDENTITY(1,1) NOT NULL,
    [IdAttacker] int  NOT NULL,
    [IdDefender] int  NOT NULL,
    [StartTime] int  NULL,
    [Gold] int  NULL,
    [Report] nvarchar(200)  NULL,
    [IdWinner] int  NOT NULL
);
GO

-- Creating table 'LogFarms'
CREATE TABLE [dbo].[LogFarms] (
    [IdLogFarm] int IDENTITY(1,1) NOT NULL,
    [IdChampion] int  NOT NULL,
    [StartTime] int  NULL,
    [DailyRemaining] int  NULL,
    [Gold] int  NULL,
    [Report] nvarchar(200)  NULL
);
GO

-- Creating table 'LogJungles'
CREATE TABLE [dbo].[LogJungles] (
    [IdLogJungle] int IDENTITY(1,1) NOT NULL,
    [IdChampion] int  NOT NULL,
    [StartTime] int  NULL,
    [Duration] int  NULL,
    [Gold] int  NULL,
    [Report] nvarchar(200)  NULL
);
GO

-- Creating table 'Mails'
CREATE TABLE [dbo].[Mails] (
    [IdMail] int IDENTITY(1,1) NOT NULL,
    [IdSender] int  NOT NULL,
    [IdReceiver] int  NOT NULL,
    [Time] int  NULL,
    [Title] nvarchar(45)  NULL,
    [Text] nvarchar(200)  NULL
);
GO

-- Creating table 'Rankings'
CREATE TABLE [dbo].[Rankings] (
    [IdRanking] int  NOT NULL,
    [FarmGold] int  NULL,
    [StolenGold] int  NULL
);
GO

-- Creating table 'Skills'
CREATE TABLE [dbo].[Skills] (
    [IdSkill] int  NOT NULL,
    [HP] int  NULL,
    [AttackDamage] int  NULL,
    [AbilityDamage] int  NULL,
    [AttackSpeed] int  NULL,
    [Armor] int  NULL,
    [MagicResist] int  NULL,
    [Critical] int  NULL,
    [ArmorPenetration] int  NULL,
    [MagicPenetration] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [IdUser] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(45)  NULL,
    [Password] nvarchar(45)  NULL,
    [eMail] nvarchar(200)  NULL
);
GO

-- Creating table 'News'
CREATE TABLE [dbo].[News] (
    [IdNews] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Text] nvarchar(500)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAdmin] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([IdAdmin] ASC);
GO

-- Creating primary key on [IdAdminMail] in table 'AdminMails'
ALTER TABLE [dbo].[AdminMails]
ADD CONSTRAINT [PK_AdminMails]
    PRIMARY KEY CLUSTERED ([IdAdminMail] ASC);
GO

-- Creating primary key on [IdChampion] in table 'Champions'
ALTER TABLE [dbo].[Champions]
ADD CONSTRAINT [PK_Champions]
    PRIMARY KEY CLUSTERED ([IdChampion] ASC);
GO

-- Creating primary key on [IdChampionType] in table 'ChampionTypes'
ALTER TABLE [dbo].[ChampionTypes]
ADD CONSTRAINT [PK_ChampionTypes]
    PRIMARY KEY CLUSTERED ([IdChampionType] ASC);
GO

-- Creating primary key on [IdInventory] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [PK_Inventories]
    PRIMARY KEY CLUSTERED ([IdInventory] ASC);
GO

-- Creating primary key on [IdItem] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([IdItem] ASC);
GO

-- Creating primary key on [IdLogBattle] in table 'LogBattles'
ALTER TABLE [dbo].[LogBattles]
ADD CONSTRAINT [PK_LogBattles]
    PRIMARY KEY CLUSTERED ([IdLogBattle] ASC);
GO

-- Creating primary key on [IdLogFarm] in table 'LogFarms'
ALTER TABLE [dbo].[LogFarms]
ADD CONSTRAINT [PK_LogFarms]
    PRIMARY KEY CLUSTERED ([IdLogFarm] ASC);
GO

-- Creating primary key on [IdLogJungle] in table 'LogJungles'
ALTER TABLE [dbo].[LogJungles]
ADD CONSTRAINT [PK_LogJungles]
    PRIMARY KEY CLUSTERED ([IdLogJungle] ASC);
GO

-- Creating primary key on [IdMail] in table 'Mails'
ALTER TABLE [dbo].[Mails]
ADD CONSTRAINT [PK_Mails]
    PRIMARY KEY CLUSTERED ([IdMail] ASC);
GO

-- Creating primary key on [IdRanking] in table 'Rankings'
ALTER TABLE [dbo].[Rankings]
ADD CONSTRAINT [PK_Rankings]
    PRIMARY KEY CLUSTERED ([IdRanking] ASC);
GO

-- Creating primary key on [IdSkill] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [PK_Skills]
    PRIMARY KEY CLUSTERED ([IdSkill] ASC);
GO

-- Creating primary key on [IdUser] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([IdUser] ASC);
GO

-- Creating primary key on [IdNews] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [PK_News]
    PRIMARY KEY CLUSTERED ([IdNews] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdAdmin] in table 'AdminMails'
ALTER TABLE [dbo].[AdminMails]
ADD CONSTRAINT [FK_dbo_AdminMail_dbo_Admin_IdAdmin]
    FOREIGN KEY ([IdAdmin])
    REFERENCES [dbo].[Admins]
        ([IdAdmin])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AdminMail_dbo_Admin_IdAdmin'
CREATE INDEX [IX_FK_dbo_AdminMail_dbo_Admin_IdAdmin]
ON [dbo].[AdminMails]
    ([IdAdmin]);
GO

-- Creating foreign key on [IdChampion] in table 'AdminMails'
ALTER TABLE [dbo].[AdminMails]
ADD CONSTRAINT [FK_dbo_AdminMail_dbo_Champion_IdChampion]
    FOREIGN KEY ([IdChampion])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AdminMail_dbo_Champion_IdChampion'
CREATE INDEX [IX_FK_dbo_AdminMail_dbo_Champion_IdChampion]
ON [dbo].[AdminMails]
    ([IdChampion]);
GO

-- Creating foreign key on [IdChampion] in table 'Champions'
ALTER TABLE [dbo].[Champions]
ADD CONSTRAINT [FK__Champion__IdCham__182C9B23]
    FOREIGN KEY ([IdChampion])
    REFERENCES [dbo].[Users]
        ([IdUser])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdRanking] in table 'Rankings'
ALTER TABLE [dbo].[Rankings]
ADD CONSTRAINT [FK__Ranking__IdRanki__31EC6D26]
    FOREIGN KEY ([IdRanking])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdSkill] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [FK__Skill__IdSkill__34C8D9D1]
    FOREIGN KEY ([IdSkill])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdChampionType] in table 'Champions'
ALTER TABLE [dbo].[Champions]
ADD CONSTRAINT [FK_dbo_Champion_dbo_ChampionType_IdChampionType]
    FOREIGN KEY ([IdChampionType])
    REFERENCES [dbo].[ChampionTypes]
        ([IdChampionType])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Champion_dbo_ChampionType_IdChampionType'
CREATE INDEX [IX_FK_dbo_Champion_dbo_ChampionType_IdChampionType]
ON [dbo].[Champions]
    ([IdChampionType]);
GO

-- Creating foreign key on [IdChampion] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [FK_dbo_Inventory_dbo_Champion_IdChampion]
    FOREIGN KEY ([IdChampion])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Inventory_dbo_Champion_IdChampion'
CREATE INDEX [IX_FK_dbo_Inventory_dbo_Champion_IdChampion]
ON [dbo].[Inventories]
    ([IdChampion]);
GO

-- Creating foreign key on [IdAttacker] in table 'LogBattles'
ALTER TABLE [dbo].[LogBattles]
ADD CONSTRAINT [FK_dbo_LogBattle_IdAttacker_dbo_Champion_IdChampion]
    FOREIGN KEY ([IdAttacker])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_LogBattle_IdAttacker_dbo_Champion_IdChampion'
CREATE INDEX [IX_FK_dbo_LogBattle_IdAttacker_dbo_Champion_IdChampion]
ON [dbo].[LogBattles]
    ([IdAttacker]);
GO

-- Creating foreign key on [IdDefender] in table 'LogBattles'
ALTER TABLE [dbo].[LogBattles]
ADD CONSTRAINT [FK_dbo_LogBattle_IdDefender_dbo_Champion_IdChampion]
    FOREIGN KEY ([IdDefender])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_LogBattle_IdDefender_dbo_Champion_IdChampion'
CREATE INDEX [IX_FK_dbo_LogBattle_IdDefender_dbo_Champion_IdChampion]
ON [dbo].[LogBattles]
    ([IdDefender]);
GO

-- Creating foreign key on [IdWinner] in table 'LogBattles'
ALTER TABLE [dbo].[LogBattles]
ADD CONSTRAINT [FK_dbo_LogBattle_IdWinner_dbo_Champion_IdChampion]
    FOREIGN KEY ([IdWinner])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_LogBattle_IdWinner_dbo_Champion_IdChampion'
CREATE INDEX [IX_FK_dbo_LogBattle_IdWinner_dbo_Champion_IdChampion]
ON [dbo].[LogBattles]
    ([IdWinner]);
GO

-- Creating foreign key on [IdChampion] in table 'LogFarms'
ALTER TABLE [dbo].[LogFarms]
ADD CONSTRAINT [FK_dbo_LogFarm_dbo_Champion_IdChampion]
    FOREIGN KEY ([IdChampion])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_LogFarm_dbo_Champion_IdChampion'
CREATE INDEX [IX_FK_dbo_LogFarm_dbo_Champion_IdChampion]
ON [dbo].[LogFarms]
    ([IdChampion]);
GO

-- Creating foreign key on [IdChampion] in table 'LogJungles'
ALTER TABLE [dbo].[LogJungles]
ADD CONSTRAINT [FK_dbo_LogJungle_dbo_Champion_IdChampion]
    FOREIGN KEY ([IdChampion])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_LogJungle_dbo_Champion_IdChampion'
CREATE INDEX [IX_FK_dbo_LogJungle_dbo_Champion_IdChampion]
ON [dbo].[LogJungles]
    ([IdChampion]);
GO

-- Creating foreign key on [IdReceiver] in table 'Mails'
ALTER TABLE [dbo].[Mails]
ADD CONSTRAINT [FK_dbo_Mail_IdReceiver_dbo_Champion_IdChampion]
    FOREIGN KEY ([IdReceiver])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Mail_IdReceiver_dbo_Champion_IdChampion'
CREATE INDEX [IX_FK_dbo_Mail_IdReceiver_dbo_Champion_IdChampion]
ON [dbo].[Mails]
    ([IdReceiver]);
GO

-- Creating foreign key on [IdSender] in table 'Mails'
ALTER TABLE [dbo].[Mails]
ADD CONSTRAINT [FK_dbo_Mail_IdSender_dbo_Champion_IdChampion]
    FOREIGN KEY ([IdSender])
    REFERENCES [dbo].[Champions]
        ([IdChampion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Mail_IdSender_dbo_Champion_IdChampion'
CREATE INDEX [IX_FK_dbo_Mail_IdSender_dbo_Champion_IdChampion]
ON [dbo].[Mails]
    ([IdSender]);
GO

-- Creating foreign key on [IdItem] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [FK_dbo_Inventory_dbo_Item_IdItem]
    FOREIGN KEY ([IdItem])
    REFERENCES [dbo].[Items]
        ([IdItem])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Inventory_dbo_Item_IdItem'
CREATE INDEX [IX_FK_dbo_Inventory_dbo_Item_IdItem]
ON [dbo].[Inventories]
    ([IdItem]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------