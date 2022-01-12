using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXP_Statistics
{
    public class Parser
    {
        public bool isGUI = true;
        private static Web web = new Web();
        private static Helper helper = new Helper();
        private static Constants constants = new Constants();
        public static Configuration.General generalConfig = new Configuration.General();
        public static List<Configuration.Threads> threads = new List<Configuration.Threads>();
        public static List<Configuration.Users> users = new List<Configuration.Users>();
        private static int daysToGoBack = generalConfig.DaysToGoBack;
        public static string reportName = "";

        public void GetForumThreads(string forumId, int forumPage)
        {
            if (isGUI)
            {
                daysToGoBack = helper.GetNumberOfDays();
                helper.isGUI = true;
                helper.ClearTextLog();
            }
            else
            {
                Console.WriteLine("Please type forum number");
                forumId = Console.ReadLine();
                Console.WriteLine("Please type number of days to get statistics: ");
                Int32.TryParse(Console.ReadLine(), out daysToGoBack);
                if (daysToGoBack < 1 || daysToGoBack >= 7)
                    daysToGoBack = 7;
                helper.isGUI = false;
            }

            helper.AddTextLog(string.Concat("Going to look for ", daysToGoBack, " days"));

            if (!generalConfig.StopGettingInfo)
            {
                DateTime now = DateTime.Now;
                DateTime daysDiff = now.AddDays(0 - daysToGoBack);
                var url = string.Concat(constants.SitePath, constants.ForumDisplay);

                if (forumPage == 1)
                    url = string.Concat(url, forumId);
                else
                    url = string.Concat(url, forumId, constants.PageParam, forumPage);

                System.Threading.Thread.Sleep(1000);
                generalConfig.PageSource = web.ReadWebPage(url);

                MatchCollection matchList = Regex.Matches(generalConfig.PageSource, constants.RgxThreadStatus, RegexOptions.Singleline);
                var forumPageContents = matchList.Cast<Match>().Select(match => match.Value).ToList();

                bool isDateReached = false;
                for (int i = 0; i < forumPageContents.Count; i++)
                {
                    if (forumPageContents[i].Contains(constants.PinnedThread))
                        continue;
                    var lastLine = forumPageContents[i].Split('\n').Last();
                    var threadUrlSearch = Regex.Match(forumPageContents[i], constants.RgxUrlSearch).Groups[1].Value;
                    string rgxTitleSearch = threadUrlSearch;
                    rgxTitleSearch = rgxTitleSearch.Replace("showthread.php?t=", "");
                    rgxTitleSearch = string.Concat("id=\"thread_title_", rgxTitleSearch, "(.+?)</a>");
                    string threadTitleSearch = Regex.Match(forumPageContents[i], rgxTitleSearch).Groups[1].Value;
                    threadTitleSearch = threadTitleSearch.Replace("\">", "");
                    var threadDateSearch = Regex.Match(lastLine, constants.RgxDateSearch, RegexOptions.Singleline).Groups[1].Value;
                    if ((!string.IsNullOrEmpty(threadUrlSearch)) && (!string.IsNullOrEmpty(threadDateSearch)))
                        threads.Add(new Configuration.Threads { ThreadTitle = threadTitleSearch, ThreadUrl = threadUrlSearch, ThreadDate = threadDateSearch, ThreadScore = 0 });

                    if (threadDateSearch != constants.DateToday && threadDateSearch != constants.DateYesterday)
                    {
                        DateTime threadDate = DateTime.Parse(threadDateSearch);
                        isDateReached = threadDate < daysDiff;
                        if (isDateReached)
                            break;
                    }

                }


                if (isDateReached == false)
                {
                    generalConfig.IntForumPageIncremental++;
                    GetForumThreads(forumId, generalConfig.IntForumPageIncremental);
                }

                for (int j = 0; j < threads.Count; j++)
                {
                    generalConfig.IntThreadPageIncremental = 1;
                    GetThreadDetails(threads[j].ThreadUrl.ToString(), 1);
                }

                List<Configuration.Users> SortedUserList = users.OrderByDescending(u => u.UserMsgCount).ToList();
                
                Console.WriteLine();
                helper.AddTextLog("User statistics:\r\n");
                helper.AddTextLog("USER\t\t\t\t\tPoints\r\n");
                var guiNewLine = "";
                if (isGUI)
                    guiNewLine = constants.TextNewLine;
                for (int k = 0; k < SortedUserList.Count; k++)
                {
                    helper.AddTextLog(SortedUserList[k].UserName + constants.TextTabs + SortedUserList[k].UserMsgCount + guiNewLine);
                }
                generalConfig.StopGettingInfo = true;

                Report.startDate = now;
                Report.endDate = daysDiff;
                Report report = new Report();
                report.BuildReport();

                SplitContainer splitContainer = (SplitContainer)Application.OpenForms["Form1"].Controls["splitContainer1"];
                WebBrowser webBrowser = splitContainer.Panel2.Controls["wb"] as WebBrowser;
                webBrowser.Url = new Uri(String.Format("file:///{0}/{1}", Application.StartupPath, reportName));

                helper.EnableGetStatsButton();
            }
        }

        private void GetThreadDetails(string threadId, int threadPage)
        {
            if (!generalConfig.StopGettingInfo)
            {
                int totalMsgsInThreadPage = 0, totalLongMsgsInThreadPage = 0;
                var url = constants.SitePath;
                Console.WriteLine("Getting information from thread id:" + threadId);

                if (threadPage == 1)
                    url = string.Concat(url, "/", threadId);
                else
                    url = string.Concat(url, "/", threadId, constants.PageParam, threadPage);

                generalConfig.PageSource = web.ReadWebPage(url);
                System.Threading.Thread.Sleep(1000);
                if (generalConfig.PageSource.Contains(constants.ThreadFirstPage))
                    Console.WriteLine("Thread has more than one page");

                Console.WriteLine("Searching for next user");
                MatchCollection matchList = Regex.Matches(generalConfig.PageSource, constants.RgxUserSearch, RegexOptions.Singleline);
                var userList = matchList.Cast<Match>().Select(match => match.Value).ToList();

                int numOfPages = 1;
                var threadPagesList = Regex.Match(generalConfig.PageSource, constants.RgxPagesSearch, RegexOptions.Multiline).Groups[1].Value;
                threadPagesList = threadPagesList.Replace(string.Concat("\"", threadId, constants.ReplacePageParam), "");
                threadPagesList = threadPagesList.Replace("\\", "");
                threadPagesList = threadPagesList.Replace("\"", "");

                if (!string.IsNullOrEmpty(threadPagesList))
                    numOfPages = Convert.ToInt16(threadPagesList);
                Console.WriteLine("Pages number is: " + numOfPages);

                bool shouldSkipPost = true;
                Cencor cencor = new Cencor();

                for (int i = 0; i < userList.Count; i++)
                {
                    bool isLongMsg = false;
                    bool isBadRep = false;

                    var lastLine = userList[i].Split('\n').Last();
                    var userSearch = Regex.Match(userList[i], constants.RgxUserName).Groups[1].Value;
                    var parsedDate = Regex.Match(userList[i], constants.RgxParsedDate).Groups[1].Value;
                    var userMsgSearch = Regex.Match(userList[i], constants.RgxUserMsgSearch, RegexOptions.Singleline);
                    string userMsg = userMsgSearch.ToString();
                    userMsg = userMsg.Replace("postcontent restore", "");
                    userMsg = userMsg.Replace("</blockquote>", "");
                    userMsg = userMsg.Replace("itemprop=\"articleBody\">", "");
                    if (userMsg.Length > 1000)
                    {
                        isLongMsg = true;
                        Console.WriteLine("User " + userSearch + " have a long message");
                    }
                    isBadRep = cencor.cencorList.Any(userMsg.Contains);
                    if(isBadRep)
                    {
                        Console.WriteLine("User cursed, adding to bad rep");
                    }

                    parsedDate = parsedDate.Replace(constants.NewLine, " ");
                    if (!parsedDate.Contains(constants.DateToday) && !parsedDate.Contains(constants.DateYesterday))
                    {
                        bool isDateInRange = false;
                        DateTime postDate = DateTime.Parse(parsedDate);
                        isDateInRange = postDate > DateTime.Now.AddDays(0 - daysToGoBack);
                        if (isDateInRange)
                            shouldSkipPost = false;
                    }
                    else
                        shouldSkipPost = false;

                    if (!shouldSkipPost)
                    {
                        if (!string.IsNullOrEmpty(userSearch))
                        {
                            if (!users.Any(usr => usr.UserName == userSearch))
                            {
                                int msgInc = 0, threadInc = 0, longMsg = 0, badRepCount = 0;
                                Console.WriteLine("User found " + userSearch);
                                if (i == 0)
                                {
                                    Console.WriteLine("User " + userSearch + " has opened this thread, award 2 points");
                                    threadInc++;
                                    msgInc++;
                                    totalMsgsInThreadPage++;
                                }
                                else
                                {
                                    msgInc++;
                                    totalMsgsInThreadPage++;
                                }
                                if (isLongMsg)
                                {
                                    longMsg++;
                                    totalLongMsgsInThreadPage++;
                                }

                                users.Add(new Configuration.Users { UserName = userSearch, UserMsgCount = msgInc, UserThreadCount = threadInc, UserLongMsgCount = longMsg, UserBadRepCount = badRepCount });
                            }
                            else
                            {
                                Console.WriteLine("User " + userSearch + " already exists, inc msg count");
                                int indexOfUserName = users.FindIndex(indx => indx.UserName == userSearch);

                                var usrMsgCount = users[indexOfUserName].UserMsgCount;
                                var usrThreadCount = users[indexOfUserName].UserThreadCount;
                                var usrLongMsgCount = users[indexOfUserName].UserLongMsgCount;
                                var usrBadRepCount = users[indexOfUserName].UserBadRepCount;

                                if (isLongMsg)
                                {
                                    usrLongMsgCount++;
                                    totalLongMsgsInThreadPage++;
                                }

                                if (i == 0)
                                {
                                    usrThreadCount++;
                                    usrMsgCount++;
                                    totalMsgsInThreadPage++;
                                    Console.WriteLine("User " + userSearch + " that was already added has opened this thread, award 2 points");
                                }
                                else
                                {
                                    usrMsgCount++;
                                    totalMsgsInThreadPage++;
                                }
                                users[indexOfUserName].UserMsgCount = usrMsgCount;
                                users[indexOfUserName].UserThreadCount = usrThreadCount;
                                users[indexOfUserName].UserLongMsgCount = usrLongMsgCount;
                                users[indexOfUserName].UserBadRepCount = usrBadRepCount;
                            }
                        }
                    }
                }

                Console.WriteLine("intThreadPageIncremental: " + generalConfig.IntThreadPageIncremental + ", numOfPages: " + numOfPages);
                if (generalConfig.IntThreadPageIncremental < numOfPages)
                {
                    generalConfig.IntThreadPageIncremental++;
                    Console.WriteLine("Getting into the next thread page");
                    GetThreadDetails(threadId, generalConfig.IntThreadPageIncremental);
                }

                // Thread statistics
                int indexOfThread = threads.FindIndex(indx => indx.ThreadUrl == threadId);
                Console.WriteLine("Adding to thread " + threadId + " total messages in page: " + totalMsgsInThreadPage + ", total long messages in page: " + totalLongMsgsInThreadPage + ", total thread score is: " + threads[indexOfThread].ThreadScore);
                threads[indexOfThread].ThreadScore = threads[indexOfThread].ThreadScore + totalMsgsInThreadPage + totalLongMsgsInThreadPage;
            }
        }
    }
}
