using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void ExecuteActivity()
    {
        Console.WriteLine("\nGet ready to begin breathing...");
        Pause(3);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            Pause(4);
            if (DateTime.Now >= endTime) break;
            Console.WriteLine("Now breathe out...");
            Pause(6);
        }
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