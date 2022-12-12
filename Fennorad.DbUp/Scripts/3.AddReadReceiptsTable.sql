USE [Chat]
GO

/****** Object:  Table [chat].[ReadReceipts]    Script Date: 12/3/2022 1:12:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'chat' 
                 AND  TABLE_NAME = 'ReadReceipts'))
BEGIN
	CREATE TABLE [chat].[ReadReceipts](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[UserMessageId] [int] NOT NULL,
		[ConversationUserId] [int] NOT NULL,
		[CreatedOn] [datetimeoffset](7) NOT NULL,
	 CONSTRAINT [PK_ReadReceipts] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [chat].[ReadReceipts]  WITH CHECK ADD  CONSTRAINT [FK_ReadReceipts_On_UserMessages] FOREIGN KEY([UserMessageId])
	REFERENCES [chat].[UserMessages] ([Id])
	

	ALTER TABLE [chat].[ReadReceipts] CHECK CONSTRAINT [FK_ReadReceipts_On_UserMessages]
	
END