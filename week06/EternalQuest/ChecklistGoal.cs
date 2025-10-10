public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted < _target)
        {
            return _points;
        }
        else
        {
            Console.WriteLine("You completed the goal!");
            Console.WriteLine($"You earned {_bonus} bonus points!");
            Console.WriteLine();
            return _bonus + _points;
        }
    }
    public override bool IsComplete()
    {
        if (_amountCompleted < _target)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public override string GetDetailsString()
    {
        string complete;

        if (IsComplete())
        {
            complete = "[X]";
        }
        else
        {
            complete = "[ ]";
        }
        return $"{complete} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|:|{_shortName}|:|{_description}|:|{_points}|:|{_target}|:|{_bonus}|:|{_amountCompleted}";
    }
}