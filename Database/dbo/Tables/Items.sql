﻿CREATE TABLE [dbo].[Items]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[OwnerId] INT NOT NULL, 
	[Path] VARCHAR(MAX) NOT NULL,
	[Type] int NOT NULL,
    CONSTRAINT [FK_UserId_ToUser] FOREIGN KEY ([OwnerId]) REFERENCES [Users]([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
)
