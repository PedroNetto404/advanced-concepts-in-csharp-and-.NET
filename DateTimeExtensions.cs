public static class DateTimeExtensions 
{
    public static string GetTodayFormattedTime(this DateTime dateTime) => dateTime.ToString("Today at HH:mm:ss");
}