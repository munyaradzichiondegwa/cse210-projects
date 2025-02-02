using System;
using System.Collections.Generic;

public class Playlist
{
    public string Name { get; set; }
    public List<Video> Videos { get; set; }
    public DateTime CreationDate { get; set; }
    public string Owner { get; set; }

    public Playlist(string name, string owner)
    {
        Name = name;
        Videos = new List<Video>();
        CreationDate = DateTime.Now;
        Owner = owner;
    }

    public void AddVideo(Video video)
    {
        Videos.Add(video);
    }

    public void RemoveVideo(Video video)
    {
        Videos.Remove(video);
    }

    public void PlayAll()
    {
        // Code to play all videos in the playlist
    }

    public void Shuffle()
    {
        // Code to shuffle the videos in the playlist
    }
}
