using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Helpers
{
    public class DateFormatter
    {
        public string FormatRelativeTime(DateTime dateTime)
        {

            DateTime CurrentDateTime = DateTime.Now;
            TimeSpan timeDifference = CurrentDateTime - dateTime;

            if (timeDifference.TotalSeconds < 60) return $"{(int)timeDifference.TotalSeconds} seconds ago";

            else if (timeDifference.TotalMinutes < 60) return $"{timeDifference.TotalMinutes} minutes ago";
            else if (timeDifference.TotalHours < 24) return $"{timeDifference.TotalHours} hours ago";
            else return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
