

USE [DB201301030953]
GO

/****** Object:  Table [dbo].[T_TrafficViolation]    Script Date: 2013/1/4 21:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TrafficViolation](
	[CarNumber] [nvarchar](10) NOT NULL,
	[CarFrame] [nvarchar](6) NULL,
	[CarOwner] [nvarchar](50) NULL,
	[ViolationAddress] [nvarchar](100) NULL,
	[ViolationDateTime] [nvarchar](25) NULL,
	[ViolationAmount] [int] NULL,
	[ViolationScore] [int] NULL,
	[Created_Time] [datetime] NOT NULL,
 CONSTRAINT [PK_T_TrafficViolation] PRIMARY KEY CLUSTERED 
(
	[CarNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  StoredProcedure [dbo].[P_IsExist_Car]    Script Date: 2013/1/4 21:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[P_IsExist_Car]
(
	@CarNumber	nvarchar(10)
)
AS
BEGIN
	SELECT COUNT(1) FROM T_TrafficViolation
		WHERE CarNumber = @CarNumber
END
GO
/****** Object:  StoredProcedure [dbo].[P_TrafficViolation_Get_By_CarNum]    Script Date: 2013/1/4 21:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[P_TrafficViolation_Get_By_CarNum]
(
	@CarNumber	nvarchar(10),
	@CarFrame	nvarchar(6)
)
AS
BEGIN

SELECT TOP 3 [CarNumber]
      ,[CarFrame]
      ,[CarOwner]
      ,[ViolationAddress]
      ,[ViolationDateTime]
      ,[ViolationAmount]
      ,[ViolationScore]
      ,[Created_Time]
  FROM [T_TrafficViolation]
  WHERE [CarNumber] = @CarNumber
	--AND [CarFrame] = @CarFrame

END
GO
/****** Object:  StoredProcedure [dbo].[P_TrafficViolation_I]    Script Date: 2013/1/4 21:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sunny
-- Create date: 2013/1/4 17:55:19
-- Description:	Insert
-- =============================================

CREATE PROCEDURE [dbo].[P_TrafficViolation_I]
(
	@CarNumber			nvarchar(10),
	@CarFrame			nvarchar(6),
	@CarOwner			nvarchar(50),
	@ViolationAddress			nvarchar(100),
	@ViolationDateTime			nvarchar(25),
	@ViolationAmount			int,
	@ViolationScore			int
)
AS 
 BEGIN 
 INSERT INTO T_TrafficViolation(
	CarNumber,
	CarFrame,
	CarOwner,
	ViolationAddress,
	ViolationDateTime,
	ViolationAmount,
	ViolationScore,
	Created_Time)
VALUES(
	@CarNumber,
	@CarFrame,
	@CarOwner,
	@ViolationAddress,
	@ViolationDateTime,
	@ViolationAmount,
	@ViolationScore,
	GETDATE())

END

GO
