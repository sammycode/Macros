USE [MACROS_1]
GO
/****** Object:  Table [dbo].[ExternalMacroSources]    Script Date: 2018-06-03 12:43:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalMacroSources](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MacroID] [bigint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ExternalSourceCode] [nvarchar](50) NOT NULL,
	[Accelerator] [nvarchar](50) NOT NULL,
	[Interval] [nvarchar](50) NOT NULL,
	[Mode] [nvarchar](50) NOT NULL,
	[PlaySeconds] [nvarchar](50) NOT NULL,
	[RepeatTimes] [nvarchar](50) NOT NULL,
	[MacroSource] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ExternalMacroSources] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExternalSources]    Script Date: 2018-06-03 12:43:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalSources](
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ExternalSources] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Labels]    Script Date: 2018-06-03 12:43:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labels](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Labels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MacroAssemblyActions]    Script Date: 2018-06-03 12:43:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MacroAssemblyActions](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MacroID] [bigint] NOT NULL,
	[ActionType] [int] NOT NULL,
	[ScreenHeight] [int] NOT NULL,
	[ScreenWidth] [int] NOT NULL,
	[PositionX] [int] NOT NULL,
	[PositionY] [int] NOT NULL,
	[ActionDelay] [int] NOT NULL,
 CONSTRAINT [PK_MacroAssemblyActions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Macros]    Script Date: 2018-06-03 12:43:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Macros](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LabelID] [bigint] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ListOrder] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_Macros] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ExternalMacroSources] ADD  CONSTRAINT [DF_ExternalMacroSources_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Macros] ADD  CONSTRAINT [DF_Macros_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Macros] ADD  CONSTRAINT [DF_Macros_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[ExternalMacroSources]  WITH CHECK ADD  CONSTRAINT [FK_ExternalMacroSources_ExternalSources] FOREIGN KEY([ExternalSourceCode])
REFERENCES [dbo].[ExternalSources] ([Code])
GO
ALTER TABLE [dbo].[ExternalMacroSources] CHECK CONSTRAINT [FK_ExternalMacroSources_ExternalSources]
GO
ALTER TABLE [dbo].[ExternalMacroSources]  WITH CHECK ADD  CONSTRAINT [FK_ExternalMacroSources_Macros] FOREIGN KEY([MacroID])
REFERENCES [dbo].[Macros] ([ID])
GO
ALTER TABLE [dbo].[ExternalMacroSources] CHECK CONSTRAINT [FK_ExternalMacroSources_Macros]
GO
ALTER TABLE [dbo].[Labels]  WITH CHECK ADD  CONSTRAINT [FK_Labels_Labels] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Labels] ([ID])
GO
ALTER TABLE [dbo].[Labels] CHECK CONSTRAINT [FK_Labels_Labels]
GO
ALTER TABLE [dbo].[MacroAssemblyActions]  WITH CHECK ADD  CONSTRAINT [FK_MacroAssemblyActions_Macros] FOREIGN KEY([MacroID])
REFERENCES [dbo].[Macros] ([ID])
GO
ALTER TABLE [dbo].[MacroAssemblyActions] CHECK CONSTRAINT [FK_MacroAssemblyActions_Macros]
GO
ALTER TABLE [dbo].[Macros]  WITH CHECK ADD  CONSTRAINT [FK_Macros_Labels] FOREIGN KEY([LabelID])
REFERENCES [dbo].[Labels] ([ID])
GO
ALTER TABLE [dbo].[Macros] CHECK CONSTRAINT [FK_Macros_Labels]
GO
