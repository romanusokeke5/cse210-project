using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<double> numbers = new List<double>();
        double userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            string userResponse = Console.ReadLine();
            userNumber = Convert.ToDouble(userResponse);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Compute the sum
        double sum = 0;
        foreach (double number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Compute the average
        double average = sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find the maximum
        double max = numbers[0];
        foreach (double number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge: Find the smallest positive number
        double smallestPositive = numbers.Where(n => n > 0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Stretch Challenge: Sort the numbers and display the sorted list
        List<double> sortedNumbers = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("The sorted list is:");
        foreach (double number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
    }
}