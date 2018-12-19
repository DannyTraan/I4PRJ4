using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLibrary.Library
{
    public class UserName
    {
        public virtual long UsernameID { get; set; }
        public virtual string Username { get; set; }
        public virtual long PlayerID { get; set; }
    }
}
