CREATE PROCEDURE [dbo].[CreateBall]
	@OwnerId int,
	@Path varchar(max),
	@Type int,
	@Colour varchar(20),
	@Size int
	
AS
	INSERT INTO Items (OwnerId, Path, Type)
	OUTPUT inserted.Id
	VALUES (@OwnerId, @Path, @Type)
	
	DECLARE @Id int
	SET @Id = SCOPE_IDENTITY()

	INSERT INTO Balls (Id, Colour, Size)
	OUTPUT inserted.Id
	VALUES (@Id, @Colour, @Size)
GO
