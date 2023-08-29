CREATE TABLE [dbo].[AccountRole]
(
	[AccountRoleId] UNIQUEIDENTIFIER NOT NULL, 
	[RoleId] UNIQUEIDENTIFIER NOT NULL
	    CONSTRAINT [FK_AccountRole_Role] FOREIGN KEY
        REFERENCES [dbo].[Role]([RoleId]),
    [AccountId] UNIQUEIDENTIFIER NOT NULL
	    CONSTRAINT [FK_AccountRole_Account] FOREIGN KEY
        REFERENCES [dbo].[Account]([AccountId]),

    CONSTRAINT [PK_AccountRole] PRIMARY KEY([AccountRoleId])
);
GO

CREATE INDEX [IX_AccountRole_RoleId] ON [dbo].[AccountRole] ([RoleId]);
GO

CREATE INDEX [IX_AccountRole_AccountId] ON [dbo].[AccountRole] ([AccountId]);
GO
