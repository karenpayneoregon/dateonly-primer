/****** Object:  Database [HasConversions]    Script Date: 8/20/2022 4:38:13 PM ******/
/****** Object:  Sequence [dbo].[seq_test]    Script Date: 8/20/2022 4:38:13 PM ******/
CREATE SEQUENCE [dbo].[seq_test] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE 1
 MAXVALUE 2147483647
 CACHE 
GO
/****** Object:  Table [dbo].[Book]    Script Date: 8/20/2022 4:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[BookVariantId] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookVariants]    Script Date: 8/20/2022 4:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookVariants](
	[BookVariantId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_BookVariants] PRIMARY KEY CLUSTERED 
(
	[BookVariantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 8/20/2022 4:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wine]    Script Date: 8/20/2022 4:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wine](
	[WineId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[WineVariantId] [int] NOT NULL,
	[BookVariantId] [int] NULL,
 CONSTRAINT [PK_Wine] PRIMARY KEY CLUSTERED 
(
	[WineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WineVariant]    Script Date: 8/20/2022 4:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WineVariant](
	[WineVariantId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_WineVariant] PRIMARY KEY CLUSTERED 
(
	[WineVariantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookId], [Title], [BookVariantId]) VALUES (1, N'First book', 2)
INSERT [dbo].[Book] ([BookId], [Title], [BookVariantId]) VALUES (2, N'Second book', 5)
INSERT [dbo].[Book] ([BookId], [Title], [BookVariantId]) VALUES (3, N'Third book', 6)
INSERT [dbo].[Book] ([BookId], [Title], [BookVariantId]) VALUES (4, N'Fourth book', 2)
INSERT [dbo].[Book] ([BookId], [Title], [BookVariantId]) VALUES (5, N'5th book', 2)
SET IDENTITY_INSERT [dbo].[Book] OFF
INSERT [dbo].[BookVariants] ([BookVariantId], [Name]) VALUES (1, N'SpaceTravel')
INSERT [dbo].[BookVariants] ([BookVariantId], [Name]) VALUES (2, N'Adventure')
INSERT [dbo].[BookVariants] ([BookVariantId], [Name]) VALUES (3, N'Romance')
INSERT [dbo].[BookVariants] ([BookVariantId], [Name]) VALUES (4, N'Sports')
INSERT [dbo].[BookVariants] ([BookVariantId], [Name]) VALUES (5, N'Automobile')
INSERT [dbo].[BookVariants] ([BookVariantId], [Name]) VALUES (6, N'Programming')
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [BirthDate]) VALUES (1, N'Karen', N'Payne', CAST(N'1956-09-24' AS Date))
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Jim', N'Gallagher', CAST(N'1957-07-09' AS Date))
SET IDENTITY_INSERT [dbo].[Person] OFF
/****** Object:  Index [IX_Book_BookVariantId]    Script Date: 8/20/2022 4:38:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Book_BookVariantId] ON [dbo].[Book]
(
	[BookVariantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wine_BookVariantId]    Script Date: 8/20/2022 4:38:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wine_BookVariantId] ON [dbo].[Wine]
(
	[BookVariantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wine_WineVariantId]    Script Date: 8/20/2022 4:38:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wine_WineVariantId] ON [dbo].[Wine]
(
	[WineVariantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookVariants_BookVariantId] FOREIGN KEY([BookVariantId])
REFERENCES [dbo].[BookVariants] ([BookVariantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BookVariants_BookVariantId]
GO
ALTER TABLE [dbo].[Wine]  WITH CHECK ADD  CONSTRAINT [FK_Wine_BookVariants_BookVariantId] FOREIGN KEY([BookVariantId])
REFERENCES [dbo].[BookVariants] ([BookVariantId])
GO
ALTER TABLE [dbo].[Wine] CHECK CONSTRAINT [FK_Wine_BookVariants_BookVariantId]
GO
ALTER TABLE [dbo].[Wine]  WITH CHECK ADD  CONSTRAINT [FK_Wine_WineVariant_WineVariantId] FOREIGN KEY([WineVariantId])
REFERENCES [dbo].[WineVariant] ([WineVariantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wine] CHECK CONSTRAINT [FK_Wine_WineVariant_WineVariantId]
GO
USE [master]
GO
ALTER DATABASE [HasConversions] SET  READ_WRITE 
GO
