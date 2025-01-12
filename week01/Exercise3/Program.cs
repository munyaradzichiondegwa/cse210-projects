using System;

class Program
{
    static void Main(string[] args)
    {
        // Start-off random number generator
        Random randomGenerator = new Random();

        // Variable to track whether the user wants to play again
        string playAgain = "yes";

        // Loop to keep the game running
        while (playAgain.ToLower() == "yes")
        {
            // Generate a random number between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);

            // Variable to track number of guesses
            int guessCount = 0;

            // Variable to store user's guess
            int guess;

            // Main game loop
            do
            {
                // Prompt the user to guess the number
                Console.WriteLine("What is your guess?");
                guess = int.Parse(Console.ReadLine());

                // Increment the number of guesses

                guessCount++;

                // Provide feedback to  the user
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher.");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower.");
                }
            } while (guess != magicNumber);

            // Winning message
            Console.WriteLine("You guessed the magic number!");

            // Display the number of guesses (Stretch Challenge)
            Console.WriteLine($"You guessed the magic number in {guessCount} guesses.");
            // Prompt the user to play again
            Console.WriteLine("Do you want to play again? (yes/no)");
            playAgain = Console.ReadLine();
        }
        // Farewell message
        Console.WriteLine("Thank you for playing. Goodbye!");
    }
}