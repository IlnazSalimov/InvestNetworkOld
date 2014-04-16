---------------------------------------------
-- ������ 28.01.2014
-- ������ 15.02.2014  ������ ������� ISO
---------------------------------------------
CREATE TABLE Countries (
	CountryID INT IDENTITY (1, 1) PRIMARY KEY,
	CountryName VARCHAR (100) NOT NULL
)
GO

---------------------------------------------
-- ������ 28.01.2014
-- ������ 15.02.2014  ������ ������� ISO
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
-- ������ 15.02.2014  ������ ������� ISO, ������� CountryID
---------------------------------------------
CREATE TABLE Cities (
	CityID INT IDENTITY (1, 1) PRIMARY KEY,
	CityName VARCHAR (100) NOT NULL,
	RegionID INT NOT NULL REFERENCES Regions (RegionID),
	CountryID INT NOT NULL REFERENCES Countries (CountryID)
)
GO


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
-- ������ 10.03.2014  ������� ProjectStatusID, StartDate
-- ������ 15.04.2014  ������� CreateDate, StartDate NOT NULL -> NULL
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
	LinkToGuaranteeLetter VARCHAR(300) NULL,
	ProjectStatusID INT NOT NULL REFERENCES ProjectStatuses (ProjectStatusID),
	StartDate DateTime NULL,
	CreateDate DateTime NOT NULL
)
GO

---------------------------------------------
-- ���� 07.03.2014
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
-- ���� 07.03.2014
-- ������ 07.03.2014  ������� StatusCode(5 - ��������, -99 - ���������, 1 - ����������� )
---------------------------------------------
CREATE TABLE ProjectStatuses(
	ProjectStatusID INT IDENTITY (1, 1) PRIMARY KEY,
	Status NVARCHAR(100),
	StatusCode INT NOT NULL
)
GO

---------------------------------------------
-- ���� 07.03.2014
-- ������ 07.03.2014  ������� StatusCode(5 - ��������, -99 - ���������, 1 - ����������� )
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