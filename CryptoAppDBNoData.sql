-- DROP SCHEMA dbo;

-- CryptoAppDB.dbo.Coins definition

-- Drop table

-- DROP TABLE CryptoAppDB.dbo.Coins;

CREATE TABLE CryptoAppDB.dbo.Coins (
	Id int IDENTITY(1,1) NOT NULL,
	LongName nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ShortName nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Icon varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT AK_Coins_LongName UNIQUE (LongName),
	CONSTRAINT PK_Coins PRIMARY KEY (Id)
);

-- CryptoAppDB.dbo.Users definition

-- Drop table

-- DROP TABLE CryptoAppDB.dbo.Users;

CREATE TABLE CryptoAppDB.dbo.Users (
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Lastname nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Email nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Password nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Token nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Image] varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT N'' NOT NULL,
	WalletAddress nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT N'' NOT NULL,
	DeviceToken nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT N'' NOT NULL,
	CONSTRAINT PK_Users PRIMARY KEY (Id)
);

-- CryptoAppDB.dbo.CoinAccounts definition

-- Drop table

-- DROP TABLE CryptoAppDB.dbo.CoinAccounts;

CREATE TABLE CryptoAppDB.dbo.CoinAccounts (
	CoinId int NOT NULL,
	UserId int NOT NULL,
	Balance decimal(30,16) NOT NULL,
	Id int IDENTITY(1,1) NOT NULL,
	CONSTRAINT PK_CoinAccounts PRIMARY KEY (Id),
	CONSTRAINT FK_CoinAccounts_Coins_CoinId FOREIGN KEY (CoinId) REFERENCES CryptoAppDB.dbo.Coins(Id) ON DELETE CASCADE,
	CONSTRAINT FK_CoinAccounts_Users_UserId FOREIGN KEY (UserId) REFERENCES CryptoAppDB.dbo.Users(Id) ON DELETE CASCADE
);

-- CryptoAppDB.dbo.Transactions definition

-- Drop table

-- DROP TABLE CryptoAppDB.dbo.Transactions;

CREATE TABLE CryptoAppDB.dbo.Transactions (
	Id int IDENTITY(1,1) NOT NULL,
	Amount decimal(18,2) NOT NULL,
	SenderId int NOT NULL,
	ReceiverId int NOT NULL,
	CoinId int NOT NULL,
	[Date] datetime2 DEFAULT '0001-01-01T00:00:00.0000000' NOT NULL,
	WalletAddress nvarchar COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT N'' NOT NULL,
	CONSTRAINT PK_Transactions PRIMARY KEY (Id),
	CONSTRAINT FK_Transactions_Coins_CoinId FOREIGN KEY (CoinId) REFERENCES CryptoAppDB.dbo.Coins(Id) ON DELETE CASCADE,
	CONSTRAINT FK_Transactions_Users_ReceiverId FOREIGN KEY (ReceiverId) REFERENCES CryptoAppDB.dbo.Users(Id) ON DELETE CASCADE
);
