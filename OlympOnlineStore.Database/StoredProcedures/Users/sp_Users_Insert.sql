CREATE PROCEDURE [dbo].[sp_Users_Insert]
	@FirstName NVARCHAR(255),
	@LastName  NVARCHAR(255) = NULL,
	@Email  NVARCHAR(255),
	@PhoneNumber  NVARCHAR(20) = NULL,
	@PasswordHash  NVARCHAR(MAX),
	@Role INT,
	@CreatedAt DATETIME
AS
BEGIN
	INSERT INTO [dbo].[Users] ([FirstName], [LastName], [Email], [PhoneNumber], [PasswordHash], [Role], [CreatedAt])
	VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @PasswordHash, @Role, @CreatedAt);
END