using System;

class Program
{
    // Function 1: Display Welcome Message
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function 2: Prompt for the user's name
    static string PromptForName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function 3: Prompt for the User Number
    static int PromptForNumber()
    {
        Console.Write("Please enter a number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function 4: Square the Number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function 5: Display the Result
    static void DisplayResult(string name, int number, int squaredNumber)
    {
        Console.WriteLine($"Hello {name}, the square of {number} is {squaredNumber}");
    }

    // Main function to orchestrate the program
    static void Main()
    {
        // Call the welcome message function
        DisplayWelcomeMessage();

        // Call the prompt for name function
        string name = PromptForName();

        // Call the prompt for number function
        int number = PromptForNumber();

        // Call the square number function
        int squaredNumber = SquareNumber(number);

        // Call the display final result function
        DisplayResult(name, number, squaredNumber);
    }

}