/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.2027)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [SNACKSTORE]    Script Date: 19/9/2019 06:35:20 ******/
CREATE DATABASE [SNACKSTORE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SNACKSTORE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SNACKSTORE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SNACKSTORE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SNACKSTORE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SNACKSTORE] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SNACKSTORE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SNACKSTORE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SNACKSTORE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SNACKSTORE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SNACKSTORE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SNACKSTORE] SET ARITHABORT OFF 
GO
ALTER DATABASE [SNACKSTORE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SNACKSTORE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SNACKSTORE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SNACKSTORE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SNACKSTORE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SNACKSTORE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SNACKSTORE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SNACKSTORE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SNACKSTORE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SNACKSTORE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SNACKSTORE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SNACKSTORE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SNACKSTORE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SNACKSTORE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SNACKSTORE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SNACKSTORE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SNACKSTORE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SNACKSTORE] SET RECOVERY FULL 
GO
ALTER DATABASE [SNACKSTORE] SET  MULTI_USER 
GO
ALTER DATABASE [SNACKSTORE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SNACKSTORE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SNACKSTORE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SNACKSTORE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SNACKSTORE] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SNACKSTORE', N'ON'
GO
ALTER DATABASE [SNACKSTORE] SET QUERY_STORE = OFF
GO
USE [SNACKSTORE]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SNACKSTORE]
GO
/****** Object:  Table [dbo].[products_History]    Script Date: 19/9/2019 06:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products_History](
	[ProductID] [int] NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[UnitPrice] [decimal](10, 4) NOT NULL,
	[UnitsInStock] [int] NULL,
	[Discontinued] [bit] NOT NULL,
	[Timestamp_Column] [timestamp] NOT NULL,
	[UserID] [int] NULL,
	[Likes] [int] NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Index [ix_products_History]    Script Date: 19/9/2019 06:35:21 ******/
CREATE CLUSTERED INDEX [ix_products_History] ON [dbo].[products_History]
(
	[EndTime] ASC,
	[StartTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 19/9/2019 06:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[ProductID] [int] NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[UnitPrice] [decimal](10, 4) NOT NULL,
	[UnitsInStock] [int] NULL,
	[Discontinued] [bit] NOT NULL,
	[Timestamp_Column] [timestamp] NOT NULL,
	[UserID] [int] NULL,
	[Likes] [int] NULL,
	[StartTime] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[EndTime] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([StartTime], [EndTime])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON ( HISTORY_TABLE = [dbo].[products_History] )
)
GO
/****** Object:  Table [dbo].[categories]    Script Date: 19/9/2019 06:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[CategoryID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Timestamp_Column] [timestamp] NOT NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customers]    Script Date: 19/9/2019 06:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Active] [bit] NULL,
	[Phone] [varchar](20) NULL,
	[Timestamp_Column] [timestamp] NOT NULL,
 CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 19/9/2019 06:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[OrdersID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[Timestamp_Column] [timestamp] NOT NULL,
	[StartTime] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[EndTime] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[OrdersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([StartTime], [EndTime])
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders_details]    Script Date: 19/9/2019 06:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders_details](
	[OrdersID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [decimal](10, 4) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [decimal](10, 4) NOT NULL,
	[Timestamp_Column] [timestamp] NOT NULL,
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products_log]    Script Date: 19/9/2019 06:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products_log](
	[LogProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UnitPrice] [decimal](10, 4) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Timestamp_Column] [timestamp] NOT NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_products_log] PRIMARY KEY CLUSTERED 
(
	[LogProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 19/9/2019 06:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[IdRole] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Timestamp_Column] [timestamp] NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userroles]    Script Date: 19/9/2019 06:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userroles](
	[UserID] [int] NOT NULL,
	[IdRole] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 19/9/2019 06:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[UserID] [int] NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[LastSuccesfullLoginDate] [datetime] NULL,
	[Counter] [int] NULL,
	[Timestamp_Column] [timestamp] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[products] ADD  CONSTRAINT [DF_Constraintproducts]  DEFAULT ((1)) FOR [UserID]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT (getdate()) FOR [LastSuccesfullLoginDate]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[users] ([UserID])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_User]
GO
ALTER TABLE [dbo].[orders_details]  WITH CHECK ADD  CONSTRAINT [FK_orders_details_orders] FOREIGN KEY([OrdersID])
REFERENCES [dbo].[orders] ([OrdersID])
GO
ALTER TABLE [dbo].[orders_details] CHECK CONSTRAINT [FK_orders_details_orders]
GO
ALTER TABLE [dbo].[orders_details]  WITH CHECK ADD  CONSTRAINT [FK_orders_details_products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[products] ([ProductID])
GO
ALTER TABLE [dbo].[orders_details] CHECK CONSTRAINT [FK_orders_details_products]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[categories] ([CategoryID])
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_Products_Category]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_Products_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[users] ([UserID])
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_Products_User]
GO
ALTER TABLE [dbo].[products_log]  WITH CHECK ADD  CONSTRAINT [FK_products_log_categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[categories] ([CategoryID])
GO
ALTER TABLE [dbo].[products_log] CHECK CONSTRAINT [FK_products_log_categories]
GO
ALTER TABLE [dbo].[products_log]  WITH CHECK ADD  CONSTRAINT [FK_products_log_users] FOREIGN KEY([UserID])
REFERENCES [dbo].[users] ([UserID])
GO
ALTER TABLE [dbo].[products_log] CHECK CONSTRAINT [FK_products_log_users]
GO
ALTER TABLE [dbo].[userroles]  WITH CHECK ADD  CONSTRAINT [FK_users__roles] FOREIGN KEY([IdRole])
REFERENCES [dbo].[roles] ([IdRole])
GO
ALTER TABLE [dbo].[userroles] CHECK CONSTRAINT [FK_users__roles]
GO
ALTER TABLE [dbo].[userroles]  WITH CHECK ADD  CONSTRAINT [FK_users_users] FOREIGN KEY([UserID])
REFERENCES [dbo].[users] ([UserID])
GO
ALTER TABLE [dbo].[userroles] CHECK CONSTRAINT [FK_users_users]
GO
USE [master]
GO
ALTER DATABASE [SNACKSTORE] SET  READ_WRITE 
GO
