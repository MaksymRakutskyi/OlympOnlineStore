CREATE PROCEDURE [dbo].[sp_Cars_Get]
    @CarId INT
AS
BEGIN
    SELECT * FROM [dbo].[Cars] WHERE [CarId] = @CarId;
END