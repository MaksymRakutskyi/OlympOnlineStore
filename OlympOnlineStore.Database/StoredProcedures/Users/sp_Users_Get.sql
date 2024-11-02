CREATE PROCEDURE [dbo].[sp_Users_Get]
	@UserId INT
AS
BEGIN
	SELECT * FROM [dbo].[Users] WHERE UserId = @UserId;
END