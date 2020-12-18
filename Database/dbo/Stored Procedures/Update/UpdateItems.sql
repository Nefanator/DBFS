CREATE PROCEDURE [dbo].[UpdateItems]
	@Id int,
	@OwnerId int,
	@Path varchar(max)
AS
	UPDATE Items
	SET OwnerId = @OwnerId, Path = @Path
	WHERE Id = @Id
GO
