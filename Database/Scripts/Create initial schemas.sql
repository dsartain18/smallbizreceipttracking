Create Schema [Common] AUTHORIZATION dbo;
GO
Create Schema [RTS] AUTHORIZATION dbo;
GO
Create Schema [Billing] AUTHORIZATION dbo;
GO
Create Schema [Companies] AUTHORIZATION dbo;
GO
Create Schema [Users] AUTHORIZATION dbo;
GO

EXEC sys.sp_addextendedproperty @name = N'Common', @value = N'Common Schema', @level0type = N'SCHEMA', @level0name = 'Common'
GO
EXEC sys.sp_addextendedproperty @name = N'RTS', @value = N'Receipt Tracking System Schema', @level0type = N'SCHEMA', @level0name = 'RTS'
GO
EXEC sys.sp_addextendedproperty @name = N'Billing', @value = N'Billing Schema', @level0type = N'SCHEMA', @level0name = 'Billing'
GO
EXEC sys.sp_addextendedproperty @name = N'Companies', @value = N'Companies Schema', @level0type = N'SCHEMA', @level0name = 'Companies'
GO
EXEC sys.sp_addextendedproperty @name = N'Users', @value = N'Users Schema', @level0type = N'SCHEMA', @level0name = 'Users'
GO

