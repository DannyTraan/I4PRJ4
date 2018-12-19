--
-- Create Table    : 'Player'   
-- PlayerID        :  
-- HighScore       :  
-- UserName        :  
-- Wallet          :  
--
CREATE TABLE Player (
    PlayerID       BIGINT IDENTITY(1,1) NOT NULL,
    HighScore      NVARCHAR(50) NOT NULL,
    UserName       NVARCHAR(50) NOT NULL,
    Wallet         NVARCHAR(50) NOT NULL,
CONSTRAINT pk_Player PRIMARY KEY CLUSTERED (PlayerID))
GO

--
-- Create Table    : 'UserName'   
-- UsernameID      :  
-- Username        :  
-- PlayerID        :  (references Player.PlayerID)
--
CREATE TABLE UserName (
    UsernameID     BIGINT IDENTITY(1,1) NOT NULL,
    Username       NVARCHAR(50) NOT NULL,
    PlayerID       BIGINT NOT NULL,
CONSTRAINT pk_UserName PRIMARY KEY CLUSTERED (UsernameID),
CONSTRAINT fk_UserName FOREIGN KEY (PlayerID)
    REFERENCES Player (PlayerID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'HighScore'   
-- HighscoreID     :  
-- Highscore       :  
-- PlayerID        :  (references Player.PlayerID)
--
CREATE TABLE HighScore (
    HighscoreID    BIGINT IDENTITY(1,1) NOT NULL,
    Highscore      NVARCHAR(50) NOT NULL,
    PlayerID       BIGINT NOT NULL,
CONSTRAINT pk_HighScore PRIMARY KEY CLUSTERED (HighscoreID),
CONSTRAINT fk_HighScore FOREIGN KEY (PlayerID)
    REFERENCES Player (PlayerID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Wallet'   
-- WalletID        :  
-- DeepCoins       :  
-- PlayerID        :  (references Player.PlayerID)
--
CREATE TABLE Wallet (
    WalletID       BIGINT IDENTITY(1,1) NOT NULL,
    DeepCoins      NVARCHAR(50) NOT NULL,
    PlayerID       BIGINT NOT NULL,
CONSTRAINT pk_Wallet PRIMARY KEY CLUSTERED (WalletID),
CONSTRAINT fk_Wallet FOREIGN KEY (PlayerID)
    REFERENCES Player (PlayerID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO