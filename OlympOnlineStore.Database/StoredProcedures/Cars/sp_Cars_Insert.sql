CREATE PROCEDURE [dbo].[sp_Cars_Insert]
    @Brand NVARCHAR(255),
    @Model NVARCHAR(255) = NULL,
    @Year INT,
    @Transmission INT = 0,
    @PricePerDay MONEY = 0,
    @PricePerWeek MONEY = 0,
    @PricePerMonth MONEY = 0,
    @Availability BIT = 0,
    @ImageBase64 NVARCHAR(MAX) = NULL,
    @Description NVARCHAR(MAX) = NULL
AS
BEGIN
    INSERT INTO Cars ([Brand], [Model], [Year], [Transmission], [PricePerDay], [PricePerWeek], [PricePerMonth], [Availability], [ImageBase64], [Description])
    VALUES (@Brand, @Model, @Year, @Transmission, @PricePerDay, @PricePerWeek, @PricePerMonth, @Availability, @ImageBase64, @Description);
END
