using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Entry.cs
public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

// Journal.cs
public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.");
            return;
        }
        Console.WriteLine("\n----- Your Journal Entries -----\n");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
        Console.WriteLine("-------------------------------\n");
    }

    public void SaveJournal(string filename, string separator = "~|~")
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}{separator}{entry.Prompt}{separator}{entry.Response}");
                }
            }
            Console.WriteLine($"Journal saved to '{filename}' successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal to '{filename}': {ex.Message}");
        }
    }

    public void LoadJournal(string filename, string separator = "~|~")
    {
        entries.Clear();
        try
        {
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(separator);
                        if (parts.Length == 3)
                        {
                            entries.Add(new Entry { Date = parts[0], Prompt = parts[1], Response = parts[2] });
                        }
                        else
                        {
                            Console.WriteLine($"Warning: Skipping invalid line in '{filename}': {line}");
                        }
                    }
                }
                Console.WriteLine($"Journal loaded from '{filename}' successfully.");
            }
            else
            {
                Console.WriteLine($"File '{filename}' not found. Starting with an empty journal.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal from '{filename}': {ex.Message}");
        }
    }
}

// Program.cs
public class Program
{
    private Journal journal;
    private List<string> prompts;

    public Program()
    {
        journal = new Journal();
        prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one thing I learned today?", // Added prompt
            "What am I grateful for today?",    // Added prompt
        };
    }

    public void DisplayMenu()
    {
        Console.WriteLine("\nJournal Program Menu:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
    }

    public void Run()
    {
        string choice;
        do
        {
            DisplayMenu();
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter the filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJournal(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter the filename to load from: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadJournal(loadFilename);
                    break;
                case "5":
                    Console.WriteLine("Exiting the Journal Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != "5");
    }

    public void WriteNewEntry()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"\nToday's Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string today = DateTime.Now.ToString("yyyy-MM-dd");
        Entry newEntry = new Entry { Prompt = prompt, Response = response, Date = today };
        journal.AddEntry(newEntry);
        Console.WriteLine("Entry added to your journal.");
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }
}
