using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("white", 25);
        Rectangle rectangle = new Rectangle("red", 25, 15);
        Circle circle = new Circle("green", 14);

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine();
            Console.WriteLine($"The color is: {color}.");
            Console.WriteLine($"The area is {area}.");
        }
    }
}