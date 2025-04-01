using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    private int _durationInSeconds;
    protected string _activityName;
    protected string _description;

    public MindfulnessActivity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public string Name => _activityName;
    public string Description => _description;

    public void StartActivity()
    {
        Console.WriteLine($"Welcome to the {Name}");
        Console.WriteLine(Description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like your session to be? ");
        string durationInput = Console.ReadLine();
        if (int.TryParse(durationInput, out _durationInSeconds))
        {
            Console.WriteLine("Prepare to begin...");
            Pause(3);
        }
        else
        {
            Console.WriteLine("Invalid duration. Please enter a number.");
            // Potentially handle this more robustly, like re-prompting
            _durationInSeconds = 0;
        }
    }

    public void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Pause(2);
        Console.WriteLine($"You have completed the {Name} for {_durationInSeconds} seconds.");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"Pausing for {i}...");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - (8 + i.ToString().Length), Console.CursorTop);
        }
        Console.WriteLine("Paused.");
    }

    protected int GetDuration()
    {
        return _durationInSeconds;
    }

    public abstract void ExecuteActivity();
}