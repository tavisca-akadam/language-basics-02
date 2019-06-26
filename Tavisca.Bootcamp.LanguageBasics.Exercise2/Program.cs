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
            Test(new[] { "11:59:13", "12:25:15", "11:13:23" }, new[] { "few seconds ago", "23 hours ago", "46 minutes ago" }, "11:59:23");
            Console.ReadKey(true);
        }

        private static void Test(string[] postTimes, string[] showTimes, string expected)
        {
            var result = GetCurrentTime(postTimes, showTimes).Equals(expected) ? "PASS" : "FAIL";
            var postTimesCsv = string.Join(", ", postTimes);
            var showTimesCsv = string.Join(", ", showTimes);
            Console.WriteLine($"[{postTimesCsv}], [{showTimesCsv}] => {result}");
        }

        public static string GetCurrentTime(string[] exactPostTime, string[] showPostTime)
        {
            // Add your code here.
            Helper helper = new Helper();
            if(helper.IsInvalid(exactPostTime, showPostTime))
                return "impossible";

            DateTime[] postTimeArray = new DateTime[exactPostTime.Length];
            int minute = 0, hour = 0, second = 0;
            DateTime calculatedTime;

            for(int i = 0; i < exactPostTime.Length; i++)
            {
                string[] showPostTimeWords = showPostTime[i].Split(' ');
                postTimeArray[i] = DateTime.Parse(exactPostTime[i]);
                
                if(showPostTimeWords[1].Equals("seconds"))
                {
                    hour = postTimeArray[i].Hour;
                    minute = postTimeArray[i].Minute;
                    second = postTimeArray[i].Second;
                }

                //Adding Hours
                if(showPostTimeWords[1].Equals("hours"))
                {
                    int postHour = int.Parse(showPostTimeWords[0]);
                    calculatedTime = helper.AddHour(postTimeArray[i], postHour);
                    hour = calculatedTime.Hour;
                    minute = calculatedTime.Minute;
                    second = calculatedTime.Second;
                }
                //Adding minutes
                else if(showPostTimeWords[1].Equals("minutes"))
                {
                    int postMinute = int.Parse(showPostTimeWords[0]);
                    calculatedTime = helper.AddMinute(postTimeArray[i], postMinute);
                    hour = calculatedTime.Hour;
                    minute = calculatedTime.Minute;
                    second = calculatedTime.Second;
                }
            }
            return helper.ToString(hour, minute, second);

            throw new NotImplementedException();
        }
    }
}
