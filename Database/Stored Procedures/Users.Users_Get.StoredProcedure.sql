IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Users.Users_Get')
DROP PROCEDURE Users.Users_Get	
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Don Sartain
-- Create date: 05/25/2017
-- Description:	Gets a list of users
-- =============================================
CREATE PROCEDURE Users.Users_Get	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

    SELECT
		u.UserID,
		u.FirstName,
		u.LastName,
		u.CompanyID,
		u.AddressID,
		u.IsPrimaryCompanyContact
	FROM	
		Users.Users u	
END
GO
