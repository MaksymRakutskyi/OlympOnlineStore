CREATE TABLE Users (
    [UserId]        INT             NOT NULL    IDENTITY(1,1),
    [FirstName]     NVARCHAR(255)   NOT NULL,
    [LastName]      NVARCHAR(255)   NULL,
    [Email]         NVARCHAR(255)   NOT NULL    UNIQUE,
    [PhoneNumber]   NVARCHAR(20)    NULL        UNIQUE,
    [PasswordHash]  NVARCHAR(MAX)   NOT NULL,
    [Role]          INT             NOT NULL    DEFAULT 0,
    [CreatedAt]     DATETIME        NOT NULL    DEFAULT GETUTCDATE(),
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED (UserId)
);