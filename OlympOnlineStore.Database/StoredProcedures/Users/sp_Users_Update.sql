CREATE PROCEDURE [dbo].[sp_Users_Update]
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
	UPDATE [dbo].[Users] 
	SET [FirstName] = @FirstName, 
		[LastName] = @LastName, 
		[Email] = @Email, 
		[PhoneNumber] = @PhoneNumber,
		[PasswordHash] = @PasswordHash, 
		[Role] = @Role, 
		[CreatedAt] = @CreatedAt
	WHERE [UserId] = @UserId;
END