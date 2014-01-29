CREATE TABLE [dbo].[Roles] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (256) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[UsersInRoles] (
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
	CONSTRAINT fk_UserId FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT fk_RoleId FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);