CREATE PROCEDURE [dbo].[ReadUsersItems]
	@OwnerId int
AS
	SELECT [Id], [Path], [Type] FROM Items
	WHERE Items.OwnerId = @OwnerId
GO
