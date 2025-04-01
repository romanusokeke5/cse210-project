using System;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nMindfulness App Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            MindfulnessActivity currentActivity = null;

            if (choice == "1")
            {
                currentActivity = new BreathingActivity();
            }
            else if (choice == "2")
            {
                currentActivity = new ReflectionActivity();
            }
            else if (choice == "3")
            {
                currentActivity = new ListingActivity();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                continue;
            }

            if (currentActivity != null)
            {
                currentActivity.StartActivity();
                currentActivity.ExecuteActivity();
                currentActivity.EndActivity();
            }
        }
    }
}

// Exceeded Requirements:
// Added a base MindfulnessActivity class with shared StartActivity, EndActivity, and Pause methods to demonstrate inheritance and avoid code duplication.
// Implemented a simple countdown animation in the base Pause method and slightly different countdowns in Breathing and Listing activities.
// Implemented a spinner animation in the Reflection activity.