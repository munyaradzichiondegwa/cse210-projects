using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> techVideos = new List<Video>();

        // First video 
        Video pythonVideo = new Video("Python for Beginners", "Munyaradzi Chiondegwa", 1200);

        // Add student comments
        pythonVideo.AddComment(new Comment("Absalom", "This video has opened my eyes to the world fo coding." ));
        pythonVideo.AddComment(new Comment("Farai", "The way Munya explains things makes it so easy to grasp concepts."));
        pythonVideo.AddComment(new Comment("Ruth", "Perfect intro to programming."));
        techVideos.Add(pythonVideo);

        // Second video  
        Video csharpVideo = new Video("C# Programming Basics", "Kuda Chiviti", 1800);

        // Add student comments
        csharpVideo.AddComment(new Comment("Tendai", "Now i understand abstraction."));
        csharpVideo.AddComment(new Comment("Blessing", "Great step by step explanation."));
        csharpVideo.AddComment(new Comment("Masimba", "This helped me a lot with my coding class."));
        techVideos.Add(csharpVideo);

        // Third video
        Video webDevVideo = new Video("Web Development Fundamentals", "Wayne Hobwani", 3000);

        // Add student comments
        webDevVideo.AddComment(new Comment("Chichi", "Now i understand how websites work."));
        webDevVideo.AddComment(new Comment("Talent", "Lazy loading anyone?"));
        webDevVideo.AddComment(new Comment("Kudzi", "Web dev made easy!"));
        techVideos.Add(webDevVideo);

        // Show information about all the videos
        Console.WriteLine("=== Tech learning Video Collection ===\n");
        foreach (Video video in techVideos)
        { 
           video.DisplayVideoInfo();
        }
    }
}
