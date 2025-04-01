using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : MindfulnessActivity
{
    private List<string> _listingPrompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void ExecuteActivity()
    {
        Console.WriteLine("\nConsider the following prompt:");
        string randomPrompt = _listingPrompts[new Random().Next(_listingPrompts.Count)];
        Console.WriteLine($"  --- {randomPrompt} ---");
        Console.WriteLine("\nGet ready to start listing in:");
        Pause(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        List<string> itemsListed = new List<string>();
        Console.WriteLine("Begin listing items:");

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemsListed.Add(item);
            }
        }

        Console.WriteLine($"\nYou listed {itemsListed.Count} items!");
    }

    protected new void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"  {i}  ");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop);
        }
        Console.WriteLine();
    }
}