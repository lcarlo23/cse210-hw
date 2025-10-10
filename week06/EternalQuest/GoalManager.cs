public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {

    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Level {GetLevel()} - {GetTitle()}");
        Console.WriteLine($"You have {_score} points");
    }
    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string name = goal.GetGoalName();
            Console.WriteLine($"{i + 1}. {name}");
        }
    }
    public void ListGoalDetails()
    {
        if (_goals.Count > 0)
        {
            Console.WriteLine("The goals are:");

            for (int i = 0; i < _goals.Count; i++)
            {
                Goal goal = _goals[i];
                string details = goal.GetDetailsString();
                Console.WriteLine($"{i + 1}. {details}");
            }
        }
        else
        {
            Console.WriteLine("Add at least one goal to list all available goals.");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("    1. Simple Goal");
        Console.WriteLine("    2. Eternal Goal");
        Console.WriteLine("    3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        string[] choices = new string[] { "1", "2", "3" };

        if (choices.Contains(choice))
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            int points;

            while (true)
            {
                Console.Write("What is the amount of points associated with this goal? ");
                string pointsString = Console.ReadLine();

                if (int.TryParse(pointsString, out points))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You must input a number.");
                }
            }

            switch (choice)
            {
                case "1":
                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                    _goals.Add(simpleGoal);
                    break;
                case "2":
                    EternalGoal eternalGoal = new EternalGoal(name, description, points);
                    _goals.Add(eternalGoal);
                    break;
                case "3":
                    int target;
                    int bonus;

                    while (true)
                    {
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        string targetString = Console.ReadLine();

                        if (int.TryParse(targetString, out target))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You must input a valid number.");
                        }
                    }

                    while (true)
                    {
                        Console.Write("What is the bonus for accomplishing it that many times? ");
                        string bonusString = Console.ReadLine();

                        if (int.TryParse(bonusString, out bonus))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You must input a valid number.");
                        }
                    }

                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    _goals.Add(checklistGoal);

                    break;
            }
        }
        else
        {
            Console.WriteLine("Sorry, but your option is not valid.");
        }
    }
    public void RecordEvent()
    {
        if (_goals.Count > 0)
        {
            ListGoalNames();
            Console.WriteLine();
            Console.Write("Which goal did you accomplish? ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(choice, out int index))
            {
                Goal goal = _goals[index - 1];
                if (!goal.IsComplete())
                {
                    int points = goal.RecordEvent();

                    int oldLevel = GetLevel();
                    string oldTitle = GetTitle();

                    _score += points;
                    Console.WriteLine($"Congratulations! You have earned {points} points!");
                    if (goal.IsComplete())
                    {
                        Console.WriteLine(GetRandomMotivation());
                    }
                    Console.WriteLine();

                    int newLevel = GetLevel();
                    string newTitle = GetTitle();

                    if (newLevel > oldLevel)
                    {
                        Console.WriteLine("--- LEVEL UP! ---");
                        Console.WriteLine($"Congratulations, you've reached Level {newLevel}!");
                    }
                    if (newTitle != oldTitle)
                    {
                        Console.WriteLine($"You've achieved the title of {newTitle}!");
                    }
                    Console.WriteLine();

                    Console.WriteLine($"You now have {_score} points.");
                }
                else
                {
                    Console.WriteLine($"The goal '{goal.GetGoalName()}' has already been completed!");
                }
            }

        }
        else
        {
            Console.WriteLine("Add at least one goal to record a new event.");
        }
    }
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                string goalString = goal.GetStringRepresentation();
                outputFile.WriteLine(goalString);
            }
        }
    }
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (System.IO.File.Exists(filename))
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            _goals.Clear();

            _score = int.Parse(lines[0]);

            foreach (string line in lines.Skip(1))
            {
                string[] parts = line.Split("|:|");

                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                switch (goalType)
                {
                    case "SimpleGoal":
                        SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                        if (parts[4] == "True")
                        {
                            simpleGoal.RecordEvent();
                        }
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        EternalGoal eternalGoal = new EternalGoal(name, description, points);
                        _goals.Add(eternalGoal);
                        break;
                    case "ChecklistGoal":
                        int target = int.Parse(parts[4]);
                        int bonus = int.Parse(parts[5]);
                        int completed = int.Parse(parts[6]);

                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                        for (int i = 0; i < completed; i++)
                        {
                            checklistGoal.RecordEvent();
                        }
                        _goals.Add(checklistGoal);
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("The file does not exist.");
        }
    }
    public string GetRandomMotivation()
    {
        string[] messages = new string[] {
            "Great job! Keep pushing forward!",
            "Well done! You're making progress!",
            "Awesome work! Stay consistent!",
            "Fantastic! Every step counts!",
            "Excellent! You're closer to your goals!",
            "Nice! Keep up the momentum!",
            "Bravo! Small wins lead to big results!"
        };
        Random random = new Random();
        int index = random.Next(messages.Length);

        return messages[index];
    }
    public int GetLevel()
    {
        return _score / 1000;
    }
    public string GetTitle()
    {
        int level = GetLevel();

        if (level < 5)
        {
            return $"Beginner";
        }
        else if (level < 10)
        {
            return $"Apprentice";
        }
        else if (level < 15)
        {
            return $"Achiever";
        }
        else if (level < 20)
        {
            return $"Master";
        }
        else
        {
            return $"Legend";
        }
    }
}