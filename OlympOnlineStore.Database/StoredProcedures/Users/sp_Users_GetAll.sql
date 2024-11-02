CREATE PROCEDURE [dbo].[sp_Users_GetAll]
AS
BEGIN
	SELECT * FROM [dbo].[Users];
END