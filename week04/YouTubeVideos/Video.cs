using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        public List<VideoComment> Comments { get; set; } = new List<VideoComment>();

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
        }

        public void AddComment(VideoComment comment)
        {
            Comments.Add(comment);
        }

        public int CommentCount()
        {
            return Comments.Count;
        }
    }

    public class VideoComment
    {
        public string Text { get; set; }
        public string Author { get; set; }
    }
}
