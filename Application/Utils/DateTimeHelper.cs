using System.Globalization;

namespace Application.Utils
{
    public static class DateTimeHelper
    {
        public static string ToShamsi(this DateTime dateTime, bool includeTime = false)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            string[] persianDayOfWeek = 
                { "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه" };
            string[] persianMonths =
            {
            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
            "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
        };

            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);
            string monthName = persianMonths[month - 1];
            string dayOfWeek = persianDayOfWeek[(int)dateTime.DayOfWeek];

            string shamsiDate = $"{dayOfWeek} {day} {monthName} {year}";

            if (includeTime)
            {
                int hour = persianCalendar.GetHour(dateTime);
                int minute = persianCalendar.GetMinute(dateTime);
                int second = persianCalendar.GetSecond(dateTime);
                shamsiDate += $" - {hour:D2}:{minute:D2}:{second:D2}";
            }

            return shamsiDate;
        }
    }
}
