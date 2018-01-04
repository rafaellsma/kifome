USE [master]
GO
/****** Object:  Database [Kifome]    Script Date: 04/01/2018 12:31:42 ******/
CREATE DATABASE [Kifome]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kifome', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Kifome.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Kifome_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Kifome_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Kifome] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kifome].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kifome] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kifome] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kifome] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kifome] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kifome] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kifome] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Kifome] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kifome] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kifome] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kifome] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kifome] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kifome] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kifome] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kifome] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kifome] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Kifome] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kifome] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kifome] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kifome] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kifome] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kifome] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kifome] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kifome] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Kifome] SET  MULTI_USER 
GO
ALTER DATABASE [Kifome] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kifome] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kifome] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kifome] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Kifome] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Kifome]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[message] [varchar](max) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[local] [varchar](50) NOT NULL,
	[initialHour] [datetime] NOT NULL,
	[finalHour] [datetime] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[seller_id] [int] NOT NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Garnish]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Garnish](
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Garnish] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meal]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meal](
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
	[price] [float] NOT NULL,
	[day] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[menu_id] [int] NOT NULL,
 CONSTRAINT [PK_Meal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MealGarnish]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealGarnish](
	[meal_id] [int] NOT NULL,
	[garnish_id] [int] NOT NULL,
 CONSTRAINT [PK_MealGarnish] PRIMARY KEY CLUSTERED 
(
	[meal_id] ASC,
	[garnish_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[initialTimeToOrder] [datetime] NOT NULL,
	[finalTimeToOrder] [datetime] NOT NULL,
	[limitOfMeals] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[seller_id] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuMeal]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuMeal](
	[menu_id] [int] NOT NULL,
	[meal_id] [int] NOT NULL,
 CONSTRAINT [PK_MenuMeal] PRIMARY KEY CLUSTERED 
(
	[meal_id] ASC,
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[status] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[seller_id] [int] NOT NULL,
	[delivery_id] [int] NOT NULL,
 CONSTRAINT [PK_Order_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderMeal]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderMeal](
	[order_id] [int] NOT NULL,
	[order_meal] [int] NOT NULL,
 CONSTRAINT [PK_OrderMeal] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[order_meal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04/01/2018 12:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[rate] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[discriminator] [char](1) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Order]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_Seller] FOREIGN KEY([seller_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_Seller]
GO
ALTER TABLE [dbo].[Meal]  WITH CHECK ADD  CONSTRAINT [FK_Meal_Menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[Menu] ([id])
GO
ALTER TABLE [dbo].[Meal] CHECK CONSTRAINT [FK_Meal_Menu]
GO
ALTER TABLE [dbo].[MealGarnish]  WITH CHECK ADD  CONSTRAINT [FK_MealGarnish_Garnish] FOREIGN KEY([garnish_id])
REFERENCES [dbo].[Garnish] ([id])
GO
ALTER TABLE [dbo].[MealGarnish] CHECK CONSTRAINT [FK_MealGarnish_Garnish]
GO
ALTER TABLE [dbo].[MealGarnish]  WITH CHECK ADD  CONSTRAINT [FK_MealGarnish_Meal] FOREIGN KEY([meal_id])
REFERENCES [dbo].[Meal] ([id])
GO
ALTER TABLE [dbo].[MealGarnish] CHECK CONSTRAINT [FK_MealGarnish_Meal]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Seller] FOREIGN KEY([seller_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Seller]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Delivery] FOREIGN KEY([delivery_id])
REFERENCES [dbo].[Delivery] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Delivery]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Seller] FOREIGN KEY([seller_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Seller]
GO
ALTER TABLE [dbo].[OrderMeal]  WITH CHECK ADD  CONSTRAINT [FK_OrderMeal_Meal] FOREIGN KEY([order_meal])
REFERENCES [dbo].[Meal] ([id])
GO
ALTER TABLE [dbo].[OrderMeal] CHECK CONSTRAINT [FK_OrderMeal_Meal]
GO
ALTER TABLE [dbo].[OrderMeal]  WITH CHECK ADD  CONSTRAINT [FK_OrderMeal_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[OrderMeal] CHECK CONSTRAINT [FK_OrderMeal_Order]
GO
USE [master]
GO
ALTER DATABASE [Kifome] SET  READ_WRITE 
GO
