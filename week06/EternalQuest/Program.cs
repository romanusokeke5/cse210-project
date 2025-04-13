using System;
using System.Collections.Generic;
using System.IO;

// ===== Abstract Goal Class =====
abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
    public virtual int GetPoints() => _points;
}

// ===== SimpleGoal =====
class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"✅ You earned {_points} points!");
        }
        else
        {
            Console.WriteLine("⚠️ This goal is already complete.");
        }
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString()
        => $"[ {(IsComplete() ? "X" : " ")} ] {_shortName} ({_description})";

    public override string GetStringRepresentation()
        => $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
}

// ===== EternalGoal =====
class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"🔁 You earned {_points} points!");
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
        => $"[ ] {_shortName} ({_description})";

    public override string GetStringRepresentation()
        => $"EternalGoal|{_shortName}|{_description}|{_points}";
}

// ===== ChecklistGoal =====
class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"📌 You earned {_points} points!");

            if (_amountCompleted == _target)
            {
                Console.WriteLine($"🏆 BONUS! You completed this goal and earned {_bonus} bonus points!");
            }
        }
        else
        {
            Console.WriteLine("✅ This goal is already completed.");
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
        => $"[ {(IsComplete() ? "X" : " ")} ] {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target}";

    public override string GetStringRepresentation()
        => $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";

    public override int GetPoints()
    {
        return _points + (IsComplete() && _amountCompleted == _target ? _bonus : 0);
    }
}

// ===== GoalManager =====
class GoalManager
{
    private List<Goal> _goals = new();
    private int _score = 0;
    private int _level = 1;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n🌟 Eternal Quest Menu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create New Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": DisplayPlayerInfo(); break;
                case "2": ListGoals(); break;
                case "3": CreateGoal(); break;
                case "4": RecordEvent(); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": return;
                default: Console.WriteLine("❌ Invalid choice."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n🎮 Score: {_score} | 🧙 Level: {_level} (Next level: {_level * 1000})");
        Console.ResetColor();
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type:\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
        Console.Write("Type: ");
        string choice = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Target times: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine("Which goal did you complete?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Select goal #: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal g = _goals[index];
            g.RecordEvent();

            int pointsEarned = g.GetPoints();
            _score += pointsEarned;
            LevelUpCheck();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void LevelUpCheck()
    {
        int nextLevel = (_score / 1000) + 1;
        if (nextLevel > _level)
        {
            _level = nextLevel;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n🎉 LEVEL UP! You are now Level {_level}!");
            Console.ResetColor();
        }
    }

    public void SaveGoals()
    {
        using StreamWriter writer = new("goals.txt");
        writer.WriteLine(_score);
        writer.WriteLine(_level);
        foreach (Goal g in _goals)
        {
            writer.WriteLine(g.GetStringRepresentation());
        }
        Console.WriteLine("✅ Progress saved.");
    }

    public void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("❌ No save file found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[4])));
                    break;
            }
        }

        Console.WriteLine("✅ Goals loaded.");
    }
}

// ===== Main Program Entry =====
class Program
{
    static void Main(string[] args)
    {
        // ✨ Enhancements:
        // - Leveling system (1000 points per level)
        // - Console colors
        // - Clean design and encapsulation
        // - Gamified feedback and scoring
        GoalManager manager = new();
        manager.Start();
    }
}
// ===== End of Program =====
// Note: This code is a simple console application for managing goals in a gamified way.