// Program.cs
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Verify that the program runs (add a simple line of code to test)
        Console.WriteLine("Shapes project started!");

        // Test Square class
        Square testSquare = new Square("Yellow", 5);
        Console.WriteLine($"Square - Color: {testSquare.GetColor()}, Area: {testSquare.GetArea()}");

        // Test Rectangle class
        Rectangle testRectangle = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle - Color: {testRectangle.GetColor()}, Area: {testRectangle.GetArea()}");

        // Test Circle class
        Circle testCircle = new Circle("Green", 3);
        Console.WriteLine($"Circle - Color: {testCircle.GetColor()}, Area: {testCircle.GetArea()}");

        // Build a List of Shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(testSquare);
        shapes.Add(testRectangle);
        shapes.Add(testCircle);

        // Iterate and display color and area
        Console.WriteLine("\nShapes in the list:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}