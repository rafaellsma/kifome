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
SET IDENTITY_INSERT [dbo].[Meal] OFF
SET IDENTITY_INSERT [dbo].[Withdrawal] ON 

INSERT [dbo].[Withdrawal] ([longitude], [latitude], [street], [number], [CEP], [initialHour], [finalHour], [id], [seller_id]) VALUES (-8.28281, 36.4994, N'Rua Desembargador João Paes', 729, N'51021360', CAST(N'2018-01-18T12:00:00.000' AS DateTime), CAST(N'2018-01-18T14:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Withdrawal] OFF
