USE [master]
GO
/****** Object:  Database [Kifome]    Script Date: 17/01/2018 22:11:13 ******/
CREATE DATABASE [Kifome]
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
/****** Object:  Table [dbo].[Comment]    Script Date: 17/01/2018 22:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConfiguredMeal]    Script Date: 17/01/2018 22:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfiguredMeal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[meal_id] [int] NOT NULL,
 CONSTRAINT [PK_OrderMeal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ConfiguredMeal] UNIQUE NONCLUSTERED 
(
	[meal_id] ASC,
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Withdrawal]    Script Date: 17/01/2018 22:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Withdrawal](
	[longitude] [float] NOT NULL,
	[latitude] [float] NOT NULL,
	[street] [varchar](50) NOT NULL,
	[number] [int] NOT NULL,
	[CEP] [varchar](10) NOT NULL,
	[initialHour] [datetime] NOT NULL,
	[finalHour] [datetime] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[seller_id] [int] NOT NULL,
 CONSTRAINT [PK_Withdrawal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Garnish]    Script Date: 17/01/2018 22:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Meal]    Script Date: 17/01/2018 22:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MealGarnish]    Script Date: 17/01/2018 22:11:13 ******/
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
/****** Object:  Table [dbo].[Menu]    Script Date: 17/01/2018 22:11:13 ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 17/01/2018 22:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[status] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[seller_id] [int] NOT NULL,
	[withdrawal_id] [int] NOT NULL,
 CONSTRAINT [PK_Order_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SelectedGarnish]    Script Date: 17/01/2018 22:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SelectedGarnish](
	[garnish_id] [int] NOT NULL,
	[configured_meal_id] [int] NOT NULL,
 CONSTRAINT [PK_SelectedGarnish] PRIMARY KEY CLUSTERED 
(
	[configured_meal_id] ASC,
	[garnish_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 17/01/2018 22:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[rate] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
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
ALTER TABLE [dbo].[ConfiguredMeal]  WITH CHECK ADD  CONSTRAINT [FK_ConfiguredMeal_Meal] FOREIGN KEY([meal_id])
REFERENCES [dbo].[Meal] ([id])
GO
ALTER TABLE [dbo].[ConfiguredMeal] CHECK CONSTRAINT [FK_ConfiguredMeal_Meal]
GO
ALTER TABLE [dbo].[ConfiguredMeal]  WITH CHECK ADD  CONSTRAINT [FK_ConfiguredMeal_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[ConfiguredMeal] CHECK CONSTRAINT [FK_ConfiguredMeal_Order]
GO
ALTER TABLE [dbo].[Withdrawal]  WITH CHECK ADD  CONSTRAINT [FK_Withdrawal_Seller] FOREIGN KEY([seller_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Withdrawal] CHECK CONSTRAINT [FK_Withdrawal_Seller]
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
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Withdrawal] FOREIGN KEY([withdrawal_id])
REFERENCES [dbo].[Withdrawal] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Withdrawal]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Seller] FOREIGN KEY([seller_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Seller]
GO
ALTER TABLE [dbo].[SelectedGarnish]  WITH CHECK ADD  CONSTRAINT [FK_SelectedGarnish_ConfiguredMeal] FOREIGN KEY([configured_meal_id])
REFERENCES [dbo].[ConfiguredMeal] ([id])
GO
ALTER TABLE [dbo].[SelectedGarnish] CHECK CONSTRAINT [FK_SelectedGarnish_ConfiguredMeal]
GO
ALTER TABLE [dbo].[SelectedGarnish]  WITH CHECK ADD  CONSTRAINT [FK_SelectedGarnish_Garnish] FOREIGN KEY([garnish_id])
REFERENCES [dbo].[Garnish] ([id])
GO
ALTER TABLE [dbo].[SelectedGarnish] CHECK CONSTRAINT [FK_SelectedGarnish_Garnish]
GO
USE [master]
GO
ALTER DATABASE [Kifome] SET  READ_WRITE 
GO
