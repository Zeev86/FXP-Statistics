using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXP_Statistics
{
    public class Configuration
    {
        public class General
        {
            public bool StopGettingInfo = false;
            public string PageSource = "";
            public int IntForumPageIncremental = 1;
            public int IntThreadPageIncremental = 1;
            public int DaysToGoBack = -6;
        }
        public class Threads
        {
            public string ThreadUrl { get; set; }
            public string ThreadDate { get; set; }
        }

        public class Users
        {
            public string UserName { get; set; }
            public int UserMsgCount { get; set; }
            public int UserThreadCount { get; set; }
            public int UserLongMsgCount { get; set; }
            public int UserBadRepCount { get; set; }
        }
    }
}
