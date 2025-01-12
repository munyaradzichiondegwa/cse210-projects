using System;

class Program
{
    static void Main()
    {
        // Prompt the user to enter their grade percentage
        Console.WriteLine("Enter your grade percentage.");
        int percentage = int.Parse(Console.ReadLine());

        // Variables to store letter grade and sign
        string letter = "";
        string sign = "";

        // Determine letter grade 
        if (percentage >= 90)
        {
            letter = "A";
            sign = "+";
        }
        else if (percentage >= 80)
        {
            letter = "B";
            sign = "+";
        }
        else if (percentage >= 70)
        {
            letter = "C";
            sign = "+";
        }
        else if (percentage >= 60)
        {
            letter = "D";
            sign = "+";
        }
        else
        {
            letter = "F";
            sign = "";
        }

        // Determine sign (#Strech challenge)

        // Only apply to A, B, C, D grades
        if (letter != "F" && letter != "A")


        { // Get the last digit of the percentage
            int lastDigit = percentage % 10;

            if (percentage % 10 >= 7)
            {
                sign = "+";
            }
            else if (percentage % 10 <= 2)
            {
                sign = "-";
            }
        }

        // Special case for A grade (no A+)

        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // combine letter and sign
        string grade = letter + sign;

        // Print the grade
        Console.WriteLine($"Your grade is: {grade}.");

        // Determine if the student passed

        if (percentage >= 70)
        {
            Console.WriteLine("Congrats! You passed the course!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the course. Keep working hard!");
        }
    }
}