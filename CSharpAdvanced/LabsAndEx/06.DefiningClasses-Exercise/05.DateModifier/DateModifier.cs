namespace DefiningClasses;

public static class DateModifier
{
    public static int GetDateDifference(string date1, string date2)
    {
        var dateTime1 = DateTime.Parse(date1);
        var dateTime2 = DateTime.Parse(date2);

        var difference = dateTime1 - dateTime2;

        return difference.Duration().Days;
    }
}