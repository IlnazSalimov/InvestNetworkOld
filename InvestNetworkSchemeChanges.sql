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
---------------------------------------------
CREATE TABLE Projects (
	ProjectID INT IDENTITY (1, 1) PRIMARY KEY,
	AuthorID INT NOT NULL REFERENCES Users (Id),
	LocationCityID INT NOT NULL REFERENCES Cities (CityID),
	Name VARCHAR (150) NOT NULL,
	ScopeID INT NOT NULL REFERENCES Scopes (ScopeID),
	Description NVARCHAR(MAX) NULL,
	LinkToBusinessPlan VARCHAR(300) NOT NULL,
	LinkToFinancialPlan VARCHAR(300) NOT NULL,
	LinkToVideoPresentation VARCHAR(300) NULL,
	LinkToGuaranteeLetter VARCHAR(300) NULL
)
GO

---------------------------------------------
-- Леха 07.03.2014
---------------------------------------------
CREATE TABLE Messages (
	MessageID INT IDENTITY (1, 1) PRIMARY KEY,
	FromUserID INT NOT NULL REFERENCES Users (Id),
	ToUserID INT NOT NULL REFERENCES Users (Id),
	MessageText NVARCHAR(MAX) NOT NULL,
	MessageDate DATETIME NOT NULL
)
GO
CREATE TABLE ProjectStatuses(
	ProjectStatusID INT IDENTITY (1, 1) PRIMARY KEY,
	Status NVARCHAR(100)
)
GO
CREATE TABLE PaymentStatuses(
	PaymentStatusID INT IDENTITY (1, 1) PRIMARY KEY,
	Status NVARCHAR(100)
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

CREATE UNIQUE INDEX idxMessageID ON Messages (MessageID);
CREATE UNIQUE INDEX idxPaymentID ON Payments (PaymentID);

ALTER TABLE Projects ADD StartDate DateTime NOT NULL ;
GO
ALTER TABLE Projects ADD ProjectStatusID INT NOT NULL REFERENCES ProjectStatuses (ProjectStatusID);
GO