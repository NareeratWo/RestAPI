USE [CreditCard]
GO

/****** Object:  Table [dbo].[CREDIT_CARD]    Script Date: 07/12/2018 00:59:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].CreditCardItem(
    [ID] [int] NOT NULL,
	[CARD_NO] [varchar] (16) NOT NULL,
	[EXPIRE_DATE] [nchar](6) NOT NULL,
	[CARD_TYPE] [nchar](20) NULL,
 CONSTRAINT [creditcard_PK] PRIMARY KEY CLUSTERED 
(
	[ID]
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


GO


