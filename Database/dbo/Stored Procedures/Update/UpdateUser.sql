CREATE PROCEDURE [dbo].[UpdateUser]
	@Id int,
	@Name varchar(50)
AS
	UPDATE Users
	SET Name = @Name
	WHERE Id = @Id
GO
