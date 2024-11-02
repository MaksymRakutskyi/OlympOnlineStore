CREATE TABLE Payments (
    [PaymentId]         INT         NOT NULL    IDENTITY(1,1),
    [BookingId]         INT         NOT NULL,
    [Amount]            MONEY       NOT NULL    DEFAULT 0,
    [PaymentMethod]     INT         NOT NULL    DEFAULT 0,
    [PaymentStatus]     INT         NOT NULL    DEFAULT 0,
    [PaymentDate]       DATETIME    NOT NULL    DEFAULT GETUTCDATE(),
    CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([PaymentId]),
    CONSTRAINT [PK_Payments_Bookings] FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Bookings] ([BookingId]) ON DELETE CASCADE
);