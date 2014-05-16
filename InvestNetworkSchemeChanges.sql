---------------------------------------------
-- Ильназ 28.01.2014
-- Ильназ 15.02.2014  Удалил колонку ISO
---------------------------------------------
CREATE TABLE Countries (
	CountryID INT IDENTITY (1, 1) PRIMARY KEY,
	CountryName VARCHAR (100) NOT NULL
)
GO

---------------------------------------------
-- Ильназ 28.01.2014
-- Ильназ 15.02.2014  Удалил колонку ISO
---------------------------------------------
CREATE TABLE Regions (
	RegionID INT IDENTITY (1, 1) PRIMARY KEY,
	ISO VARCHAR (50) NULL,
	RegionName VARCHAR (100) NOT NULL,
	CountryID INT NOT NULL REFERENCES Countries (CountryID)
)
GO

---------------------------------------------
-- Ильназ 28.01.2014
-- Ильназ 15.02.2014  Удалил колонку ISO, добавил CountryID
---------------------------------------------
CREATE TABLE Cities (
	CityID INT IDENTITY (1, 1) PRIMARY KEY,
	CityName VARCHAR (100) NOT NULL,
	RegionID INT NOT NULL REFERENCES Regions (RegionID),
	CountryID INT NOT NULL REFERENCES Countries (CountryID)
)
GO


---------------------------------------------
-- Леха 30.01.2014
---------------------------------------------
CREATE UNIQUE INDEX idxCityID ON Cities (CityID);
CREATE UNIQUE INDEX idxCountryID ON Countries (CountryID);
CREATE UNIQUE INDEX idxRegionID ON Regions (RegionID);
CREATE UNIQUE INDEX idxRoleID ON Roles (Id);
CREATE UNIQUE INDEX idxUserID ON Users (Id);


---------------------------------------------
-- Ильназ 12.02.2014
---------------------------------------------
CREATE TABLE Scopes (
	ScopeID INT IDENTITY (1, 1) PRIMARY KEY,
	Title VARCHAR (150) NOT NULL
)
GO

---------------------------------------------
-- Ильназ 12.02.2014
-- Ильназ 10.03.2014  Добавил ProjectStatusID, StartDate
-- Ильназ 15.04.2014  Добавил CreateDate, StartDate NOT NULL -> NULL
-- Ильназ 07.05.2014  Добавил LinkToImg, EndDate
-- Ильназ 09.05.2014  Добавил NecessaryFunding, ShortDescription
-- Ильназ 11.05.2014  Добавил FundingDuration
---------------------------------------------
CREATE TABLE Projects (
	ProjectID INT IDENTITY (1, 1) PRIMARY KEY,
	AuthorID INT NOT NULL REFERENCES Users (Id),
	LocationCityID INT NULL REFERENCES Cities (CityID),
	Name NVARCHAR (150) NULL,
	ScopeID INT NULL REFERENCES Scopes (ScopeID),
	[Description] NVARCHAR(MAX) NULL,
	LinkToBusinessPlan NVARCHAR(300) NULL,
	LinkToFinancialPlan NVARCHAR(300) NULL,
	LinkToVideoPresentation NVARCHAR(300) NULL,
	LinkToGuaranteeLetter NVARCHAR(300) NULL,
	ProjectStatusID INT NOT NULL REFERENCES ProjectStatuses (ProjectStatusID),
	StartDate DateTime NULL,
	CreateDate DateTime NOT NULL,
	LinkToImg NVARCHAR(300) NULL,
	EndDate DateTime NULL,
	NecessaryFunding MONEY NULL,
	ShortDescription NVARCHAR(135) NULL,
	FundingDuration INT NULL,
	IsInspected BIT NOT NULL,
	ProjectFilesDirectory NVARCHAR(256) NOT NULL,
)
GO

CREATE TABLE [dbo].[Users] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Email]      NVARCHAR (128) NOT NULL,
    [Password]   NVARCHAR (128) NOT NULL,
    [FullName]   NVARCHAR (128) NOT NULL,
    [RoleId]     INT            NULL,
    [Avatar]     NVARCHAR (300) NULL,
    [PostNotice] BIT            DEFAULT ((1)) NULL,
	FilesBrowserDirectory NVARCHAR(256) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);

---------------------------------------------
-- Леха 07.03.2014
---------------------------------------------
CREATE TABLE Messages(
	MessageID INT IDENTITY (1, 1) PRIMARY KEY,
	FromUserID INT NOT NULL REFERENCES Users (Id),
	ToUserID INT NOT NULL REFERENCES Users (Id),
	MessageText NVARCHAR(MAX) NOT NULL,
	MessageDate DATETIME NOT NULL
)
GO

---------------------------------------------
-- Леха 07.03.2014
-- Ильназ 07.03.2014  Добавил StatusCode(5 - активный, -99 - удаленный, 1 - проверяется, -1 - блокированный)
---------------------------------------------
CREATE TABLE ProjectStatuses(
	ProjectStatusID INT IDENTITY (1, 1) PRIMARY KEY,
	Status NVARCHAR(100),
	StatusCode INT NOT NULL
)
GO

---------------------------------------------
-- Леха 07.03.2014
-- Ильназ 07.03.2014  Добавил StatusCode(5 - активный, -99 - удаленный, 1 - проверяется,  )
---------------------------------------------
CREATE TABLE PaymentStatuses(
	PaymentStatusID INT IDENTITY (1, 1) PRIMARY KEY,
	Status NVARCHAR(100),
	StatusCode INT NOT NULL
)
GO
CREATE TABLE Payments(
	PaymentID INT IDENTITY (1, 1) PRIMARY KEY,
	UserID INT NOT NULL REFERENCES Users (Id),
	ProjectID INT NOT NULL REFERENCES Projects (ProjectID),
	Sum DECIMAL(12,2) NOT NULL DEFAULT 0,
	PaymentDate DateTime NOT NULL,
	PaymentStatus INT NOT NULL REFERENCES PaymentStatuses (PaymentStatusID)
)
GO
CREATE TABLE UsersInfo(
	UsersInfoID INT IDENTITY (1, 1) PRIMARY KEY,
	UserID INT NOT NULL REFERENCES Users (Id),
	Family NVARCHAR(100) NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	Middle NVARCHAR(100),
	DateOfBirth Date NOT NULL,
	Address NVARCHAR(1000) NOT NULL,
	Citizenship NVARCHAR(100) NOT NULL,
	PasportSerie NVARCHAR(128) NOT NULL,
	PasportNumber NVARCHAR(128) NOT NULL,
	PasportIssueDate Date NOT NULL,
	PasportIssuedBy NVARCHAR(1000) NOT NULL,
	PhoneNumber NVARCHAR(20),
	RegisterDate DateTime NOT NULL
)
GO

CREATE UNIQUE INDEX idxMessageID ON Messages (MessageID);
CREATE UNIQUE INDEX idxPaymentID ON Payments (PaymentID);
CREATE UNIQUE INDEX idxUsersInfoID ON UsersInfo (UsersInfoID);

---------------------------------------------
-- Леха 14.05.2014  Добавил ссылку на аватарку и поле О СЕБЕ
---------------------------------------------
alter table Users add Avatar nvarchar(300);
alter table Users add PostNotice bit default 1;
alter table UsersInfo add AboutMyself nvarchar(max);
