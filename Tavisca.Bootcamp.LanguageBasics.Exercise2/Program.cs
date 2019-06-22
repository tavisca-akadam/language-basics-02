using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(new[] {"12:12:12"}, new [] { "few seconds ago" }, "12:12:12");
            Test(new[] { "23:23:23", "23:23:23" }, new[] { "59 minutes ago", "59 minutes ago" }, "00:22:23");
            Test(new[] { "00:10:10", "00:10:10" }, new[] { "59 minutes ago", "1 hours ago" }, "impossible");
            Test(new[] { "11:59:13", "11:13:23", "12:25:15" }, new[] { "few seconds ago", "46 minutes ago", "23 hours ago" }, "11:59:23");
            Console.ReadKey(true);
        }

        private static void Test(string[] postTimes, string[] showTimes, string expected)
        {
            var result = GetCurrentTime(postTimes, showTimes).Equals(expected) ? "PASS" : "FAIL";
            var postTimesCsv = string.Join(", ", postTimes);
            var showTimesCsv = string.Join(", ", showTimes);
            Console.WriteLine($"[{postTimesCsv}], [{showTimesCsv}] => {result}");
        }

        public static bool isinvalid(string[] exactPostTime, string[] showPostTime)
        {
            for (int i = 0; i < exactPostTime.Length; i++) 
            {
                for (int j = i + 1; j < exactPostTime.Length; j++)
                {
                    if (exactPostTime[i] == exactPostTime[j])
                    {
                        if (showPostTime[i] != showPostTime[j])
                            return true;
                    }
                }
            }
            return false;
        }
        public static string GetCurrentTime(string[] exactPostTime, string[] showPostTime)
        {
            // Add your code here.
            //check If the information given is self-contradictory
            if(isinvalid(exactPostTime,showPostTime))
            {
                return "impossible";
            }

            string currentTime = "";
            DateTime[] timeArray = new DateTime[exactPostTime.Length];
            int mins = 0, hrs = 0, sec = 0;
            DateTime calcTime;
            bool flag = true;
            for(int i = 0; i < exactPostTime.Length; i++)
            {
                string[] showPostTimeWords = showPostTime[i].Split(' ');
                timeArray[i] = DateTime.Parse(exactPostTime[i]);
                if(flag)
                {   
                    //initianlize all variables
                    hrs = timeArray[i].Hour;
                    mins = timeArray[i].Minute;
                    sec = timeArray[i].Second;
                    flag = false;
                }

                //Adding Hours
                if(showPostTimeWords[1].Equals("hours"))
                {
                    hrs = timeArray[i].AddHours(int.Parse(showPostTimeWords[0])).Hour;
                }
                //Adding minutes
                else if(showPostTimeWords[1].Equals("minutes"))
                {
                    calcTime = timeArray[i].AddMinutes(int.Parse(showPostTimeWords[0]));
                    hrs = calcTime.Hour;
                    mins = calcTime.Minute;
                    sec = timeArray[i].Second;
                }
            }
            string temp = "" + hrs;
            if(hrs == 0) temp = "00"; 
            //calculated time to string
            currentTime = $"{temp}:{mins}:{sec}";
            return currentTime;
            throw new NotImplementedException();
        }
    }
}
