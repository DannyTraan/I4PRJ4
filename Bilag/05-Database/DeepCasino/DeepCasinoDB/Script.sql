SELECT Player.PlayerID, UserName.UsernameID, UserName.Username, HighScore.HighscoreID, HighScore.Highscore, Wallet.WalletID, Wallet.DeepCoins
FROM     HighScore INNER JOIN
                  Player ON HighScore.PlayerID = Player.PlayerID INNER JOIN
                  UserName ON Player.PlayerID = UserName.PlayerID INNER JOIN
                  Wallet ON Player.PlayerID = Wallet.PlayerID

SELECT * FROM Player