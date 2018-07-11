SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nareerat Wo.
-- Create date: 2018/07/11
-- Description:	for check and insert credit card 
-- =============================================
CREATE PROCEDURE [dbo].[SP_CHECK_ADD_CREDIT_CARD]
@CreditCard_NO integer,
@expire_date Varchar(6),
@card_type Varchar(20)
AS
BEGIN
	DECLARE @countCreditcard int
	SELECT @countCreditcard = (SELECT COUNT(*) FROM [dbo].[CREDIT_CARD] 
	                           WHERE [CARD_NO] = @CreditCard_NO AND [EXPIRE_DATE] = @expire_date)
	IF @countCreditcard <= 0
	BEGIN
		INSERT INTO [dbo].[CREDIT_CARD]
		([CARD_NO]
		,[EXPIRE_DATE]
		,[CARD_TYPE])
		VALUES (@CreditCard_NO
		, @expire_date
		, @card_type)
	END
	SELECT [CARD_NO], [EXPIRE_DATE], [CARD_TYPE]
	FROM [dbo].[CREDIT_CARD] 
	WHERE [CARD_NO] = @CreditCard_NO 
	AND [EXPIRE_DATE] = @expire_date
END
GO
