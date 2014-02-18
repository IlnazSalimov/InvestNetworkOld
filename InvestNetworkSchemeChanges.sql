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