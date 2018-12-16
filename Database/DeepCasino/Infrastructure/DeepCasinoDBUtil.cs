using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLibrary.Library;

namespace Infrastructure
{
    public class DeepCasinoDBUtil
    {
        private readonly Player currentPlayer;

        public DeepCasinoDBUtil()
        {
            currentPlayer = new Player()
            {
                PlayerID = 0,
                UserName = null,
                Wallet = null,
                HighScore = null
            };
        }
        #region SQL
        private SqlConnection OpenConnection
        {
            get
            {
                var con = new SqlConnection(@"Data Source=st-i4dab.uni.au.dk;Initial Catalog=E18I4DABau556770;User ID=E18I4DABau556770;Password=E18I4DABau556770;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                con.Open();
                return con;
            }
        }
        #endregion
        
        #region Player
        public void AddPlayerDB(ref Player pla)
        {
            string insertStringParam = @"INSERT INTO [Player] (Wallet, UserName, HighScore)
                                                OUTPUT INSERTED.PlayerID
                                                VALUES (@Wallet, @UserName, @HighScore)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@Wallet", pla.Wallet);
                cmd.Parameters.AddWithValue("@UserName", pla.UserName);
                cmd.Parameters.AddWithValue("@HighScore", pla.HighScore);

                pla.PlayerID = (long)cmd.ExecuteScalar();
            }
        }

        public List<Player> GetPlayerDB()
        {
            string getStringParam = @"SELECT * FROM Player";
            Console.WriteLine("PlayerID \t\t HighScore \t\t\t UserName \t\t Wallet ");
            using (var cmd = new SqlCommand(getStringParam, OpenConnection))
            {
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                List<Player> players = new List<Player>();
                Player pla = null;
                while (rdr.Read())
                {
                    pla = new Player
                    {
                        PlayerID = (long) rdr["PlayerID"],
                        UserName = (string)rdr["UserName"],
                        HighScore = (string) rdr["HighScore"],
                        Wallet = (string) rdr["Wallet"]
                    };

                    Console.WriteLine(String.Format("{0} \t\t\t | {2} | \t\t\t | {1} | \t\t\t | {3} DeepCoins|", rdr[0], rdr[1], rdr[2], rdr[3]));

                    players.Add(pla);
                }

                return players;
            }
        }

        public void UpdatePlayerDB(ref Player pla)
        {
            string updateString = @"UPDATE Player
                                           SET Wallet = @Wallet, UserName = @UserName, HighScore = @HighScore
                                           WHERE PlayerID = @PlayerID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@Wallet", pla.Wallet);
                cmd.Parameters.AddWithValue("@UserName", pla.UserName);
                cmd.Parameters.AddWithValue("@HighScore", pla.HighScore);
                cmd.Parameters.AddWithValue("@PlayerID", pla.PlayerID);

                var id = (long) cmd.ExecuteNonQuery();
            }
        }

        public void DeletePlayerDB(ref Player pla)
        {
            string deleteString = @"DELETE FROM Player WHERE (PlayerID = @PlayerID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PlayerID", pla.PlayerID);

                var id = (long) cmd.ExecuteNonQuery();
                pla = null;
            }
        }

        #endregion

        #region Username

        public void AddUsernameDB(ref UserName name)
        {
            string insertStringParam = @"INSERT INTO [UserName] (Username, PlayerID)
                                                        OUTPUT INSERTED.UsernameID
                                                        VALUES (@Username, @PlayerID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@Username", name.Username);
                cmd.Parameters.AddWithValue("@PlayerID", name.PlayerID);

                name.UsernameID = (long) cmd.ExecuteScalar();
            }
        }

        public void UpdateUsernameDB(ref UserName name)
        {
            string updateString = @"UPDATE UserName
                                    SET Username = @Username, PlayerID = @PlayerID
                                    WHERE UsernameID = @UsernameID";
            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@Username", name.Username);
                cmd.Parameters.AddWithValue("@PlayerID", name.PlayerID);
                cmd.Parameters.AddWithValue("@UsernameID", name.UsernameID);
                var id = (long) cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUsernameDB(ref UserName name)
        {
            string deleteString = @"DELETE FROM UserName WHERE (UsernameID = @UsernameID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@UsernameID", name.UsernameID);

                var id = (long) cmd.ExecuteNonQuery();

                name = null;
            }
        }

        #endregion

        #region Wallet

        public void AddWalletDB(ref Wallet wal)
        {
            string insertStringParam = @"INSERT INTO [Wallet] (DeepCoins, PlayerID)
                                                        OUTPUT INSERTED.WalletID
                                                        VALUES (@DeepCoins, @PlayerID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@DeepCoins", wal.DeepCoins);
                cmd.Parameters.AddWithValue("@PlayerID", wal.PlayerID);

                wal.WalletID = (long) cmd.ExecuteScalar();
            }
        }

        public void UpdateWalletDB(ref Wallet wal)
        {
            string updateString = @"UPDATE Wallet
                                    SET DeepCoins = @DeepCoins, PlayerID = @PlayerID
                                    WHERE WalletID = @WalletID";
            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@DeepCoins", wal.DeepCoins);
                cmd.Parameters.AddWithValue("@PlayerID", wal.PlayerID);
                cmd.Parameters.AddWithValue("@WalletID", wal.WalletID);

                var id = (long) cmd.ExecuteNonQuery();
            }
        }

        public void DeleteWalletDB(ref Wallet wal)
        {
            string deleteString = @"DELETE FROM Wallet WHERE (WalletID = @WalletID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@WalletID", wal.WalletID);

                var id = (long) cmd.ExecuteNonQuery();

                wal = null;
            }
        }

        #endregion

        #region HighScore

        public void AddHighScoreDB(ref HighScore hi)
        {
            string insertStringParam = @"INSERT INTO [HighScore] (Highscore, PlayerID)
                                                            OUTPUT INSERTED.HighScoreID
                                                            VALUES (@Highscore, @PlayerID)";
            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@Highscore", hi.Highscore);
                cmd.Parameters.AddWithValue("@PlayerID", hi.PlayerID);

                hi.HighScoreID = (long) cmd.ExecuteScalar();
            }
        }

        public void UpdateHighScoreDB(ref HighScore hi)
        {
            string updateString = @"UPDATE HighScore
                                    SET Highscore = @Highscore, PlayerID = @PlayerID
                                    WHERE HighScoreID = @HighScoreID";
            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@Highscore", hi.Highscore);
                cmd.Parameters.AddWithValue("@PlayerID", hi.PlayerID);
                cmd.Parameters.AddWithValue("@HighScoreID", hi.HighScoreID);

                var id = (long) cmd.ExecuteNonQuery();
            } 
        }

        public void DeleteHighScoreDB(ref HighScore hi)
        {
            string deleteString = @"DELETE FROM HighScore WHERE (HighScoreID = @HighScoreID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@HighScoreID", hi.HighScoreID);

                var id = (long) cmd.ExecuteNonQuery();

                hi = null;
            }
        }

        #endregion
    }
}
