using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        Fraction fraction2 = new Fraction(1);
        Fraction fraction3 = new Fraction(5);
        Fraction fraction4 = new Fraction(3, 4);
        Fraction fraction5 = new Fraction(1, 3);

        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetTop());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetTop());
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetTop());
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());
        Console.WriteLine(fraction5.GetFractionString());
        Console.WriteLine(fraction5.GetDecimalValue());
    }
}