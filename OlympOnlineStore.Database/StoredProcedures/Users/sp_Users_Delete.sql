CREATE PROCEDURE [dbo].[sp_Users_Delete]
	@UserId INT
AS
BEGIN
	DELETE FROM [dbo].[Users] WHERE UserId = @UserId;
END