using System;
using System.Collections.Generic;

// Activity.cs (Base class)
public class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Default implementation
    }

    public virtual double GetSpeed()
    {
        return 0; // Default implementation
    }

    public virtual double GetPace()
    {
        return 0; // Default implementation
    }

    public string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }
}