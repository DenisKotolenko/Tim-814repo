CREATE TABLE [dbo].[Admin] ( 
    [IdAdmin] INT IDENTITY (1, 1) NOT NULL, 
    [Username] NVARCHAR (45) NULL, 
    [Password]  NVARCHAR (45) NULL, 
	[eMail]  NVARCHAR (200) NULL, 
    CONSTRAINT [PK_dbo.Admin] PRIMARY KEY CLUSTERED ([IdAdmin] ASC) 
);

CREATE TABLE [dbo].[User] ( 
    [IdUser] INT IDENTITY (1, 1) NOT NULL, 
    [Username] NVARCHAR (45) NULL, 
    [Password]  NVARCHAR (45) NULL, 
	[eMail]  NVARCHAR (200) NULL, 
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([IdUser] ASC) 
);

CREATE TABLE [dbo].[ChampionType] ( 
    [IdChampionType] INT IDENTITY (1, 1) NOT NULL,
    [Nation] NVARCHAR (45) NULL,
	[Name] NVARCHAR (45) NULL,
	[ImageLink] NVARCHAR (45) NULL,
	[HP] INT NULL, 
	[AttackDamage] INT NULL,
	[AbilityDamage] INT NULL,
	[AttackSpeed] INT NULL,
	[Armor] INT NULL,
    [MagicResist] INT NULL, 
    CONSTRAINT [PK_dbo.ChampionType] PRIMARY KEY CLUSTERED ([IdChampionType] ASC), 
);

CREATE TABLE [dbo].[Item] ( 
    [IdItem] INT IDENTITY (1, 1) NOT NULL,
	[Price] INT NULL,
	[HP] INT NULL, 
	[AttackDamage] INT NULL,
	[AbilityDamage] INT NULL,
	[AttackSpeed] INT NULL,
	[Armor] INT NULL,
    [MagicResist] INT NULL,
	[Critical] INT NULL,
	[ArmorPenetration] INT NULL,
	[MagicPenetration] INT NULL,
	[Heal] INT NULL,
    CONSTRAINT [PK_dbo.Item] PRIMARY KEY CLUSTERED ([IdItem] ASC), 
);

