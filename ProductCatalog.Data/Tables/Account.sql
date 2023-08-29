CREATE TABLE [dbo].[Account]
(
	[AccountId] UNIQUEIDENTIFIER NOT NULL,
	[Email] NVARCHAR(256) NOT NULL,
	[Password] NVARCHAR(64) NOT NULL,
	[PasswordSalt] NVARCHAR(128) NULL, 

    CONSTRAINT [PK_Account] PRIMARY KEY([AccountId])
);