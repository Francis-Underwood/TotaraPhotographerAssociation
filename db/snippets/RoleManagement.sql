/****** Script for inserting roles from SSMS  ******/

USE [TotaraPhoto]
GO

INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (NEWID(), 'admin');
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (NEWID(), 'full');
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (NEWID(), 'associate');