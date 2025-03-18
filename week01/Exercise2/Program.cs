using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade = Convert.ToInt32(input);

        if (grade >= 90)
        {
            Console.WriteLine("You got an A!");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("You got a B!");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("You got a C!");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("You got a D!");
        }
        else
        {
            Console.WriteLine("You got an F!");
        }

        string passMessage;
        if (grade >= 60)
        {
            passMessage = "You passed!";
        }
        else
        {
            passMessage = "You failed!";
        }

         Console.WriteLine($"Your grade is {grade}. {passMessage}");


    }
}