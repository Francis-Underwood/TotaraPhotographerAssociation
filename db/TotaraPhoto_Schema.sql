USE [master]
GO
/****** Object:  Database [TotaraPhoto]    Script Date: 29/10/2016 11:16:23 p.m. ******/
CREATE DATABASE [TotaraPhoto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TotaraPhoto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRE2014VINC\MSSQL\DATA\TotaraPhoto.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TotaraPhoto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRE2014VINC\MSSQL\DATA\TotaraPhoto_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TotaraPhoto] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TotaraPhoto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TotaraPhoto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TotaraPhoto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TotaraPhoto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TotaraPhoto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TotaraPhoto] SET ARITHABORT OFF 
GO
ALTER DATABASE [TotaraPhoto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TotaraPhoto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TotaraPhoto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TotaraPhoto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TotaraPhoto] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [TotaraPhoto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TotaraPhoto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TotaraPhoto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TotaraPhoto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TotaraPhoto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TotaraPhoto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TotaraPhoto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TotaraPhoto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TotaraPhoto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TotaraPhoto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TotaraPhoto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TotaraPhoto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TotaraPhoto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TotaraPhoto] SET  MULTI_USER 
GO
ALTER DATABASE [TotaraPhoto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TotaraPhoto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TotaraPhoto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TotaraPhoto] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TotaraPhoto] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TotaraPhoto]
GO
/****** Object:  User [MIT502712]    Script Date: 29/10/2016 11:16:23 p.m. ******/
CREATE USER [MIT502712] FOR LOGIN [MIT502712] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [MIT502712]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Discount] [decimal](4, 2) NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[ExpiryDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerOrder]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrder](
	[Id] [nvarchar](128) NOT NULL,
	[ShippingFirstName] [nvarchar](50) NOT NULL,
	[ShippingLastName] [nvarchar](50) NOT NULL,
	[ShippingEmail] [nvarchar](50) NOT NULL,
	[ShippingPhone] [nvarchar](50) NOT NULL,
	[DeliveryAddressLine1] [nvarchar](100) NOT NULL,
	[DeliveryAddressLine2] [nvarchar](100) NULL,
	[ShippingPostalCode] [nvarchar](20) NULL,
	[OrderStatus] [nvarchar](10) NOT NULL CONSTRAINT [DF_Order_OrderStatus]  DEFAULT (N'nonpaid'),
	[CreatedDate] [datetime] NOT NULL,
	[PaypalPaymentId] [nvarchar](128) NULL,
	[CustomerId] [nvarchar](128) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [nvarchar](128) NOT NULL,
	[LineNumber] [int] NOT NULL,
	[ProductId] [nvarchar](20) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](6, 2) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[LineNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PhotoFilePath] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_Product_IsDeleted]  DEFAULT ((0)),
	[BigPhotoFilePath] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resource]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](56) NOT NULL,
	[Title] [nvarchar](128) NULL,
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysParam]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysParam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParaName] [nvarchar](10) NOT NULL,
	[ParaVal] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SysParam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 29/10/2016 11:16:24 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 29/10/2016 11:16:24 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 29/10/2016 11:16:24 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 29/10/2016 11:16:24 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 29/10/2016 11:16:24 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 29/10/2016 11:16:24 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[ExpirizeMembership]    Script Date: 29/10/2016 11:16:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ExpirizeMembership] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @ExpiredRoleId NVARCHAR(128)
	SELECT @ExpiredRoleId = [Id] FROM [dbo].[AspNetRoles] WHERE [Name] = 'expired';

	-- vars
	DECLARE @UserId NVARCHAR(128)
	DECLARE @UserRoleCursor CURSOR 

    -- move the records into a temporay table, to avoid deadlock
	SELECT * INTO #tempTable
	FROM dbo.AspNetUserRoles ur WITH (NOLOCK)
	INNER JOIN dbo.AspNetRoles r  WITH (NOLOCK) ON ur.RoleId = r.Id
	WHERE r.Name IN ('full', 'associate') AND ExpiryDate <= GETDATE();

	SET @UserRoleCursor = CURSOR FAST_FORWARD
	FOR
	SELECT [UserId] FROM #tempTable

	OPEN @UserRoleCursor

	FETCH NEXT FROM @UserRoleCursor INTO @UserId
	-- Or put try catch here
	WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		-- TODO: TRY-CATCH
		UPDATE dbo.AspNetUserRoles SET RoleId = @ExpiredRoleId, ExpiryDate = NULL WHERE [UserId] = @UserId

		FETCH NEXT FROM @UserRoleCursor INTO @UserId
	END

	CLOSE @UserRoleCursor
	DEALLOCATE @UserRoleCursor


END

GO
USE [master]
GO
ALTER DATABASE [TotaraPhoto] SET  READ_WRITE 
GO
