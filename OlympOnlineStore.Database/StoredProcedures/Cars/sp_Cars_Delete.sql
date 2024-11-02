CREATE PROCEDURE [dbo].[sp_Cars_Delete]
    @CarId INT
AS
BEGIN
    DELETE FROM [dbo].[Cars] WHERE [CarId] = @CarId;
END