using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list to store numbers
        List<int> numbers = new List<int>();

        // Add numbers to the list
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Input loop
        while (true)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            // Check if the number is 0, break the loop
            if (number == 0)
            {
                break;
            }

            // Add the number to the list
            numbers.Add(number);

        }

        // Core Requirement 1: Compute the sum of the numbers
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Core Requirement 2: Compute the average of the numbers
        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;

        // Core Requirement 3: Find the maximum number
        int max = numbers.Count > 0 ? numbers.Max() : 0;

        // Display core requirements results
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Max: {max}");

        // Stretch Challenge 1: Find the smallest positive number
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        int minPositive = positiveNumbers.Count > 0 ? positiveNumbers.Min() : 0;

        // Stretch Challenge 2: Sort and display the list of numbers
        numbers.Sort();

        // Display stretch challenges results
        if (positiveNumbers.Count > 0)
        {
            Console.WriteLine($"Min Positive: {minPositive}");
        }

        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}