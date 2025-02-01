using System;

namespace YouTubeVideos
{
    public class Comment
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }

        public Comment(string authorName, string text)
        {
            AuthorName = authorName;
            Text = text;
        }
    }
}