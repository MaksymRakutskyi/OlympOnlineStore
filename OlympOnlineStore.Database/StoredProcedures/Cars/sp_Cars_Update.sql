CREATE PROCEDURE [dbo].[sp_Cars_Update]
    @CarId INT,
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
    UPDATE [dbo].[Cars]    
    SET [Brand] = @Brand,
        [Model] = @Model,
        [Year] = @Year,
        [Transmission] = @Transmission,
        [PricePerDay] = @PricePerDay,
        [PricePerWeek] = @PricePerWeek,
        [PricePerMonth] = @PricePerMonth,
        [Availability] = @Availability,
        [ImageBase64] = @ImageBase64,
        [Description] = @Description
    WHERE [CarId] = @CarId;
END