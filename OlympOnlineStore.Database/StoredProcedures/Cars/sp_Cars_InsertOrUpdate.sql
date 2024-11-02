CREATE PROCEDURE [dbo].[sp_Cars_InsertOrUpdate]
    @CarId INT = NULL,
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
    IF EXISTS (SELECT 1 FROM Cars WHERE [CarId] = @CarId)
        BEGIN
            EXEC [dbo].[sp_Cars_Update] @CarId, @Brand, @Model, @Year, @Transmission, @PricePerDay, @PricePerWeek, 
                                        @PricePerMonth, @Availability, @ImageBase64, @Description;
        END
    ELSE
        BEGIN
            EXEC [dbo].[sp_Cars_Insert] @Brand, @Model, @Year, @Transmission, @PricePerDay, @PricePerWeek, 
                                        @PricePerMonth, @Availability, @ImageBase64, @Description;
        END
END