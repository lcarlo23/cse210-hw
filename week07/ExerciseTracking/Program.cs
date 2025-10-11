using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("11/03/2022", 30, 5.2),
            new Cycling("04/15/2023", 45, 27.5),
            new Swimming("08/22/2024", 40, 32)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}