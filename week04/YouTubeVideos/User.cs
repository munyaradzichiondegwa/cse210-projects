using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public List<string> Subscriptions { get; set; }
    public List<Playlist> Playlists { get; set; }
    public List<Video> UploadedVideos { get; set; }

    public User(string username, string email)
    {
        Username = username;
        Email = email;
        Subscriptions = new List<string>();
        Playlists = new List<Playlist>();
        UploadedVideos = new List<Video>();
    }

    public void SubscribeToChannel(string channel)
    {
        Subscriptions.Add(channel);
    }

    public void CreatePlaylist(string name)
    {
        Playlists.Add(new Playlist(name, Username));
    }

    public void UploadVideo(Video video)
    {
        UploadedVideos.Add(video);
    }

    public void LikeVideo(Video video)
    {
        video.Like();
    }
}
