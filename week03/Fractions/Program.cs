using System;

// Create a class to hold a fraction.
// The class should be in its own file.  (Fraction.cs)
public class Fraction
{
    // Attributes for the top and bottom numbers
    // Make sure the attributes are private.
    private int _top;
    private int _bottom;

    // Constructors
    // Constructor that has no parameters that initializes the number to 1/1.
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor that has one parameter for the top and that initializes the denominator to 1.
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor that has two parameters, one for the top and one for the bottom.
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and setters for both the top and the bottom values.
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Methods to return the representations
    // Create a method called GetFractionString that returns the fraction in the form 3/4.
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Create a method called GetDecimalValue that returns a double that is the result of dividing the top number by the bottom number, such as 0.75.
    public double GetDecimalValue()
    {
        // Use (double) to ensure floating-point division.
        return (double)_top / _bottom;
    }
}

// Program.cs
class Program
{
    static void Main(string[] args)
    {
        // Verify that you can create fractions using all three constructors.
        // For example, create an instance for 1/1, for 6/1, for 6/7.
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());
        
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Verify that you can call all of these methods and get the correct values,
        // using setters to change the values and then getters to retrieve these new values
        // and then display them to the console.
        Fraction f5 = new Fraction();  // Start with 1/1
        f5.SetTop(6);          // Change to 6/1
        f5.SetBottom(7);      // Change to 6/7
        Console.WriteLine(f5.GetFractionString());  // Display 6/7
        Console.WriteLine(f5.GetDecimalValue());    // Display decimal value

        Console.WriteLine($"Top: {f5.GetTop()}, Bottom: {f5.GetBottom()}"); //show getters
    }
}
/*
1/1
1
5/1
5
3/4
0.75
1/3
0.3333333333333333
6/7
0.8571428571428571
Top: 6, Bottom: 7
*/
