using System;

class Program
{
    static void Main()
    {
        //Prompt the user for their first name
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();

        //Prompt the user for their last name
        Console.WriteLine("What is your last name?");
        string lastName = Console.ReadLine();

        // Print the user's name in specified format
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}