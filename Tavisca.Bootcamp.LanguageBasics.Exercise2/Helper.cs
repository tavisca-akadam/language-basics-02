using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Helper
    {
        public bool IsInvalid(string[] exactPostTime, string[] showPostTime)
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

        public DateTime AddHour(DateTime postTime, int hour)
        {
            return postTime.AddHours(hour);
        }

        public DateTime AddMinute(DateTime postTime, int minute)
        {
            return postTime.AddMinutes(minute);
        }

        public string ToString(int hour, int minute, int second)
        {
            string resultedString = "";
            if(hour == 0)
                resultedString += $"00:{minute}:{second}";
            else
                resultedString += $"{hour}:{minute}:{second}";
            return resultedString;
        }
    }
}