using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLibrary.Library
{
    public class HighScore
    {
        public virtual long HighScoreID { get; set; }
        public virtual string Highscore { get; set; }
        public virtual long PlayerID { get; set; }
    }
}
