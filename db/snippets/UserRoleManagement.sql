/****** Script for Inserting User-Role command from SSMS  ******/

USE [TotaraPhoto]
GO

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES ('02bca8db-6b18-4f14-82cc-64dde20bd0f0', '079A2F8C-58F4-4BFF-AE25-93960535E1A5');

SELECT u.[UserName] AS [User Name], r.[Name] AS [Role Name]
FROM [dbo].AspNetUsers AS u 
INNER JOIN [dbo].[AspNetUserRoles] AS ur ON u.Id = ur.UserId
INNER JOIN [dbo].AspNetRoles AS r ON ur.RoleId = r.Id 
GO
