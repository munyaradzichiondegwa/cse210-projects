using System;

namespace EternalQuest
{
    class Program
    {
        private static GoalManager goalManager = new GoalManager();

        static void Main(string[] args)
        {
            goalManager.LoadGoals("goals.txt");
            while (true)
            {
                Console.WriteLine("\nEternal Quest Program");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Show Goals");
                Console.WriteLine("4. Show Score");
                Console.WriteLine("5. Save and Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        RecordEvent();
                        break;
                    case "3":
                        goalManager.DisplayGoals();
                        break;
                    case "4":
                        goalManager.DisplayScore();
                        break;
                    case "5":
                        goalManager.SaveGoals("goals.txt");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateNewGoal()
        {
            Console.WriteLine("Select Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choose an option: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points for completing the goal: ");
            int points = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    goalManager.AddGoal(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    goalManager.AddGoal(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("Enter target number of completions: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points for completing the target: ");
                    int bonus = int.Parse(Console.ReadLine());
                    goalManager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid option. Goal not created.");
                    break;
            }
        }

        static void RecordEvent()
        {
            goalManager.DisplayGoals();
            Console.Write("Select a goal to record: ");
            int choice = int.Parse(Console.ReadLine()) - 1;
            goalManager.RecordEvent(choice);
        }
    }
}