CREATE TABLE [dbo].[Notes](
	[UserId] [nchar](50) NULL,
	[Title] [nchar](50) NULL,
	[Description] [nchar](150) NULL,
	[Color] [nchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsArchive] [bit] NULL,
	[IsPin] [bit] NULL,
	[IsTrash] [bit] NULL,
	[Image] [nchar](100) NULL,
	[Reminder] [datetime] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]