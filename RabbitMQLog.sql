USE [RabbitMQ]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LogMessageStatus](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_LogMessageStatusId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EventType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_EventTypeId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LogMessage](
	[Id] [int] IDENTITY,
	[ExternalId] [char](36) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[EventTypeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[ErrorMessage] [nvarchar](500) NULL,
 CONSTRAINT [PK_LogMessageId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [EventTypeIdIndex] ON [dbo].[LogMessage]
(
	[EventTypeId] ASC
)
GO

CREATE NONCLUSTERED INDEX [StatusIdIndex] ON [dbo].[LogMessage]
(
	[StatusId] ASC
)
GO

ALTER TABLE [dbo].[LogMessage] WITH CHECK ADD CONSTRAINT [FK_LogMessage_LogMessageStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[LogMessageStatus] ([Id])
GO

ALTER TABLE [dbo].[LogMessage] WITH CHECK ADD CONSTRAINT [FK_LogMessage_EventType] FOREIGN KEY([EventTypeId])
REFERENCES [dbo].[EventType] ([Id])
GO

INSERT INTO [dbo].[LogMessageStatus]([Id], [Name])
VALUES
	(1, 'В процессе'),
	(2, 'Доставлено'),
	(3, 'Не доставлено')
GO

INSERT INTO [dbo].[EventType]
VALUES
	(1, 'Создание пользователя'),
	(2, 'Редактирование пользователя')
GO
