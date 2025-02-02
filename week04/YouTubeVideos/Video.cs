using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; } // Duration in seconds
    public int Views { get; set; }
    public int Likes { get; set; }
    public DateTime UploadDate { get; set; }
    public string Uploader { get; set; }
    public List<string> Tags { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string description, int duration, int views, int likes, DateTime uploadDate, string uploader, List<string> tags)
    {
        Title = title;
        Description = description;
        Duration = duration;
        Views = views;
        Likes = likes;
        UploadDate = uploadDate;
        Uploader = uploader;
        Tags = tags;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void Play()
    {
        // Code to play the video
    }

    public void Pause()
    {
        // Code to pause the video
    }

    public void Like()
    {
        Likes++;
    }

    public void Dislike()
    {
        // Code to dislike the video
    }

    public void Share()
    {
        // Code to share the video
    }
}
