using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXP_Statistics;

namespace FXP_Statistics_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");
            Parser parser = new FXP_Statistics.Parser();
            parser.isGUI = false;
            parser.GetForumThreads(Convert.ToString(10122), 1);
            Console.Read();
        }
    }
}
