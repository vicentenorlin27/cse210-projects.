using System;
using System.IO;

// Exceeding requirements:
// I added an extra feature that allows the user to record their mood
// along with each journal entry. This gives more detail to each entry
// and makes the journal more meaningful than only storing the date,
// prompt, and response.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string userInput = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(userInput, out choice))
            {
                if (choice == 1)
                {
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("How would you describe your mood today? ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._responseText = response;
                    newEntry._mood = mood;

                    journal.AddEntry(newEntry);

                    Console.WriteLine("Entry added successfully.");
                    Console.WriteLine();
                }
                else if (choice == 2)
                {
                    journal.DisplayAll();
                }
                else if (choice == 3)
                {
                    Console.Write("Enter filename to load: ");
                    string fileName = Console.ReadLine();

                    if (File.Exists(fileName))
                    {
                        journal.LoadFromFile(fileName);
                        Console.WriteLine("Journal loaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                    }

                    Console.WriteLine();
                }
                else if (choice == 4)
                {
                    Console.Write("Enter filename to save: ");
                    string fileName = Console.ReadLine();

                    journal.SaveToFile(fileName);
                    Console.WriteLine("Journal saved successfully.");
                    Console.WriteLine();
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose 1-5.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine();
            }
        }
    }
}