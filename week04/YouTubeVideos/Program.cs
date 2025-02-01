using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of Video
        Video video1 = new Video("Exploring Abstraction in OOP", "Munyaradzi Chiondegwa", 600);
        Video video2 = new Video("Understanding Encapsulation in C#", "Jane Doe", 720);
        Video video3 = new Video("Intro to Polymorphism", "John Smith", 540);

        // Add comments to each video
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "Helped me a lot, thanks!"));

        video2.AddComment(new Comment("David", "Clear and concise."));
        video2.AddComment(new Comment("Eve", "Loved the examples."));
        video2.AddComment(new Comment("Frank", "Really helped me understand encapsulation."));

        video3.AddComment(new Comment("Grace", "Polymorphism is amazing."));
        video3.AddComment(new Comment("Heidi", "Thanks for the great content."));
        video3.AddComment(new Comment("Ivan", "Very helpful for my studies."));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"{comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
