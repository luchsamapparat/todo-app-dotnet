using System;
using Humanizer;

namespace SsrTodo.Domain
{
    public class DateTimeUtils
    {
        public static string FormatShortDateTime(DateTime date)
        {
            return $"{date.ToShortDateString()} {date.ToShortTimeString()}";
        }

        public static string FormatIsoDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string FormatRelativeDate(DateTime date)
        {
            return date.Humanize();
        }
    }

}