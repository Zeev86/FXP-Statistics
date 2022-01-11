using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXP_Statistics
{
    class Web
    {
        public string ReadWebPage(string url)
        {
            List<string> links = new List<string>();
            var htmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDoc = htmlWeb.Load(url);
            return htmlDoc.DocumentNode.InnerHtml;
        }
    }
}
