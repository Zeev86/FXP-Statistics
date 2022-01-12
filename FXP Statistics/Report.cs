using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXP_Statistics
{
    class Report
    {
        private static SplitContainer splitContainer = (SplitContainer)Application.OpenForms["Form1"].Controls["splitContainer1"];
        WebBrowser webBrowser = splitContainer.Panel2.Controls["wb"] as WebBrowser;
        public void BuildReport()
        {
            PopulateTable();
        }

        private void PopulateTable()
        {
            List<Configuration.Users> SortedUserList = Parser.users.OrderByDescending(u => u.UserMsgCount).ToList();

            string htmlBuilder = "<html><title>Statistics Report</title><body>";
            htmlBuilder = htmlBuilder + "<table width=90% border=0><tr>" +
                "<td width=20%><b>User</b></td><td><b>Messages</b></td><td><b>Threads</b></td>" + 
                "<td><b>Long messages</b></td><td><b>Bad Reputation</b></td><td width=50%><b>Score</b></td></tr>";
            for (int k = 0; k < SortedUserList.Count; k++)
            {
                var user = SortedUserList[k].UserName;
                var msgCount = SortedUserList[k].UserMsgCount;
                var threadCount = SortedUserList[k].UserThreadCount;
                var longMsgCount = SortedUserList[k].UserLongMsgCount;
                var badRepCount = SortedUserList[k].UserBadRepCount;
                var score = msgCount + threadCount + longMsgCount - badRepCount;

                htmlBuilder = htmlBuilder + string.Concat("<tr><td>", user, "</td><td>", msgCount, "</td><td>", threadCount, "</td><td>", longMsgCount, "</td><td>", badRepCount, "</td><td> | ", score, " ");
                htmlBuilder = htmlBuilder + "<font size=4 color=green>";
                if (score > 0)
                {
                    for (int i = 0; i < score; i++)
                        htmlBuilder = htmlBuilder + "+";
                }
                htmlBuilder = htmlBuilder + "</font><font size=4 color=red>";
                if (badRepCount > 0)
                {
                    for (int j = 0; j < badRepCount; j++)
                        htmlBuilder = htmlBuilder + "-";
                }
                htmlBuilder = htmlBuilder + "</font>";
            }

            htmlBuilder = htmlBuilder + "</td></tr>" +
                "</table>";

            webBrowser.DocumentText = htmlBuilder;
        }
    }
}
