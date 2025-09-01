using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();
        int number;

        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int sum = 0;
        double average;
        int max = 0;
        int min = int.MaxValue;

        foreach (int num in numbers)
        {
            sum += num;
            if (num > max)
            {
                max = num;
            }
            else if (num < min && num > -1)
            {
                min = num;
            }
        }

        average = ((double)sum) / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {min}");

        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();

        Console.WriteLine($"The sorted list is:");
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num);
        }
    }
}