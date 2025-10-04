/*
ENHANCEMENTS:
- The cursor now automatically hides during the spinner and countdown
- Updated ShowCountDown so it can handle numbers of any length
- Improved the Reflecting Activity:
    - It now always shows different questions
    - When no questions are left, it displays a fallback message
- If the menu choice is not valid, the menu resets without returning an error
- Added a default duration when no input is provided, along with an invalid input message
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        string userChoice = "";

        while (userChoice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Start breathing activity");
            Console.WriteLine("    2. Start reflection activity");
            Console.WriteLine("    3. Start listing activity");
            Console.WriteLine("    4. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                default:
                    break;
            }
        }
    }
}