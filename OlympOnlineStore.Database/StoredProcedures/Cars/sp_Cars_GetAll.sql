CREATE PROCEDURE [dbo].[sp_Cars_GetAll]
AS
BEGIN
    SELECT * FROM [dbo].[Cars];
END