USE [QuickMarket]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[UserID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinancialTransactions]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinancialTransactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[TransactionType] [varchar](50) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK__Financia__55433A4B2ED35ADF] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessID] [int] IDENTITY(1,1) NOT NULL,
	[FromUserID] [int] NOT NULL,
	[ToUserID] [int] NOT NULL,
	[MessageText] [text] NOT NULL,
	[SentTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](255) NOT NULL,
	[Description] [text] NULL,
	[StatusId] [nvarchar](50) NULL,
 CONSTRAINT [PK__ProductC__19093A2BCD6A00CA] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[ImageURL] [varchar](255) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReviews]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReviews](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[UserID] [int] NULL,
	[Comment] [nvarchar](2000) NULL,
	[ReviewDate] [datetime] NOT NULL,
	[ThreadId] [int] NULL,
 CONSTRAINT [PK__ProductR__74BC79AE6D1AB213] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CategoryID] [int] NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[DatePosted] [datetime] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Products__B40CC6ED9C90F943] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[BuyerID] [int] NULL,
	[SellerID] [int] NULL,
	[ProductID] [int] NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Transact__55433A4BED3D5DC7] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[PasswordHash] [varchar](255) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastLogin] [datetime] NULL,
	[RoldeID] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK__Users__1788CCACE58D8B40] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserShipped]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserShipped](
	[TransactionID] [int] NOT NULL,
	[AddressLine1] [nvarchar](500) NOT NULL,
	[AddressLine2] [nvarchar](500) NULL,
	[City] [nvarchar](500) NULL,
	[State] [nvarchar](500) NULL,
	[Country] [nvarchar](500) NULL,
	[PostalCode] [nvarchar](500) NULL,
	[AddressType] [nvarchar](500) NULL,
	[DateAdded] [datetime] NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK__UserAddr__091C2A1BED36E446] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallet]    Script Date: 7/21/2024 5:44:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallet](
	[UserID] [int] NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Wallet] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (1, 3, CAST(N'2024-03-22T05:06:41.830' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (1, 13, CAST(N'2024-03-22T08:44:04.283' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (4, 3, CAST(N'2024-03-22T02:34:25.117' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (4, 5, CAST(N'2024-03-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (4, 12, CAST(N'2024-03-22T08:41:52.120' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (5, 3, CAST(N'2024-03-23T02:37:41.777' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (5, 5, CAST(N'2024-03-23T03:05:26.967' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (5, 6, CAST(N'2024-03-23T03:05:39.237' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (7, 3, CAST(N'2024-03-22T21:34:09.837' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (32, 3, CAST(N'2024-03-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (32, 5, CAST(N'2024-07-10T14:17:33.117' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (32, 6, CAST(N'2024-07-10T14:17:35.230' AS DateTime))
INSERT [dbo].[Favorites] ([UserID], [ProductID], [DateAdded]) VALUES (32, 8, CAST(N'2024-07-14T21:51:18.343' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[FinancialTransactions] ON 

INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (7, 1, N'VND', CAST(2000.00 AS Decimal(18, 2)), CAST(N'2024-02-06T17:12:32.650' AS DateTime), N'Failed', N'CODE055904')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (8, 1, N'VND', CAST(213321.00 AS Decimal(18, 2)), CAST(N'2024-02-06T17:45:48.060' AS DateTime), N'Pending', N'CODE243602')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (9, 1, N'VND', CAST(213321.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:14:45.663' AS DateTime), N'Pending', N'CODE803474')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (10, 1, N'VND', CAST(213321.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:15:20.957' AS DateTime), N'Pending', N'CODE408672')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (11, 1, N'VND', CAST(3310000.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:15:34.043' AS DateTime), N'Pending', N'CODE440121')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (12, 1, N'VND', CAST(13.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:17:36.393' AS DateTime), N'Pending', N'CODE824359')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (13, 1, N'VND', CAST(123312.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:17:50.970' AS DateTime), N'Pending', N'CODE128682')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (14, 1, N'VND', CAST(213321.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:18:00.123' AS DateTime), N'Pending', N'CODE369570')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (15, 1, N'VND', CAST(213321.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:18:20.573' AS DateTime), N'Pending', N'CODE513831')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (16, 1, N'VND', CAST(123312.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:18:29.973' AS DateTime), N'Pending', N'CODE450241')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (17, 1, N'VND', CAST(312.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:30:32.810' AS DateTime), N'Pending', N'CODE702157')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (18, 1, N'VND', CAST(123312.00 AS Decimal(18, 2)), CAST(N'2024-02-06T18:32:17.657' AS DateTime), N'Pending', N'CODE166715')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (19, 1, N'VND', CAST(5000.00 AS Decimal(18, 2)), CAST(N'2024-02-07T21:55:31.633' AS DateTime), N'Successful', N'CODE230598')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (20, 1, N'VND', CAST(213321.00 AS Decimal(18, 2)), CAST(N'2024-02-19T08:49:14.083' AS DateTime), N'Pending', N'CODE282242')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (1020, 1, N'VND', CAST(5000.00 AS Decimal(18, 2)), CAST(N'2024-03-12T11:29:47.053' AS DateTime), N'Pending', N'CODE271346')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (1021, 1, N'VND', CAST(5000.00 AS Decimal(18, 2)), CAST(N'2024-03-12T11:32:25.653' AS DateTime), N'Successful', N'CODE561722')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (2020, 7, N'VND', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-03-21T22:24:07.497' AS DateTime), N'Successful', N'CODE468139')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (2021, 7, N'VND', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-03-21T22:28:05.647' AS DateTime), N'Successful', N'CODE857421')
INSERT [dbo].[FinancialTransactions] ([TransactionID], [UserID], [TransactionType], [Amount], [TransactionDate], [Status], [Description]) VALUES (2022, 1, N'VND', CAST(5000.00 AS Decimal(18, 2)), CAST(N'2024-03-22T00:19:45.363' AS DateTime), N'Successful', N'CODE337768')
SET IDENTITY_INSERT [dbo].[FinancialTransactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (1, 32, 1, N'tung day ', CAST(N'2024-03-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (2, 1, 32, N'sao har', CAST(N'2024-03-21T19:06:23.413' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (3, 1, 32, N'ha', CAST(N'2024-03-21T21:46:26.837' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (4, 32, 7, N'ha', CAST(N'2024-03-21T21:59:43.910' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (5, 32, 1, N'oi', CAST(N'2024-03-21T15:03:00.317' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (6, 32, 7, N'hi', CAST(N'2024-03-21T15:04:08.253' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (7, 7, 32, N'oi', CAST(N'2024-03-21T22:08:18.300' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (8, 32, 7, N'hi', CAST(N'2024-03-21T15:08:29.653' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (9, 32, 7, N'hi', CAST(N'2024-03-21T15:08:30.380' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (10, 32, 7, N'hi', CAST(N'2024-03-21T15:08:32.063' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (11, 32, 7, N'hi', CAST(N'2024-03-21T15:08:32.563' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (12, 32, 7, N'hi', CAST(N'2024-03-21T15:08:32.703' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (13, 32, 7, N'hi', CAST(N'2024-03-21T15:08:32.853' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (14, 7, 32, N'G? c?u', CAST(N'2024-03-21T15:08:56.007' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (15, 32, 7, N'zô', CAST(N'2024-03-21T15:09:02.807' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (16, 7, 32, N'hid', CAST(N'2024-03-21T15:10:17.953' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (17, 7, 32, N'a', CAST(N'2024-03-21T15:11:25.553' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (18, 7, 32, N'a', CAST(N'2024-03-21T15:11:28.340' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (19, 7, 32, N'aa', CAST(N'2024-03-21T15:11:38.953' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (20, 7, 32, N'aa', CAST(N'2024-03-21T15:11:39.427' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (21, 7, 32, N'aa', CAST(N'2024-03-21T15:11:39.573' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (22, 7, 32, N'aa', CAST(N'2024-03-21T15:11:39.727' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (23, 7, 32, N'aa', CAST(N'2024-03-21T15:11:39.893' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (24, 7, 32, N'a', CAST(N'2024-03-21T15:12:10.050' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (25, 7, 32, N'a', CAST(N'2024-03-21T15:12:10.670' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (26, 7, 32, N'ad', CAST(N'2024-03-21T15:12:14.167' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (27, 7, 32, N'a', CAST(N'2024-03-21T15:12:18.863' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (28, 32, 7, N'sao h?', CAST(N'2024-03-21T15:12:43.620' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (29, 1, 32, N'd', CAST(N'2024-03-21T16:55:43.007' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (30, 1, 1, N'r', CAST(N'2024-03-21T22:10:51.647' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (31, 7, 4, N'.', CAST(N'2024-03-22T02:07:23.957' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (32, 7, 32, N'a', CAST(N'2024-03-22T02:17:38.167' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (33, 7, 32, N'a', CAST(N'2024-03-22T02:18:04.013' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (34, 7, 32, N'a', CAST(N'2024-03-22T02:18:05.180' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (35, 7, 32, N'a', CAST(N'2024-03-22T02:18:05.673' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (36, 1, 1, N'e', CAST(N'2024-03-22T18:12:44.057' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (37, 32, 1, N'e', CAST(N'2024-03-22T18:12:58.193' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (38, 1, 32, N'e', CAST(N'2024-03-22T18:13:07.933' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (39, 32, 1, N'sao h?', CAST(N'2024-03-22T18:13:15.043' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (40, 32, 1, N'sao h?', CAST(N'2024-03-22T18:13:19.053' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (41, 32, 1, N'a', CAST(N'2024-03-22T18:15:11.373' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (42, 32, 1, N'a', CAST(N'2024-03-22T18:15:14.747' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (43, 32, 1, N'a', CAST(N'2024-03-22T18:15:25.023' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (44, 1, 32, N'a', CAST(N'2024-03-22T18:18:39.617' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (45, 1, 32, N'a', CAST(N'2024-03-22T18:18:44.283' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (46, 32, 1, N'a', CAST(N'2024-07-10T07:17:50.633' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (47, 1, 1, N'qeqwee', CAST(N'2024-07-10T07:21:03.053' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (48, 1, 1, N'aaaaa', CAST(N'2024-07-10T07:21:23.990' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (49, 32, 1, N'eqwe', CAST(N'2024-07-10T07:22:01.440' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (50, 1, 32, N'saoas', CAST(N'2024-07-10T07:22:17.550' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (51, 32, 1, N'eqwe', CAST(N'2024-07-10T07:22:25.477' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (52, 32, 1, N'aaaaaa', CAST(N'2024-07-10T07:22:42.577' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (2046, 1, 32, N'sdasd', CAST(N'2024-07-14T14:35:23.040' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (2047, 1, 32, N'????', CAST(N'2024-07-14T14:42:05.720' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (2048, 32, 1, N'queqwe', CAST(N'2024-07-14T14:42:36.027' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (2049, 1, 32, N'?a ', CAST(N'2024-07-14T14:42:41.403' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (2050, 32, 4, N'eqwe', CAST(N'2024-07-14T15:03:27.627' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (2051, 32, 4, N'eqwe', CAST(N'2024-07-14T15:03:30.410' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (2052, 32, 1, N'eqweqw', CAST(N'2024-07-14T16:07:38.880' AS DateTime))
INSERT [dbo].[Messages] ([MessID], [FromUserID], [ToUserID], [MessageText], [SentTime]) VALUES (2053, 32, 1, N'qqqq', CAST(N'2024-07-14T16:07:46.167' AS DateTime))
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategories] ON 

INSERT [dbo].[ProductCategories] ([CategoryID], [CategoryName], [Description], [StatusId]) VALUES (1, N'Electrolic', N'elec', N'InActive')
INSERT [dbo].[ProductCategories] ([CategoryID], [CategoryName], [Description], [StatusId]) VALUES (2, N'Green ', N'Green', N'Active')
INSERT [dbo].[ProductCategories] ([CategoryID], [CategoryName], [Description], [StatusId]) VALUES (3, N'Home', N'Home', N'InActive')
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (4, NULL, N'https://cdn.tgdd.vn/Products/Images/44/312414/Slider/vi-vn-asus-vivobook-15-x1504za-i3-nj102w-slider-2.jpg', CAST(N'2024-03-19T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (5, NULL, N'https://cdn.tgdd.vn/Products/Images/44/312414/Slider/vi-vn-asus-vivobook-15-x1504za-i3-nj102w-slider-3.jpg', CAST(N'2024-03-19T01:13:06.370' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (8, 5, N'https://th.bing.com/th/id/R.fce01bdf529424e3659eaf9ce0fea42f?rik=YRPbMPcS0Ktkkw&pid=ImgRaw&r=0', CAST(N'2024-03-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (11, 5, N'https://i.pinimg.com/originals/1b/fe/7c/1bfe7cc28f27873908c7c6683568800b.jpg', CAST(N'2024-03-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (12, 5, N'https://www.lg.com/ae/images/monitors/MD06247416/gallery/350_01.jpg', CAST(N'2024-03-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (14, 6, N'https://th.bing.com/th/id/OIP.DYDydRkoFUHACiHsCTuwYgAAAA?rs=1&pid=ImgDetMain', CAST(N'2024-03-21T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (15, 7, N'https://thienphucons.com/wp-content/uploads/2020/01/nh%C3%A0-m%C3%A1i-th%C3%A1i.jpg', CAST(N'2024-03-22T03:08:05.460' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (16, NULL, N'https://cf.shopee.vn/file/sg-11134201-22120-gu6nva6qr8kv92', CAST(N'2024-03-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (17, NULL, N'https://ae01.alicdn.com/kf/H676c5511453c4ffda93e6f348ae4ac24H/Deli-Pokemon-Mechanical-Pencils-Cute-Pikachu-Mechanical-Pencil-Refills-Student-Writing-Stationery-School-Supplies-Kids-Pencil.jpg', CAST(N'2024-03-21T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (18, 9, N'https://th.bing.com/th/id/OIP.LzUrfCwLHR33O_29djE-IwAAAA?w=350&h=350&rs=1&pid=ImgDetMain', CAST(N'2024-03-17T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (19, 13, N'https://th.bing.com/th/id/R.f77a9961d2c0c193be0d28d47716e81f?rik=U2yCYzRVyk4Nrg&pid=ImgRaw&r=0', CAST(N'2024-03-12T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (20, 14, N'https://th.bing.com/th/id/OIP.gDv6i3wLnq6qtx6Q5JIHKQHaFz?rs=1&pid=ImgDetMainL', CAST(N'2024-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (22, 14, N'https://th.bing.com/th/id/OIP.OLMs2ii5ujsseFjs5GzXiwHaE8?rs=1&pid=ImgDetMain', CAST(N'2024-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (23, 15, N'https://i5.walmartimages.com/asr/9ad82e70-420f-459e-ac76-7de603042269.827a20c07cccaaafc9b6943342ccfcce.jpeg', CAST(N'2024-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (24, 16, N'https://th.bing.com/th/id/R.4cf86e481aaaa4ea091d9779707af186?rik=qBfgtJ%2fqA%2fmTew&pid=ImgRaw&r=0', CAST(N'2024-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (25, 16, N'https://th.bing.com/th/id/OIP.JNyPzK_uljpmuK2y851oTgAAAA?rs=1&pid=ImgDetMain', CAST(N'2024-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (26, 17, N'https://th.bing.com/th/id/OIP.hDlUjPoA9tEE6DjDXo1GmgHaE7?w=295&h=197&c=7&r=0&o=5&pid=1.7', CAST(N'2024-03-22T05:13:44.353' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (27, NULL, N'eqweqwe', CAST(N'2024-07-14T16:24:54.203' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (28, NULL, N'eqwe', CAST(N'2024-07-14T16:25:07.567' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (29, NULL, N'eqwe', CAST(N'2024-07-14T16:25:07.570' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (30, NULL, N'aaaaaaaaaaaaaaa', CAST(N'2024-07-14T16:25:17.703' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (31, NULL, N'ueqweqwe', CAST(N'2024-07-14T16:33:38.363' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (32, NULL, N'eqwe', CAST(N'2024-07-14T16:33:59.747' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (33, NULL, N'eqqqqqqqqqq', CAST(N'2024-07-14T16:33:59.750' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (34, NULL, N'ewqeqwe', CAST(N'2024-07-14T16:35:54.280' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (35, NULL, N'eqwe', CAST(N'2024-07-14T16:36:15.560' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (36, NULL, N'eqwe', CAST(N'2024-07-14T16:36:15.560' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (37, NULL, N'eqwe', CAST(N'2024-07-14T16:36:15.560' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (38, 8, N'eqweq', CAST(N'2024-07-14T16:38:10.283' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (1027, NULL, N'eqwe', CAST(N'2024-07-21T17:25:18.860' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (1028, NULL, N'eqwe', CAST(N'2024-07-21T17:25:18.870' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (1029, 18, N'qeqwe', CAST(N'2024-07-21T10:25:28.980' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (1030, NULL, N'https://cdn.tgdd.vn/Products/Images/44/312414/Slider/vi-vn-asus-vivobook-15-x1504za-i3-nj102w-slider-2.jpg', CAST(N'2024-07-21T10:32:23.447' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (1031, NULL, N'https://cdn.tgdd.vn/Products/Images/44/312414/Slider/vi-vn-asus-vivobook-15-x1504za-i3-nj102w-slider-3.jpg', CAST(N'2024-07-21T10:32:23.447' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (1032, NULL, N'https://cdn.tgdd.vn/Products/Images/44/312414/Slider/vi-vn-asus-vivobook-15-x1504za-i3-nj102w-slider-2.jpg', CAST(N'2024-07-21T10:33:55.807' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (1033, NULL, N'https://cdn.tgdd.vn/Products/Images/44/312414/Slider/vi-vn-asus-vivobook-15-x1504za-i3-nj102w-slider-3.jpg', CAST(N'2024-07-21T10:33:55.807' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (1034, 3, N'https://cdn.tgdd.vn/Products/Images/44/312414/Slider/vi-vn-asus-vivobook-15-x1504za-i3-nj102w-slider-2.jpg', CAST(N'2024-07-21T10:34:05.487' AS DateTime))
INSERT [dbo].[ProductImages] ([ImageID], [ProductID], [ImageURL], [DateAdded]) VALUES (1035, 3, N'https://cdn.tgdd.vn/Products/Images/44/312414/Slider/vi-vn-asus-vivobook-15-x1504za-i3-nj102w-slider-3.jpg', CAST(N'2024-07-21T10:34:05.487' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductReviews] ON 

INSERT [dbo].[ProductReviews] ([ReviewID], [ProductID], [UserID], [Comment], [ReviewDate], [ThreadId]) VALUES (1, 3, 1, N'Haha', CAST(N'2024-03-23T00:01:09.990' AS DateTime), NULL)
INSERT [dbo].[ProductReviews] ([ReviewID], [ProductID], [UserID], [Comment], [ReviewDate], [ThreadId]) VALUES (4, 3, 5, N'OK', CAST(N'2024-03-23T00:01:40.823' AS DateTime), 1)
INSERT [dbo].[ProductReviews] ([ReviewID], [ProductID], [UserID], [Comment], [ReviewDate], [ThreadId]) VALUES (5, 3, 4, N'OKHAHA', CAST(N'2024-03-23T00:06:50.620' AS DateTime), 1)
INSERT [dbo].[ProductReviews] ([ReviewID], [ProductID], [UserID], [Comment], [ReviewDate], [ThreadId]) VALUES (6, 3, 32, N'Hoho', CAST(N'2024-03-23T00:07:15.573' AS DateTime), NULL)
INSERT [dbo].[ProductReviews] ([ReviewID], [ProductID], [UserID], [Comment], [ReviewDate], [ThreadId]) VALUES (19, 3, 32, N'a', CAST(N'2024-03-23T01:37:24.833' AS DateTime), NULL)
INSERT [dbo].[ProductReviews] ([ReviewID], [ProductID], [UserID], [Comment], [ReviewDate], [ThreadId]) VALUES (20, 3, 32, N'Cooment', CAST(N'2024-03-23T01:40:21.713' AS DateTime), NULL)
INSERT [dbo].[ProductReviews] ([ReviewID], [ProductID], [UserID], [Comment], [ReviewDate], [ThreadId]) VALUES (21, 3, 32, N'eqwe', CAST(N'2024-03-23T01:40:45.047' AS DateTime), 20)
INSERT [dbo].[ProductReviews] ([ReviewID], [ProductID], [UserID], [Comment], [ReviewDate], [ThreadId]) VALUES (22, 3, 32, N'qqq', CAST(N'2024-03-23T01:41:16.723' AS DateTime), 20)
INSERT [dbo].[ProductReviews] ([ReviewID], [ProductID], [UserID], [Comment], [ReviewDate], [ThreadId]) VALUES (23, 3, 32, N'eqwe', CAST(N'2024-07-14T21:43:07.893' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ProductReviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (3, 1, 2, N'Laptop Asus', N'Laptop 88', CAST(99999.00 AS Decimal(10, 2)), CAST(N'2024-03-19T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (5, 4, 1, N'TV LG', N'TV mới mua được 2 tháng còn bảo hành 3 năm', CAST(88888.00 AS Decimal(10, 2)), CAST(N'2024-03-21T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (6, 30, 1, N'Airpod', N'tai nghe', CAST(10000.00 AS Decimal(10, 2)), CAST(N'2024-02-02T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (7, 31, 2, N'HOME', N'home', CAST(999999.00 AS Decimal(10, 2)), CAST(N'2024-02-02T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (8, 32, 2, N'pen', N'pen', CAST(191919.00 AS Decimal(10, 2)), CAST(N'2024-02-02T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (9, 6, 2, N'notebook', N'notebook', CAST(2000.00 AS Decimal(10, 2)), CAST(N'2024-03-19T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (12, 6, 2, N'book', N'book', CAST(1990.00 AS Decimal(10, 2)), CAST(N'2024-03-20T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (13, 7, 3, N'pen red', N'red', CAST(2002.00 AS Decimal(10, 2)), CAST(N'2024-03-03T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (14, 8, 2, N'book Green', N'green', CAST(3000.00 AS Decimal(10, 2)), CAST(N'2024-03-03T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (15, 5, 1, N'mouse', N'mouse', CAST(2005.00 AS Decimal(10, 2)), CAST(N'2024-03-03T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (16, 33, 1, N'PC', N'PC', CAST(2007.00 AS Decimal(10, 2)), CAST(N'2024-03-03T00:00:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (17, 1, 2, N'Air Condition', N'Pass Đi?u h?a giá r?', CAST(12321.00 AS Decimal(10, 2)), CAST(N'2024-03-22T05:13:00.000' AS DateTime), N'Active')
INSERT [dbo].[Products] ([ProductID], [UserID], [CategoryID], [Name], [Description], [Price], [DatePosted], [Status]) VALUES (18, 1, 1, N'eqwe', N'qưeqwe', CAST(3123123.00 AS Decimal(10, 2)), CAST(N'2024-07-21T17:25:00.000' AS DateTime), N'Active')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Manager')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (2, 4, 1, 3, CAST(N'2024-03-19T00:00:00.000' AS DateTime), CAST(10000.00 AS Decimal(18, 2)), N'Pending')
INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (9, 32, 1, 3, CAST(N'2024-03-22T05:37:47.127' AS DateTime), CAST(260000.00 AS Decimal(18, 2)), N'Successful')
INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (10, 32, 1, 3, CAST(N'2024-03-22T05:38:14.523' AS DateTime), CAST(260000.00 AS Decimal(18, 2)), N'Failed')
INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (11, 32, 1, 3, CAST(N'2024-03-22T05:39:14.157' AS DateTime), CAST(260000.00 AS Decimal(18, 2)), N'Canceled')
INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (12, 32, 1, 3, CAST(N'2024-03-22T05:39:29.397' AS DateTime), CAST(260000.00 AS Decimal(18, 2)), N'Successful')
INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (13, 32, 1, 3, CAST(N'2024-03-22T05:40:09.073' AS DateTime), CAST(260000.00 AS Decimal(18, 2)), N'Successful')
INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (14, 32, 1, 3, CAST(N'2024-03-22T05:41:23.400' AS DateTime), CAST(260000.00 AS Decimal(18, 2)), N'Successful')
INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (15, 5, 1, 3, CAST(N'2024-03-23T03:12:46.257' AS DateTime), CAST(260000.00 AS Decimal(18, 2)), N'Successful')
INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (16, 5, 1, 3, CAST(N'2024-03-23T03:16:35.127' AS DateTime), CAST(260000.00 AS Decimal(18, 2)), N'Successful')
INSERT [dbo].[Transactions] ([TransactionID], [BuyerID], [SellerID], [ProductID], [TransactionDate], [Amount], [Status]) VALUES (17, 32, 1, 3, CAST(N'2024-07-14T14:43:43.093' AS DateTime), CAST(260000.00 AS Decimal(18, 2)), N'Successful')
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (1, N'tung12ok', N'', N'123456', CAST(N'2024-02-03T19:08:46.750' AS DateTime), NULL, 1, N'7')
INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (4, N'tungld', N'1', N'tung', CAST(N'2024-02-04T13:00:32.830' AS DateTime), CAST(N'2024-02-04T13:00:32.830' AS DateTime), 3, N'7')
INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (5, N'tung12k', N'2', N'123456', CAST(N'2024-03-20T15:31:05.473' AS DateTime), NULL, 3, N'7')
INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (6, N'tung12ok1', N'3', N'123456', CAST(N'2024-03-20T18:48:27.327' AS DateTime), NULL, 3, N'10')
INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (7, N'tung12ok2', N'tungvnriot@gmail.com', N'123456', CAST(N'2024-03-21T01:14:18.103' AS DateTime), NULL, 3, N'7')
INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (8, N'tungld1', N'@gmail.com', N'123456', CAST(N'2024-03-21T01:15:45.970' AS DateTime), NULL, 3, N'7')
INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (30, N't123ok', N'tung0208021@gmail.com', N'123456', CAST(N'2024-03-21T01:40:14.323' AS DateTime), NULL, 3, N'7')
INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (31, N't123', N'tung0208012@gmail.com', N'123456', CAST(N'2024-03-21T01:51:30.993' AS DateTime), NULL, 3, N'10')
INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (32, N'tungld123', N'tung020802@gmail.com', N'1234567', CAST(N'2024-03-21T01:55:03.183' AS DateTime), NULL, 3, N'7')
INSERT [dbo].[Users] ([UserID], [Username], [Email], [PasswordHash], [DateCreated], [LastLogin], [RoldeID], [Status]) VALUES (33, N'kien', N'kien@gmail.com', N'123456', CAST(N'2024-03-21T00:00:00.000' AS DateTime), NULL, 3, N'7')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserShipped] ([TransactionID], [AddressLine1], [AddressLine2], [City], [State], [Country], [PostalCode], [AddressType], [DateAdded], [Status]) VALUES (14, N'Ha Noi', N'HN', N'Hà N?i', N'Ha Noi', N'Vietnam', N'15000', N'', CAST(N'2024-03-22T05:41:29.023' AS DateTime), N'11')
INSERT [dbo].[UserShipped] ([TransactionID], [AddressLine1], [AddressLine2], [City], [State], [Country], [PostalCode], [AddressType], [DateAdded], [Status]) VALUES (15, N'Ha Noi', N'HN', N'Hà N?i', N'Ha Noi', N'Vietnam', N'15000', N'', CAST(N'2024-03-23T03:12:48.140' AS DateTime), N'11')
INSERT [dbo].[UserShipped] ([TransactionID], [AddressLine1], [AddressLine2], [City], [State], [Country], [PostalCode], [AddressType], [DateAdded], [Status]) VALUES (16, N'a', N'a', N'Hà N?i', N'Ha Noi', N'Vietnam', N'15000', N'', CAST(N'2024-03-23T03:16:37.707' AS DateTime), N'11')
INSERT [dbo].[UserShipped] ([TransactionID], [AddressLine1], [AddressLine2], [City], [State], [Country], [PostalCode], [AddressType], [DateAdded], [Status]) VALUES (17, N'Ha Noi', N'HN', N'Hà N?i', N'Ha Noi', N'Vietnam', N'15000', N'', CAST(N'2024-07-14T14:43:43.120' AS DateTime), N'11')
GO
INSERT [dbo].[Wallet] ([UserID], [Balance], [LastUpdate]) VALUES (1, CAST(19000.00 AS Decimal(18, 2)), CAST(N'2024-02-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Wallet] ([UserID], [Balance], [LastUpdate]) VALUES (4, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-02-04T13:00:32.863' AS DateTime))
INSERT [dbo].[Wallet] ([UserID], [Balance], [LastUpdate]) VALUES (5, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-03-20T15:31:05.860' AS DateTime))
INSERT [dbo].[Wallet] ([UserID], [Balance], [LastUpdate]) VALUES (6, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-03-20T18:48:28.500' AS DateTime))
INSERT [dbo].[Wallet] ([UserID], [Balance], [LastUpdate]) VALUES (7, CAST(20000.00 AS Decimal(18, 2)), CAST(N'2024-03-21T01:14:18.470' AS DateTime))
INSERT [dbo].[Wallet] ([UserID], [Balance], [LastUpdate]) VALUES (8, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-03-21T01:15:45.963' AS DateTime))
INSERT [dbo].[Wallet] ([UserID], [Balance], [LastUpdate]) VALUES (30, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-03-21T01:40:17.357' AS DateTime))
INSERT [dbo].[Wallet] ([UserID], [Balance], [LastUpdate]) VALUES (31, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-03-21T01:51:33.113' AS DateTime))
INSERT [dbo].[Wallet] ([UserID], [Balance], [LastUpdate]) VALUES (32, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-03-21T01:55:07.067' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Email]    Script Date: 7/21/2024 5:44:49 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UC_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Username]    Script Date: 7/21/2024 5:44:49 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UC_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D1053483FFE6BF]    Script Date: 7/21/2024 5:44:49 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__A9D1053483FFE6BF] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Favorites] ADD  CONSTRAINT [DF__Favorites__DateA__5CD6CB2B]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF__Messages__SentTi__5812160E]  DEFAULT (getdate()) FOR [SentTime]
GO
ALTER TABLE [dbo].[ProductImages] ADD  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[ProductReviews] ADD  CONSTRAINT [DF__ProductRe__Revie__5441852A]  DEFAULT (getdate()) FOR [ReviewDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__DateCreat__38996AB5]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[UserShipped] ADD  CONSTRAINT [DF__UserAddre__DateA__3C69FB99]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Wallet] ADD  CONSTRAINT [DF__UserBalan__Balan__6B24EA82]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[Wallet] ADD  CONSTRAINT [DF__UserBalan__LastU__6C190EBB]  DEFAULT (getdate()) FOR [LastUpdate]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK__Favorites__Produ__5BE2A6F2] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK__Favorites__Produ__5BE2A6F2]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK__Favorites__UserI__5AEE82B9] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK__Favorites__UserI__5AEE82B9]
GO
ALTER TABLE [dbo].[FinancialTransactions]  WITH CHECK ADD  CONSTRAINT [FK__Financial__UserI__6EF57B66] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[FinancialTransactions] CHECK CONSTRAINT [FK__Financial__UserI__6EF57B66]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users] FOREIGN KEY([FromUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users1] FOREIGN KEY([ToUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users1]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK__ProductIm__Produ__46E78A0C] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK__ProductIm__Produ__46E78A0C]
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD  CONSTRAINT [FK__ProductRe__Produ__5070F446] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[ProductReviews] CHECK CONSTRAINT [FK__ProductRe__Produ__5070F446]
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD  CONSTRAINT [FK__ProductRe__UserI__5165187F] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ProductReviews] CHECK CONSTRAINT [FK__ProductRe__UserI__5165187F]
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD  CONSTRAINT [FK_ProductReviews_ProductReviews] FOREIGN KEY([ThreadId])
REFERENCES [dbo].[ProductReviews] ([ReviewID])
GO
ALTER TABLE [dbo].[ProductReviews] CHECK CONSTRAINT [FK_ProductReviews_ProductReviews]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ProductCategories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Users]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__Buyer__4AB81AF0] FOREIGN KEY([BuyerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK__Transacti__Buyer__4AB81AF0]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__Produ__4CA06362] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK__Transacti__Produ__4CA06362]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__Selle__4BAC3F29] FOREIGN KEY([SellerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK__Transacti__Selle__4BAC3F29]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([RoldeID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
ALTER TABLE [dbo].[UserShipped]  WITH CHECK ADD  CONSTRAINT [FK_UserShipped_Transactions1] FOREIGN KEY([TransactionID])
REFERENCES [dbo].[Transactions] ([TransactionID])
GO
ALTER TABLE [dbo].[UserShipped] CHECK CONSTRAINT [FK_UserShipped_Transactions1]
GO
ALTER TABLE [dbo].[Wallet]  WITH CHECK ADD  CONSTRAINT [FK__UserBalan__UserI__6A30C649] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Wallet] CHECK CONSTRAINT [FK__UserBalan__UserI__6A30C649]
GO
