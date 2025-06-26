USE [MarsaKAnzAbhar]
GO

/****** Object:  Table [dbo].[[IncomeFromCashier]]    Script Date: 06/16/2020 16:30:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IncomeFromCashier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NULL,
	[StartTime] [time](7) NULL,		
	[UserID] [int] NULL,
	[PayCash] [decimal](18, 2) NULL,
	[PayCard] [decimal](18, 2) NULL,
 CONSTRAINT [PK_IncomeFromCashier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
