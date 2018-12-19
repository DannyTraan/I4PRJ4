CREATE TABLE [dbo].[UserName] (
    [UsernameID] BIGINT        IDENTITY (1, 1) NOT NULL,
    [Username]   NVARCHAR (50) NOT NULL,
    [PlayerID]   BIGINT        NOT NULL,
    CONSTRAINT [pk_UserName] PRIMARY KEY CLUSTERED ([UsernameID] ASC),
    CONSTRAINT [fk_UserName] FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[Player] ([PlayerID]) ON UPDATE CASCADE
);

