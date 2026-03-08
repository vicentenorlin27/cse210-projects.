using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        while (guess != magicNumber)
        {
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("You guessed it!");
    }
}