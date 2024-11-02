CREATE PROCEDURE [dbo].[sp_Users_InsertOrUpdate]
	@UserId INT,
	@FirstName NVARCHAR(255),
	@LastName  NVARCHAR(255) = NULL,
	@Email  NVARCHAR(255),
	@PhoneNumber  NVARCHAR(20) = NULL,
	@PasswordHash  NVARCHAR(MAX),
	@Role INT,
	@CreatedAt DATETIME
AS
BEGIN
	IF EXISTS(SELECT * FROM [dbo].[Users] WHERE [UserId] = @UserId)
		BEGIN
			EXEC [dbo].[sp_Users_Update] @UserId, @FirstName, @LastName, @Email, @PhoneNumber,@PasswordHash, @Role, 
										 @CreatedAt;
		END
	ELSE
		BEGIN
			EXEC [dbo].[sp_Users_Insert] @FirstName, @LastName, @Email, @PhoneNumber,@PasswordHash, @Role, @CreatedAt;
		END
END