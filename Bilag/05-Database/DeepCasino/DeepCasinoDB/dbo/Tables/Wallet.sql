CREATE TABLE [dbo].[Wallet] (
    [WalletID]  BIGINT        IDENTITY (1, 1) NOT NULL,
    [DeepCoins] NVARCHAR (50) NOT NULL,
    [PlayerID]  BIGINT        NOT NULL,
    CONSTRAINT [pk_Wallet] PRIMARY KEY CLUSTERED ([WalletID] ASC),
    CONSTRAINT [fk_Wallet] FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[Player] ([PlayerID]) ON UPDATE CASCADE
);

