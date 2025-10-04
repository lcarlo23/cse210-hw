public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Activity";
        _description = "This is a sample activity";
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        string userDuration = Console.ReadLine();

        if (int.TryParse(userDuration, out int intDuration))
        {
            _duration = intDuration;
        }
        else
        {
            Console.Write($"Your input is invalid, the default duration for the activity will be {_duration} seconds. ");
            ShowSpinner(3);
        }

        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    public void ShowSpinner(int seconds)
    {

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        List<string> spinnerStrings = new List<string> { "|", "/", "—", "\\" };

        Console.CursorVisible = false;

        while (DateTime.Now < endTime)
        {
            foreach (string s in spinnerStrings)
            {
                Console.Write(s + "\b");
                Thread.Sleep(200);
            }
        }

        Console.WriteLine("\r \r");
        Console.CursorVisible = true;
    }

    public void ShowCountDown(int seconds)
    {
        Console.CursorVisible = false;

        int length = seconds.ToString().Length;
        string backspaces = new string('\b', length);

        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i.ToString().PadRight(length) + backspaces);
            Thread.Sleep(1000);
        }

        Console.WriteLine(" " + backspaces.PadRight(length));
        Console.CursorVisible = true;
    }
}