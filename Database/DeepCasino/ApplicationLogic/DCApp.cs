using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLibrary.Library;
using Infrastructure;

namespace ApplicationLogic
{
    public class DCApp
    {
        public void TheApp()
        {
            DeepCasinoDBUtil util = new DeepCasinoDBUtil();

            #region Player

            Player newPlayer = new Player() { PlayerID = 10002, UserName = "Bekir", HighScore = "100", Wallet = "Dybet" };
            util.AddPlayerDB(ref newPlayer);
            util.DeletePlayerDB(ref newPlayer);
            util.UpdatePlayerDB(ref newPlayer);
            util.GetPlayerDB();
            Console.WriteLine("***Updated Player!***");

            #endregion

            #region Wallet

            //Wallet newWallet = new Wallet() {WalletID = 3, PlayerID = 1, DeepCoins = "1000"};
            //util.AddWalletDB(ref newWallet);
            //util.UpdateWalletDB(ref newWallet);
            //util.DeleteWalletDB(ref newWallet);
            //Console.WriteLine("***Deleted Wallet!***");

            #endregion

            #region Username

            //UserName newUserName = new UserName() {UsernameID = 2, PlayerID = 1, Username = "DE4D R4BB1T"};
            //util.AddUsernameDB(ref newUserName);
            //util.UpdateUsernameDB(ref newUserName);
            //util.DeleteUsernameDB(ref newUserName);
            //Console.WriteLine("***Username Deleted!***");

            #endregion

            #region HighScore

            //HighScore newScore = new HighScore() {HighScoreID = 2, PlayerID = 0, Highscore = "4321"};
            //util.AddHighScoreDB(ref newScore);
            //util.UpdateHighScoreDB(ref newScore);
            //util.DeleteHighScoreDB(ref newScore);
            //Console.WriteLine("***Highscore Added!***");

            #endregion
        }
    }
}
