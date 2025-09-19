/*
ENHANCEMENTS:
- Added menu for easier navigation
- Added ability to insert the scripture reference and text
- Added option to choose how many words to hide
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";
        int hiddenWords = 2;

        bool running = true;

        Console.WriteLine();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine();

        while (running)
        {
            Console.WriteLine("1. Choose Scripture");
            Console.WriteLine("2. Set words to hide");
            Console.WriteLine("3. Start Memorizer");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Choose your option: ");
            int userChoice = int.Parse(Console.ReadLine());
            Console.WriteLine();


            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Input Book, chapter and verses");
                    Console.Write("Book: ");
                    string book = Console.ReadLine();
                    Console.Write("Chapter: ");
                    int chapter = int.Parse(Console.ReadLine());
                    Console.Write("From verse: ");
                    int startVerse = int.Parse(Console.ReadLine());
                    Console.Write("To verse (0 if only one verse): ");
                    int endVerse = int.Parse(Console.ReadLine());
                    Console.Write("Scripture Text: ");
                    string scriptureText = Console.ReadLine();
                    Console.WriteLine();

                    reference = new Reference(book, chapter, startVerse, endVerse);
                    text = scriptureText;
                    break;
                case 2:
                    Console.Write($"How many words do you want to hide? ");
                    hiddenWords = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    break;
                case 3:
                    Scripture scripture = new Scripture(reference, text);

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(scripture.GetDisplayText());
                        Console.WriteLine();

                        Console.WriteLine("Press enter to continue or type 'quit' to finish:");
                        string userInput = Console.ReadLine();
                        Console.WriteLine();

                        if (userInput.ToLower() == "quit" || scripture.isCompletelyHidden())
                        {
                            break;
                        }
                        else if (userInput == "")
                        {
                            scripture.HideRandomWords(hiddenWords);
                        }
                    }
                    break;
                case 4:
                    running = false;
                    break;
            }
        }

    }
}