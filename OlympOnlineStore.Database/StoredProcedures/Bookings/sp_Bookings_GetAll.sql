﻿CREATE PROCEDURE [dbo].[sp_Bookings_Get]
	@param1 int = 0,
	@param2 int
AS
	SELECT @param1, @param2
RETURN 0