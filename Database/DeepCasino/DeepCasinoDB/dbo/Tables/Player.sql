CREATE TABLE [dbo].[Player] (
    [PlayerID]  BIGINT        IDENTITY (1, 1) NOT NULL,
    [HighScore] NVARCHAR (50) NOT NULL,
    [UserName]  NVARCHAR (50) NOT NULL,
    [Wallet]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [pk_Player] PRIMARY KEY CLUSTERED ([PlayerID] ASC)
);

