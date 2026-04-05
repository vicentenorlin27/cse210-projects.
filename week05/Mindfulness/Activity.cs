using System;
using System.Threading;

namespace Mindfulness
{
    public class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetDuration()
        {
            return _duration;
        }

        public void SetDuration(int duration)
        {
            _duration = duration;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");

            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }

            SetDuration(duration);

            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            ShowSpinner(3);

            Console.WriteLine();
            Console.WriteLine($"You have completed another {GetDuration()} seconds of the {_name}.");
            ShowSpinner(3);
        }

        public void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write(spinner[i]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;

                if (i >= spinner.Length)
                {
                    i = 0;
                }
            }
        }

        public void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);

                if (i < 10)
                {
                    Console.Write("\b \b");
                }
                else
                {
                    Console.Write("\b\b  \b\b");
                }
            }
        }
    }
}