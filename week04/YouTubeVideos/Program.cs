using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of Video
        Video video1 = new Video("Exploring Abstraction in OOP", "Munyaradzi Chiondegwa", 600);
        Video video2 = new Video("Understanding Encapsulation in C#", "Nevanji Munyaradzi", 720);
        Video video3 = new Video("Intro to Polymorphism", "Kuda Wayne Chiviti", 540);

        // Add comments to each video
        video1.AddComment(new Comment("Mufaro", "Great explanation! The video masterfully breaks down complex concepts into easily digestible segments, making it highly accessible to viewers of all levels."));
        video1.AddComment(new Comment("Thabiso", "Very informative. The information is presented in a clear and structured manner, making it easy to follow and comprehend."));
        video1.AddComment(new Comment("Taurai", "Your explanation provided significant clarity, and I'm grateful for the assistance. It made a big difference in my understanding. Thank you so much!"));

        video2.AddComment(new Comment("Mona", "Insightful and succinct, truly worth your time."));
        video2.AddComment(new Comment("Hazel", "I absolutely loved the examples presented in the video. They were clear, relevant, and made the complex concepts much easier to understand.."));
        video2.AddComment(new Comment("Vimbai", "This provided me with a clear understanding of encapsulation. Your explanation was immensely helpful in grasping the concept. Thank you!"));

        video3.AddComment(new Comment("Tanyaradzwa", "Polymorphism is truly remarkable. Its ability to allow objects to take on multiple forms is incredibly powerful and versatile in programming. Got that from the video"));
        video3.AddComment(new Comment("Nomusa", "I really appreciate the high-quality content you've provided. It's been incredibly helpful and insightful. Thanks a lot for sharing!"));
        video3.AddComment(new Comment("Mazvita", "This has been incredibly beneficial for my studies. I truly appreciate the clarity and depth of the material."));

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
