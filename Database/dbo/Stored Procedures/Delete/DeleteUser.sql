CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
AS
	DELETE FROM Users
	WHERE Id = @Id
GO
