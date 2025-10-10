/*
ENHANCEMENTS
- Validates user input to prevent invalid menu choices
- Checks if the filename exists before loading goals
- Displays a message and prevents awarding points if a goal is already completed
- Shows a message prompting the user to add a new goal when listing goals or recording events with an empty list
- Added random motivational messages upon goal completion
- Implemented a leveling and titling system with notifications (level up every 1000 points)
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            goalManager.DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Create New Goal");
            Console.WriteLine("    2. List Goals");
            Console.WriteLine("    3. Save Goals");
            Console.WriteLine("    4. Load Goals");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateGoal();
                    break;
                case "2":
                    goalManager.ListGoalDetails();
                    break;
                case "3":
                    goalManager.SaveGoals();
                    break;
                case "4":
                    goalManager.LoadGoals();
                    break;
                case "5":
                    goalManager.RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Sorry, but your option is not valid.");
                    break;
            }
        }
    }
}