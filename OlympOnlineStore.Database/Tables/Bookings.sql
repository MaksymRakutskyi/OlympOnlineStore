CREATE TABLE Bookings (
    [BookingId]         INT         NOT NULL    IDENTITY(1,1),
    [UserId]            INT         NOT NULL,
    [CarId]             INT         NOT NULL,
    [StartDate]         DATETIME    NOT NULL,
    [EndDate]           DATETIME    NOT NULL,
    [TotalPrice]        MONEY       NOT NULL,
    [BookingStatus]     INT         NOT NULL    DEFAULT 0,
    [CreatedAt]         DATETIME    NOT NULL    DEFAULT GETUTCDATE(),
    CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED ([BookingId]),
    CONSTRAINT [FK_Bookings_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Bookings_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]) ON DELETE CASCADE
);