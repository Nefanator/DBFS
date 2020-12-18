CREATE PROCEDURE [dbo].[DeleteItem]
	@Id int
AS
	DELETE FROM Items
	WHERE ID = @Id
GO
