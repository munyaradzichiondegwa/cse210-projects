using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalManager
    {
        private readonly List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new();
            _score = 0;
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                int pointsEarned = _goals[goalIndex].RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"Event recorded! You earned {pointsEarned} points.");
            }
            else
            {
                Console.WriteLine("Invalid goal index.");
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Your total score is: {_score} points.");
        }

        public void SaveGoals(string fileName)
        {
            using StreamWriter outputFile = new(fileName);
            outputFile.WriteLine(_score);
            foreach (var goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        public void LoadGoals(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                _score = int.Parse(lines[0]);
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(':');
                    string type = parts[0];
                    string[] details = parts[1].Split(',');

                    switch (type)
                    {
                        case "SimpleGoal":
                            var simpleGoal = new SimpleGoal(details[0], details[1], int.Parse(details[2]))
                            {
                                IsCompleted = bool.Parse(details[3])
                            };
                            _goals.Add(simpleGoal);
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                            break;
                        case "ChecklistGoal":
                            var checklistGoal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[3]))
                            {
                                CompletedCount = int.Parse(details[5])
                            };
                            _goals.Add(checklistGoal);
                            break;
                    }
                }
            }
        }
    }
}