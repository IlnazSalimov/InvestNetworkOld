---------------------------------------------
-- Ильназ 28.01.2014
---------------------------------------------
CREATE TABLE Countries (
	CountryID INT IDENTITY (1, 1) PRIMARY KEY,
	ISO VARCHAR (50) NULL,
	CountryName VARCHAR (100) NOT NULL
)
GO

---------------------------------------------
-- Ильназ 28.01.2014
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
---------------------------------------------
CREATE TABLE Cities (
	CityID INT IDENTITY (1, 1) PRIMARY KEY,
	ISO VARCHAR (50) NULL,
	CityName VARCHAR (100) NOT NULL,
	RegionID INT NOT NULL REFERENCES Regions (RegionID)
)
GO

---------------------------------------------
-- Ильназ 28.01.2014
---------------------------------------------
INSERT INTO Countries (ISO, CountryName, id) 
SELECT m.iso, m.local_name, m.id
FROM meta_location m
WHERE m.type = 'CO'

---------------------------------------------
-- Ильназ 28.01.2014
---------------------------------------------
INSERT INTO Regions (ISO, RegionName, CountryID, id) 
SELECT m.iso, m.local_name, c.CountryID, m.id
FROM meta_location m JOIN Countries c
ON m.in_location = c.id
WHERE m.type = 'RE'

---------------------------------------------
-- Ильназ 28.01.2014
---------------------------------------------
INSERT INTO Cities (ISO, CityName, RegionID) 
SELECT m.iso, m.local_name, r.RegionID
FROM meta_location m JOIN Regions r
ON m.in_location = r.id
WHERE m.type = 'CI'

---------------------------------------------
-- Леха 30.01.2014
---------------------------------------------
CREATE UNIQUE INDEX idxCityID ON Cities (CityID);
CREATE UNIQUE INDEX idxCountryID ON Countries (CountryID);
CREATE UNIQUE INDEX idxRegionID ON Regions (RegionID);
CREATE UNIQUE INDEX idxRoleID ON Roles (Id);
CREATE UNIQUE INDEX idxUserID ON Users (Id);