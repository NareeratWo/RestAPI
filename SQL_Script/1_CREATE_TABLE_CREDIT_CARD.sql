USE [CreditCard]
GO

/****** Object:  Table [dbo].[CREDIT_CARD]    Script Date: 07/12/2018 00:59:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CREDIT_CARD](
	[CARD_NO] [numeric](18, 0) NOT NULL,
	[EXPIRE_DATE] [nchar](6) NOT NULL,
	[CARD_TYPE] [nchar](20) NULL
) ON [PRIMARY]

GO