CREATE TABLE [dbo].[Champion] ( 
    [IdChampion] INT PRIMARY KEY FOREIGN KEY REFERENCES [User] (IdUser), 
	[IdChampionType] INT NOT NULL, 
	[Gold] INT NULL, 
    [BanCooldown] INT NULL,  
    CONSTRAINT [FK_dbo.Champion_dbo.ChampionType_IdChampionType] FOREIGN KEY([IdChampionType]) REFERENCES [dbo].[ChampionType] ([IdChampionType]) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE [dbo].[AdminMail] ( 
    [IdAdminMail] INT IDENTITY (1, 1) NOT NULL, 
    [Title] NVARCHAR (45) NULL, 
    [Text] NVARCHAR (200) NULL, 
	[IdAdmin] INT NOT NULL, 
    [IdChampion] INT NOT NULL, 
    CONSTRAINT [PK_dbo.AdminMail] PRIMARY KEY CLUSTERED ([IdAdminMail] ASC), 
    CONSTRAINT [FK_dbo.AdminMail_dbo.Admin_IdAdmin] FOREIGN KEY ([IdAdmin]) REFERENCES [dbo].[Admin] ([IdAdmin]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.AdminMail_dbo.Champion_IdChampion] FOREIGN KEY ([IdChampion]) REFERENCES [dbo].[Champion] ([IdChampion]) ON DELETE CASCADE ON UPDATE CASCADE  
); 

CREATE TABLE [dbo].[Inventory] ( 
    [IdInventory] INT IDENTITY (1, 1) NOT NULL,
	[IdChampion] INT NOT NULL,  
	[IdItem] INT NOT NULL, 
	[Activated] INT NULL, 
    CONSTRAINT [PK_dbo.Inventory] PRIMARY KEY CLUSTERED ([IdInventory] ASC), 
    CONSTRAINT [FK_dbo.Inventory_dbo.Champion_IdChampion] FOREIGN KEY ([IdChampion]) REFERENCES [dbo].[Champion] ([IdChampion]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.Inventory_dbo.Item_IdItem] FOREIGN KEY ([IdItem]) REFERENCES [dbo].[Item] ([IdItem]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[LogBattle] ( 
    [IdLogBattle] INT IDENTITY (1, 1) NOT NULL,
	[IdAttacker] INT NOT NULL,  
	[IdDefender] INT NOT NULL, 
	[StartTime] INT NULL,
	[Gold] INT NULL,
	[Report] NVARCHAR (200) NULL,
	[IdWinner] INT NOT NULL,
    CONSTRAINT [PK_dbo.LogBattle] PRIMARY KEY CLUSTERED ([IdLogBattle] ASC), 
    CONSTRAINT [FK_dbo.LogBattle_IdAttacker_dbo.Champion_IdChampion] FOREIGN KEY ([IdAttacker]) REFERENCES [dbo].[Champion] ([IdChampion]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
    CONSTRAINT [FK_dbo.LogBattle_IdDefender_dbo.Champion_IdChampion] FOREIGN KEY ([IdDefender]) REFERENCES [dbo].[Champion] ([IdChampion]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT [FK_dbo.LogBattle_IdWinner_dbo.Champion_IdChampion] FOREIGN KEY ([IdWinner]) REFERENCES [dbo].[Champion] ([IdChampion]) ON DELETE NO ACTION ON UPDATE NO ACTION,
);

CREATE TABLE [dbo].[LogFarm] ( 
    [IdLogFarm] INT IDENTITY (1, 1) NOT NULL,
	[IdChampion] INT NOT NULL,  
	[StartTime] INT NULL,
	[DailyRemaining] INT NULL,
	[Gold] INT NULL,
	[Report] NVARCHAR (200) NULL,
    CONSTRAINT [PK_dbo.LogFarm] PRIMARY KEY CLUSTERED ([IdLogFarm] ASC), 
    CONSTRAINT [FK_dbo.LogFarm_dbo.Champion_IdChampion] FOREIGN KEY ([IdChampion]) REFERENCES [dbo].[Champion] ([IdChampion]) ON DELETE CASCADE ON UPDATE CASCADE, 
);

CREATE TABLE [dbo].[LogJungle] ( 
    [IdLogJungle] INT IDENTITY (1, 1) NOT NULL,
	[IdChampion] INT NOT NULL,  
	[StartTime] INT NULL,
	[Duration] INT NULL,
	[Gold] INT NULL,
	[Report] NVARCHAR (200) NULL,
    CONSTRAINT [PK_dbo.LogJungle] PRIMARY KEY CLUSTERED ([IdLogJungle] ASC), 
    CONSTRAINT [FK_dbo.LogJungle_dbo.Champion_IdChampion] FOREIGN KEY ([IdChampion]) REFERENCES [dbo].[Champion] ([IdChampion]) ON DELETE CASCADE ON UPDATE CASCADE, 
);

CREATE TABLE [dbo].[Mail] ( 
    [IdMail] INT IDENTITY (1, 1) NOT NULL,
	[IdSender] INT NOT NULL,  
	[IdReceiver] INT NOT NULL,  
	[Time] INT NULL,
    [Title] NVARCHAR (45) NULL, 
    [Text] NVARCHAR (200) NULL, 
    CONSTRAINT [PK_dbo.Mail] PRIMARY KEY CLUSTERED ([IdMail] ASC), 
    CONSTRAINT [FK_dbo.Mail_IdSender_dbo.Champion_IdChampion] FOREIGN KEY ([IdSender]) REFERENCES [dbo].[Champion] ([IdChampion]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
    CONSTRAINT [FK_dbo.Mail_IdReceiver_dbo.Champion_IdChampion] FOREIGN KEY ([IdReceiver]) REFERENCES [dbo].[Champion] ([IdChampion]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
);

CREATE TABLE [dbo].[Ranking] ( 
    [IdRanking] INT PRIMARY KEY FOREIGN KEY REFERENCES [Champion] (IdChampion), 
	[FarmGold] INT NULL,
	[StolenGold] INT NULL, 
);

CREATE TABLE [dbo].[Skill] ( 
    [IdSkill] INT PRIMARY KEY FOREIGN KEY REFERENCES [Champion](IdChampion),   
	[HP] INT NULL, 
	[AttackDamage] INT NULL,
	[AbilityDamage] INT NULL,
	[AttackSpeed] INT NULL,
	[Armor] INT NULL,
    [MagicResist] INT NULL,
	[Critical] INT NULL,
	[ArmorPenetration] INT NULL,
	[MagicPenetration] INT NULL,   
);
