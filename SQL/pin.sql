USE [Darko]
GO
/****** Object:  Table [dbo].[Zero]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Zero]') AND type in (N'U'))
DROP TABLE [dbo].[Zero]
GO
/****** Object:  Table [dbo].[Two]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Two]') AND type in (N'U'))
DROP TABLE [dbo].[Two]
GO
/****** Object:  Table [dbo].[Three]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Three]') AND type in (N'U'))
DROP TABLE [dbo].[Three]
GO
/****** Object:  Table [dbo].[Six]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Six]') AND type in (N'U'))
DROP TABLE [dbo].[Six]
GO
/****** Object:  Table [dbo].[Seven]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Seven]') AND type in (N'U'))
DROP TABLE [dbo].[Seven]
GO
/****** Object:  Table [dbo].[One]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[One]') AND type in (N'U'))
DROP TABLE [dbo].[One]
GO
/****** Object:  Table [dbo].[Nine]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nine]') AND type in (N'U'))
DROP TABLE [dbo].[Nine]
GO
/****** Object:  Table [dbo].[Four]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Four]') AND type in (N'U'))
DROP TABLE [dbo].[Four]
GO
/****** Object:  Table [dbo].[Five]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Five]') AND type in (N'U'))
DROP TABLE [dbo].[Five]
GO
/****** Object:  Table [dbo].[Eight]    Script Date: 5/22/2023 11:57:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Eight]') AND type in (N'U'))
DROP TABLE [dbo].[Eight]
GO

/****** Object:  Table [dbo].[Eight]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eight](
	[pin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Five]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Five](
	[pin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Four]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Four](
	[pin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nine]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nine](
	[pin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[One]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[One](
	[pin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seven]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seven](
	[pin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Six]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Six](
	[pin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Three]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Three](
	[pin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Two]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Two](
	[pin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

/****** Object:  Table [dbo].[Zero]    Script Date: 5/22/2023 11:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zero](
	[pin] [int] NULL
) ON [PRIMARY]
GO


INSERT [dbo].[Eight] ([pin]) VALUES (8)
GO
INSERT [dbo].[Eight] ([pin]) VALUES (5)
GO
INSERT [dbo].[Eight] ([pin]) VALUES (7)
GO
INSERT [dbo].[Eight] ([pin]) VALUES (9)
GO
INSERT [dbo].[Eight] ([pin]) VALUES (0)
GO
INSERT [dbo].[Five] ([pin]) VALUES (5)
GO
INSERT [dbo].[Five] ([pin]) VALUES (2)
GO
INSERT [dbo].[Five] ([pin]) VALUES (4)
GO
INSERT [dbo].[Five] ([pin]) VALUES (6)
GO
INSERT [dbo].[Five] ([pin]) VALUES (8)
GO
INSERT [dbo].[Four] ([pin]) VALUES (4)
GO
INSERT [dbo].[Four] ([pin]) VALUES (1)
GO
INSERT [dbo].[Four] ([pin]) VALUES (5)
GO
INSERT [dbo].[Four] ([pin]) VALUES (7)
GO
INSERT [dbo].[Nine] ([pin]) VALUES (9)
GO
INSERT [dbo].[Nine] ([pin]) VALUES (6)
GO
INSERT [dbo].[Nine] ([pin]) VALUES (8)
GO
INSERT [dbo].[One] ([pin]) VALUES (1)
GO
INSERT [dbo].[One] ([pin]) VALUES (2)
GO
INSERT [dbo].[One] ([pin]) VALUES (4)
GO
INSERT [dbo].[Seven] ([pin]) VALUES (7)
GO
INSERT [dbo].[Seven] ([pin]) VALUES (4)
GO
INSERT [dbo].[Seven] ([pin]) VALUES (8)
GO
INSERT [dbo].[Six] ([pin]) VALUES (6)
GO
INSERT [dbo].[Six] ([pin]) VALUES (3)
GO
INSERT [dbo].[Six] ([pin]) VALUES (5)
GO
INSERT [dbo].[Six] ([pin]) VALUES (9)
GO
INSERT [dbo].[Three] ([pin]) VALUES (3)
GO
INSERT [dbo].[Three] ([pin]) VALUES (2)
GO
INSERT [dbo].[Three] ([pin]) VALUES (6)
GO
INSERT [dbo].[Two] ([pin]) VALUES (1)
GO
INSERT [dbo].[Two] ([pin]) VALUES (2)
GO
INSERT [dbo].[Two] ([pin]) VALUES (3)
GO
INSERT [dbo].[Two] ([pin]) VALUES (5)
GO
INSERT [dbo].[Zero] ([pin]) VALUES (0)
GO
INSERT [dbo].[Zero] ([pin]) VALUES (8)
GO
