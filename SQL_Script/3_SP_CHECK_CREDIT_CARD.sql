SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nareerat Wo.
-- Create date: 2018/07/13
-- Description:	for check credit card 
-- =============================================
CREATE PROCEDURE [dbo].[SP_CHECK_CREDIT_CARD]
@Card_NO varchar (16),
@expire_date nchar(6),
@card_type nchar(20)

AS
BEGIN
	SELECT [CARD_NO]
		,[EXPIRE_DATE]
		,[CARD_TYPE]
	FROM [dbo].[CreditCardItem] 
	WHERE [CARD_NO] = @Card_NO AND [EXPIRE_DATE] = @expire_date AND [CARD_TYPE]=@card_type;
	
END
GO
