CREATE TABLE [dbo].[Category]
(
	[CategoryId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(20) NOT NULL,

	CONSTRAINT [PK_Category] PRIMARY KEY([CategoryId])
)
