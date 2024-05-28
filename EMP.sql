USE [TESTDB]
GO

/****** Object:  Table [dbo].[EMP]    Script Date: 2024/5/28 �U�� 12:46:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EMP](	
	[EMP_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMP_NAME] [varchar](50) NOT NULL,
	[AGE] [int] NOT NULL,
	[BIRTHDAY] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EMP] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

