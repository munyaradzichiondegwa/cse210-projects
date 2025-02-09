using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace YouTubeVideos
{
    class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        var techVideos = new List<Video>();
        var pythonVideo = new Video("Python for Beginners", "Munyaradzi Chiondegwa", 1200);
        pythonVideo.AddComment(new Comment("Farai", "The way Munya explains things makes it so easy to grasp concepts."));
        pythonVideo.AddComment(new Comment("Tapiwa", "This video really helped me understand Python!"));
        pythonVideo.AddComment(new Comment("Ruth", "Perfect intro to programming."));
        techVideos.Add(pythonVideo);

        // Second video  
        var csharpVideo = new Video("C# Programming Basics", "Kuda Chiviti", 1800);
        // Add student comments
        csharpVideo.AddComment(new Comment("Masimba", "This helped me a lot with my coding class."));
        csharpVideo.AddComment(new Comment("Tendai", "Great step-by-step explanation"));
        csharpVideo.AddComment(new Comment("Blessing", "Now I understand more about classes."));
        techVideos.Add(csharpVideo);

        // Third video
        var webDevVideo = new Video("Web Development Fundamentals", "Wayne Hobwani", 3000);
        // Add student comments
        webDevVideo.AddComment(new Comment("Chichi", "Now i understand how websites work."));
        webDevVideo.AddComment(new Comment("Talent", "Amazing tutorial for beginners."));
        webDevVideo.AddComment(new Comment("Kudzi", "Lazy loading anybody?"));
        techVideos.Add(webDevVideo);

        // Show information about all the videos
        Console.WriteLine("=== Tech learning Video Collection ===\n");
        foreach (Video video in techVideos)
        { 
           video.DisplayVideoInfo();
        }
    }
}

}
