using System;

class Program
{
    static void Main(string[] args)
    {
        string newGame = "yes";
        while (newGame == "yes")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101);
            int guess;
            int guessCount = 0;

            do
            {
                Console.Write("What is your guess? ");
                string userGuess = Console.ReadLine();
                guess = int.Parse(userGuess);

                guessCount++;

                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            } while (guess != number);

            Console.Write("Do you want to play again? ");
            newGame = Console.ReadLine().ToLower();
        }
    }
}