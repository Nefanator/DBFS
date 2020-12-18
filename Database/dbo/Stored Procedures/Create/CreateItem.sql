CREATE PROCEDURE [dbo].[CreateItem]
	@OwnerId int,
	@Path varchar(max)	
AS
	INSERT INTO Items (OwnerId, Path)
	OUTPUT inserted.Id
	VALUES (@OwnerId, @Path)
GO
