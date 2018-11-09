using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLibrary.Library
{
    public class Wallet
    {
        public virtual long WalletID { get; set; }
        public virtual string DeepCoins { get; set; }
        public virtual long PlayerID { get; set; }
    }
}
