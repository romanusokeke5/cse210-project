using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _reflectionQuestions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void ExecuteActivity()
    {
        Console.WriteLine("\nConsider the following prompt:");
        string randomPrompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($"  --- {randomPrompt} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        Pause(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        Random random = new Random();

        while (DateTime.Now < endTime)
        {
            string randomQuestion = _reflectionQuestions[random.Next(_reflectionQuestions.Count)];
            Console.WriteLine($"> {randomQuestion}");
            Console.Write("Reflecting");
            AnimateSpinner(5); // Use a spinner animation
            Console.WriteLine();
        }
    }

    private void AnimateSpinner(int iterations)
    {
        char[] spinnerChars = { '-', '\\', '|', '/' };
        for (int i = 0; i < iterations; i++)
        {
            Console.Write(spinnerChars[i % spinnerChars.Length]);
            Thread.Sleep(300);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}