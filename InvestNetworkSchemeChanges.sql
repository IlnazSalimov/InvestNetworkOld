---------------------------------------------
-- ������ 28.01.2014
---------------------------------------------
CREATE TABLE Countries (
	CountryID INT IDENTITY (1, 1) PRIMARY KEY,
	ISO VARCHAR (50) NULL,
	CountryName VARCHAR (100) NOT NULL
)
GO

---------------------------------------------
-- ������ 28.01.2014
---------------------------------------------
CREATE TABLE Regions (
	RegionID INT IDENTITY (1, 1) PRIMARY KEY,
	ISO VARCHAR (50) NULL,
	RegionName VARCHAR (100) NOT NULL,
	CountryID INT NOT NULL REFERENCES Countries (CountryID)
)
GO

---------------------------------------------
-- ������ 28.01.2014
---------------------------------------------
CREATE TABLE Cities (
	CityID INT IDENTITY (1, 1) PRIMARY KEY,
	ISO VARCHAR (50) NULL,
	CityName VARCHAR (100) NOT NULL,
	RegionID INT NOT NULL REFERENCES Regions (RegionID)
)
GO

---------------------------------------------
-- ������ 28.01.2014
---------------------------------------------
INSERT INTO Countries (ISO, CountryName, id) 
SELECT m.iso, m.local_name, m.id
FROM meta_location m
WHERE m.type = 'CO'

---------------------------------------------
-- ������ 28.01.2014
---------------------------------------------
INSERT INTO Regions (ISO, RegionName, CountryID, id) 
SELECT m.iso, m.local_name, c.CountryID, m.id
FROM meta_location m JOIN Countries c
ON m.in_location = c.id
WHERE m.type = 'RE'

---------------------------------------------
-- ������ 28.01.2014
---------------------------------------------
INSERT INTO Cities (ISO, CityName, RegionID) 
SELECT m.iso, m.local_name, r.RegionID
FROM meta_location m JOIN Regions r
ON m.in_location = r.id
WHERE m.type = 'CI'

---------------------------------------------
-- ���� 30.01.2014
---------------------------------------------
CREATE UNIQUE INDEX idxCityID ON Cities (CityID);
CREATE UNIQUE INDEX idxCountryID ON Countries (CountryID);
CREATE UNIQUE INDEX idxRegionID ON Regions (RegionID);
CREATE UNIQUE INDEX idxRoleID ON Roles (Id);
CREATE UNIQUE INDEX idxUserID ON Users (Id);


---------------------------------------------
-- ������ 12.02.2014
---------------------------------------------
CREATE TABLE Scopes (
	ScopeID INT IDENTITY (1, 1) PRIMARY KEY,
	Title VARCHAR (150) NOT NULL
)
GO

---------------------------------------------
-- ������ 12.02.2014
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