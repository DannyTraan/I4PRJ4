using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogic;

namespace UserApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DCApp runningApp = new DCApp();
            runningApp.TheApp();
        }
    }
}
