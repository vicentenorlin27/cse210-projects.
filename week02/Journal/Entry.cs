using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _responseText;
    public string _mood;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_responseText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{_date}~|~{_promptText}~|~{_responseText}~|~{_mood}";
    }
}