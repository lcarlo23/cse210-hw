public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000.0;
    }
    public override double GetSpeed()
    {
        double distance = GetDistance();
        return distance / _length * 60.0;
    }
    public override double GetPace()
    {
        double distance = GetDistance();
        return _length / distance;
    }
}