CREATE TABLE [dbo].[HighScore] (
    [HighscoreID] BIGINT        IDENTITY (1, 1) NOT NULL,
    [Highscore]   NVARCHAR (50) NOT NULL,
    [PlayerID]    BIGINT        NOT NULL,
    CONSTRAINT [pk_HighScore] PRIMARY KEY CLUSTERED ([HighscoreID] ASC),
    CONSTRAINT [fk_HighScore] FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[Player] ([PlayerID]) ON UPDATE CASCADE
);

