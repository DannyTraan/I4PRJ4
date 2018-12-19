using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLibrary.Library
{
    public class Player
    {
        public virtual long PlayerID { get; set; }
        public virtual string Wallet { get; set; }
        public virtual string UserName { get; set; }
        public virtual string HighScore { get; set; }
        public virtual long PID { get; set; }
    }
}
