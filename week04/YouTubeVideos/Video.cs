// This class helps us create and manage our video information
using System;
using System.Collections.Generic;

public class Video 
{
    // Details about each video will be stored
    private string _title;
    private string _presenter;
    private int _videoLength;
    private List<Comment> _videoComments;

    // On creating new video, its basic details will be set
    public Video(string title, string presenter, int lenghtInSeconds)
    {
        _title = title;
        _presenter = presenter;
        _videoLength = lenghtInSeconds;
        _videoComments = new List<Comment>(); // start with an empty list of comments
    }

    // This nethod lets comments be added to videos
    public void AddComment(Comment newComment)
    {
        _videoComments.Add(newComment);
    }

    // This method counts number of comments
    public int CountComments()
    {
      return _videoComments.Count;  
    }

    // This method shows all the details about video
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Video Title: {_title}");
        Console.WriteLine($"Presented by: {_presenter}");
        Console.WriteLine($"Video Length: {_videoLength} seconds");
        Console.WriteLine($"Total Comments: {CountComments()}");

        // Show all comments in the video
        Console.WriteLine("\nVideo Comments:");
        foreach (Comment comment in _videoComments)
        {
            comment.ShowComment();
        }
        Console.WriteLine(); // Add a blank line for readability
   }
}

