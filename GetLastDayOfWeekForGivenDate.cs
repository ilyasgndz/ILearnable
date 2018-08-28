static DateTime GetLastDay(DateTime dateStart, DayOfWeek day)
{
    var dateEnd = dateStart.AddDays(10);
    var lastMonday = dateEnd;

    while (lastMonday.DayOfWeek != day)
    {
        lastMonday = lastMonday.AddDays(-1);
    }

    return lastMonday;
}
