using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWinService.data.Helper
{
    public class TimeSpanHelper
    {
        public static TimeSpan GetTimeSpan(string time)
        {
            TimeSpan timeSpan = new TimeSpan();
            string tempTime = time;
            if (!string.IsNullOrEmpty(tempTime))
            {
                tempTime = tempTime.Trim().ToUpper();
                if (tempTime.EndsWith("S"))
                {
                    timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(tempTime.Substring(0, tempTime.Length - 1)));
                }
                else if (tempTime.EndsWith("M"))
                {
                    timeSpan = TimeSpan.FromMinutes(Convert.ToInt32(tempTime.Substring(0, tempTime.Length - 1)));
                }
                else if (tempTime.EndsWith("H"))
                {
                    timeSpan = TimeSpan.FromHours(Convert.ToInt32(tempTime.Substring(0, tempTime.Length - 1)));
                }
                else
                {
                    int result = 0;
                    if (Int32.TryParse(tempTime, out result))
                    {
                        timeSpan = new TimeSpan(0, 0, result);
                    }
                }
            }
            return timeSpan;
        }

        public static int GetSecond(string timeStr)
        {
            int returnSecond = 0;
            string tempTime = timeStr;
            if (!string.IsNullOrEmpty(tempTime))
            {
                tempTime = tempTime.Trim().ToUpper();
                if (tempTime.EndsWith("S"))
                {
                    returnSecond = Convert.ToInt32(tempTime.Substring(0, tempTime.Length - 1));
                }
                else if (tempTime.EndsWith("M"))
                {
                    returnSecond = Convert.ToInt32(tempTime.Substring(0, tempTime.Length - 1)) * 60;
                }
                if (tempTime.EndsWith("H"))
                {
                    returnSecond = Convert.ToInt32(tempTime.Substring(0, tempTime.Length - 1)) * 3600;
                }
            }
            return returnSecond;
        }
    }
}
