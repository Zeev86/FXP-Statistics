using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXP_Statistics
{
    class Constants
    {
        // Text Constants
        public string TextNewLine = "\r\n";
        public string TextTabs = "\t\t\t\t\t";

        // Forum URL
        public string SitePath = "https://www.fxp.co.il";
        public string ForumDisplay = "/forumdisplay.php?f=";
        public string PageParam = "&page=";

        // Forum Constants
        public string PinnedThread = "אשכול נעוץ";
        public string DateYesterday = "אתמול";
        public string DateToday = "היום";
        public string ThreadFirstPage = "עמוד 1</a></span>";
        public string ReplacePageParam = "&amp;page=";
        public string NewLine = "&nbsp;";

        // Regex to parse threads and users
        public string RgxThreadStatus = "threadstatus(.+?)</em>";
        public string RgxUrlSearch = "class=\"title\" href=\"(.+)\" id=";
        public string RgxDateSearch = "<dd>(.+?) <em";
        public string RgxUserSearch = "<div class=\"userinfo\"(.+?)הצג עוד";
        public string RgxUserMsgSearch = "postcontent restore(.+?)</blockquote>";
        public string RgxPagesSearch = "class=\"first_last\"><a href=(.+)title=";
        public string RgxUserName = "הסמל האישי של(.+)\"";
        public string RgxParsedDate = "<span class=\"date\">(.+)</span>";
    }
}
