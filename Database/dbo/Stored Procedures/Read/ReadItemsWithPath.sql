CREATE PROCEDURE [dbo].[ReadItemsWithPath]
	@OwnerId int,
	@Path varchar(max)
AS
	SELECT [Id], [Path], [Type] FROM Items
	WHERE OwnerId = @OwnerId AND Path LIKE @Path
GO
