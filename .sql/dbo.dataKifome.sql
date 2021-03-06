USE [Kifome]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([email], [password], [name], [rate], [id]) VALUES (N'joao.lins@pitang.com', N'123456', N'João Paulo Lins', 0, 1)
INSERT [dbo].[User] ([email], [password], [name], [rate], [id]) VALUES (N'vinicius.santana@pitang.com', N'123456', N'Vinicius Santana', 0, 2)
INSERT [dbo].[User] ([email], [password], [name], [rate], [id]) VALUES (N'rafael.albuquerque@pitang.com', N'123456', N'Rafael Albuquerque', 0, 3)
SET IDENTITY_INSERT [dbo].[User] OFF
INSERT [dbo].[Menu] ([initialTimeToOrder], [finalTimeToOrder], [limitOfMeals], [id], [seller_id]) VALUES (CAST(N'2018-01-18T07:00:00.000' AS DateTime), CAST(N'2018-01-18T10:00:00.000' AS DateTime), 40, 1, 1)
INSERT [dbo].[Menu] ([initialTimeToOrder], [finalTimeToOrder], [limitOfMeals], [id], [seller_id]) VALUES (CAST(N'2018-01-18T08:00:00.000' AS DateTime), CAST(N'2018-01-18T11:00:00.000' AS DateTime), 50, 2, 2)
SET IDENTITY_INSERT [dbo].[Meal] ON 

INSERT [dbo].[Meal] ([name], [description], [price], [day], [id], [menu_id]) VALUES (N'Filé de Frango à Parmegiana', N'Frango empanado com queijo mussarela ao molho tomate', 7, 1, 1, 1)
INSERT [dbo].[Meal] ([name], [description], [price], [day], [id], [menu_id]) VALUES (N'Filé ao Molho Madeira', N'Bife fritado com cebolas refogadas, champignon e molho de vinho tinto.', 10, 2, 3, 1)
SET IDENTITY_INSERT [dbo].[Meal] OFF
SET IDENTITY_INSERT [dbo].[Withdrawal] ON 

INSERT [dbo].[Withdrawal] ([longitude], [latitude], [street], [number], [CEP], [initialHour], [finalHour], [id], [seller_id]) VALUES (-8.28281, 36.4994, N'Rua Desembargador João Paes', 729, N'51021360', CAST(N'2018-01-18T12:00:00.000' AS DateTime), CAST(N'2018-01-18T14:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Withdrawal] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([status], [id], [customer_id], [seller_id], [withdrawal_id]) VALUES (3, 1, 1, 2, 1)
INSERT [dbo].[Order] ([status], [id], [customer_id], [seller_id], [withdrawal_id]) VALUES (2, 2, 1, 2, 1)
INSERT [dbo].[Order] ([status], [id], [customer_id], [seller_id], [withdrawal_id]) VALUES (2, 3, 1, 2, 1)
INSERT [dbo].[Order] ([status], [id], [customer_id], [seller_id], [withdrawal_id]) VALUES (1, 4, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[ConfiguredMeal] ON 

INSERT [dbo].[ConfiguredMeal] ([id], [order_id], [meal_id]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[ConfiguredMeal] OFF
SET IDENTITY_INSERT [dbo].[Garnish] ON 

INSERT [dbo].[Garnish] ([name], [description], [seller_id], [id]) VALUES (N'Arroz Branco', N'Arroz branco de grão longo, cozinhado.', 1, 1)
INSERT [dbo].[Garnish] ([name], [description], [seller_id], [id]) VALUES (N'Feijão Preto', N'Grãos de feijão cozinhados e temperados.', 1, 2)
INSERT [dbo].[Garnish] ([name], [description], [seller_id], [id]) VALUES (N'Vinagrete', N'Tomate e cebola picados, temperados com vinagre.', 1, 3)
INSERT [dbo].[Garnish] ([name], [description], [seller_id], [id]) VALUES (N'Arroz a Grega', N'Arroz cozinhado com pimentão, cebola, salsa, cebolinha verde e cenoura a gosto, finalizado com uvas passas', 1, 4)
INSERT [dbo].[Garnish] ([name], [description], [seller_id], [id]) VALUES (N'Purê de Batata', N'Batatas cozidas com margarina, ovo e leite', 1, 5)
INSERT [dbo].[Garnish] ([name], [description], [seller_id], [id]) VALUES (N'Batata Frita', N'Batatas cortadas em tiras e fritas', 1, 6)
INSERT [dbo].[Garnish] ([name], [description], [seller_id], [id]) VALUES (N'Farofa de Feijão Macassar', N'Feijão macassar, bacon e linguiça calabresa', 1, 7)
SET IDENTITY_INSERT [dbo].[Garnish] OFF
INSERT [dbo].[SelectedGarnish] ([garnish_id], [configured_meal_id]) VALUES (1, 1)
INSERT [dbo].[SelectedGarnish] ([garnish_id], [configured_meal_id]) VALUES (2, 1)
INSERT [dbo].[SelectedGarnish] ([garnish_id], [configured_meal_id]) VALUES (3, 1)
INSERT [dbo].[MealGarnish] ([meal_id], [garnish_id]) VALUES (3, 1)
INSERT [dbo].[MealGarnish] ([meal_id], [garnish_id]) VALUES (3, 3)
INSERT [dbo].[MealGarnish] ([meal_id], [garnish_id]) VALUES (3, 4)
INSERT [dbo].[MealGarnish] ([meal_id], [garnish_id]) VALUES (3, 5)
INSERT [dbo].[MealGarnish] ([meal_id], [garnish_id]) VALUES (3, 7)
