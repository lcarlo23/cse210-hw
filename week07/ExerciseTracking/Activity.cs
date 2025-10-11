using System.Globalization;

public abstract class Activity
{
    private DateTime _date;
    protected int _length;

    public Activity(string date, int length)
    {
        DateTime convertedDate = DateTime.ParseExact(
            date,
            "MM/dd/yyyy",
            CultureInfo.InvariantCulture
        );

        _date = convertedDate;

        _length = length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public string GetSummary()
    {
        string date = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{date} {GetType().Name} ({_length} min): Distance: {distance:0.0#} km, Speed: {speed:0.0#} kph, Pace: {pace:0.0#} min per km";
    }
}