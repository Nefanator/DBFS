CREATE PROCEDURE [dbo].[ReadBallWithId]
	@Id int
AS
	SELECT [Colour], [Size] FROM Balls
	WHERE Id = @Id
GO
