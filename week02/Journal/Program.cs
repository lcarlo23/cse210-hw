/* EXCEEDING REQUIREMENTS
- Added a warning message when an invalid menu option is selected
- Provided user feedback when files are successfully saved or loaded
- Included notification if the journal is empty
- Improved readability by adding additional line breaks
- Implemented automatic date and time assignment for new entries
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine();

        bool running = true;

        Journal journal = new Journal();

        while (running)
        {

            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.Write("What would you like to do? ");
            string userChoice = Console.ReadLine();
            Console.WriteLine();

            int choice = int.Parse(userChoice);

            switch (choice)
            {
                case 1:
                    Entry entry = new Entry();

                    DateTime currentTime = DateTime.Now;
                    string dateText = currentTime.ToString();

                    entry._date = dateText;

                    PromptGenerator generator = new PromptGenerator();
                    string prompt = generator.GetRandomPrompt();
                    entry._promptText = prompt;

                    Console.WriteLine(prompt);
                    string entryText = Console.ReadLine();
                    Console.WriteLine();

                    entry._entryText = entryText;

                    journal.AddEntry(entry);

                    break;

                case 2:
                    journal.DisplayAll();

                    if (journal._entries.Count == 0)
                    {
                        Console.WriteLine("There are no entries in the journal.");
                        Console.WriteLine();
                    }

                    break;

                case 3:
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    Console.WriteLine();

                    journal.LoadFromFile(loadFile);

                    break;

                case 4:
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    Console.WriteLine();

                    journal.SaveToFile(saveFile);

                    break;

                case 5:
                    running = false;
                    break;

                default:
                    Console.WriteLine("The option selected is invalid, please choose another one.");
                    Console.WriteLine();

                    break;
            }
        }
    }
}