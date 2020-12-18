CREATE PROCEDURE [dbo].[CreateUser]
	@Name varchar(50)
AS
	INSERT INTO Users (Name)
	OUTPUT inserted.Id
	VALUES (@Name)	
GO
