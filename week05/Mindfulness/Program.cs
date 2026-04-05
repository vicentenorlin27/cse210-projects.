using System;
using System.Collections.Generic;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> activityLog = new Dictionary<string, int>
            {
                { "Breathing Activity", 0 },
                { "Reflection Activity", 0 },
                { "Listing Activity", 0 }
            };

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflection activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. View activity log");
                Console.WriteLine("  5. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Run();
                        activityLog["Breathing Activity"]++;
                        break;

                    case "2":
                        ReflectionActivity reflection = new ReflectionActivity();
                        reflection.Run();
                        activityLog["Reflection Activity"]++;
                        break;

                    case "3":
                        ListingActivity listing = new ListingActivity();
                        listing.Run();
                        activityLog["Listing Activity"]++;
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Activity Log:");
                        foreach (var entry in activityLog)
                        {
                            Console.WriteLine($"{entry.Key}: completed {entry.Value} time(s)");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press Enter to return to the menu.");
                        Console.ReadLine();
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
    }
}