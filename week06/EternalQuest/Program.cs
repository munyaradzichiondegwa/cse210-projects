using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalScore = 0;

        static void Main(string[] args)
        {
            LoadGoals();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Eternal Quest Program");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Add Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. View Goals");
                Console.WriteLine("4. Save and Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddGoal();
                        break;
                    case "2":
                        RecordEvent();
                        break;
                    case "3":
                        ViewGoals();
                        break;
                    case "4":
                        SaveGoals();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddGoal()
        {
            Console.Clear();
            Console.WriteLine("Add Goal");
            Console.WriteLine("--------");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choose goal type: ");
            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal value: ");
            int value = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, value));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, value));
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int target = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, value, target));
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Please try again.");
                    break;
            }
        }

        static void RecordEvent()
        {
            Console.Clear();
            Console.WriteLine("Record Event");
            Console.WriteLine("------------");
            Console.WriteLine("Choose a goal to record an event:");

            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }

            Console.Write("Enter goal number: ");
            if (!int.TryParse(Console.ReadLine(), out int goalIndex) || goalIndex < 1 || goalIndex > goals.Count)
            {
                Console.WriteLine("Invalid goal number. Please try again.");
                return;
            }

            goalIndex--; // Convert to 0-based index
            Goal selectedGoal = goals[goalIndex];
            selectedGoal.RecordEvent();
            totalScore += selectedGoal.Value;

            // Fixed variable initialization
            ChecklistGoal checklistGoal = selectedGoal as ChecklistGoal;
            if (checklistGoal != null && checklistGoal.IsComplete())
            {
                totalScore += selectedGoal.Value;
                Console.WriteLine("Bonus points awarded!");
            }

            Console.WriteLine("Event recorded successfully.");
        }

        static void ViewGoals()
        {
            Console.Clear();
            Console.WriteLine("View Goals");
            Console.WriteLine("----------");

            foreach (var goal in goals)
            {
                string status = goal.IsComplete() ? "[X]" : "[ ]";
                string progress = goal switch
                {
                    ChecklistGoal cg => $"Completed {cg.CompletedCount}/{cg.Target} times",
                    _ => ""
                };
                Console.WriteLine($"{status} {goal.Name} ({goal.GetType().Name}) {progress}");
            }

            Console.WriteLine($"Total Score: {totalScore}");
        }

        static void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(totalScore);
                foreach (var goal in goals)
                {
                    string extraData = goal switch
                    {
                        ChecklistGoal cg => $"{cg.Target};{cg.CompletedCount}",
                        _ => ";"
                    };
                    writer.WriteLine($"{goal.GetType().Name};{goal.Name};{goal.Value};{extraData}");
                }
            }
        }

        static void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                using (StreamReader reader = new StreamReader("goals.txt"))
                {
                    totalScore = int.Parse(reader.ReadLine());
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        string type = parts[0];
                        string name = parts[1];
                        int value = int.Parse(parts[2]);

                        switch (type)
                        {
                            case "SimpleGoal":
                                goals.Add(new SimpleGoal(name, value));
                                break;
                            case "EternalGoal":
                                goals.Add(new EternalGoal(name, value));
                                break;
                            case "ChecklistGoal":
                                int target = int.Parse(parts[3]);
                                int completed = int.Parse(parts[4]);
                                var goal = new ChecklistGoal(name, value, target);
                                goal.GetType().GetProperty("CompletedCount").SetValue(goal, completed);
                                goals.Add(goal);
                                break;
                        }
                    }
                }
            }
        }
    }
}