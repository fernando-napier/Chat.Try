USE [Chat]
GO

/****** Object:  Table [chat].[ReadReceipts]    Script Date: 12/3/2022 1:12:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
GO

ALTER TABLE [chat].[ReadReceipts]  WITH CHECK ADD  CONSTRAINT [FK_ReadReceipts_On_UserMessages] FOREIGN KEY([UserMessageId])
REFERENCES [chat].[UserMessages] ([Id])
GO

ALTER TABLE [chat].[ReadReceipts] CHECK CONSTRAINT [FK_ReadReceipts_On_UserMessages]
GO
