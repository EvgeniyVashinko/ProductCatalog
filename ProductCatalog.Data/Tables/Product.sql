CREATE TABLE [dbo].[Product]
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL, 
    [CategoryId] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT [FK_Product_Category] FOREIGN KEY
        REFERENCES [dbo].[Category]([CategoryId]), 
    [Name] NVARCHAR(100) NOT NULL,
    [Price] DECIMAL NULL,
    [Description] NVARCHAR(500) NULL,
    [Note] NVARCHAR(500) NULL,
    [SpecialNote] NVARCHAR(500) NULL,

    CONSTRAINT [PK_Product] PRIMARY KEY([ProductId])
);
GO

CREATE INDEX [IX_Product_CategoryId] ON [dbo].[Category] ([CategoryId]);
GO
