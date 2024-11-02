CREATE TABLE Cars (
    [CarId]             INT             NOT NULL    IDENTITY(1,1),
    [Brand]             NVARCHAR(255)   NOT NULL,
    [Model]             NVARCHAR(255)   NULL,
    [Year]              INT             NOT NULL,
    [Transmission]      INT             NOT NULL    DEFAULT 0,
    [PricePerDay]       MONEY           NOT NULL    DEFAULT 0,
    [PricePerWeek]      MONEY           NOT NULL    DEFAULT 0,
    [PricePerMonth]     MONEY           NOT NULL    DEFAULT 0,
    [Availability]      BIT             NOT NULL    DEFAULT 0,
    [ImageBase64]       NVARCHAR(MAX)   NULL,
    [Description]       NVARCHAR(MAX)   NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED (CarId)
);