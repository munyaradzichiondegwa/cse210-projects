using System; 

namespace YouTubeVideos
{
    class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public List<Comment> Comments { get; set; }
        public int Length { get; set; }
        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {Length} seconds");
            Console.WriteLine("Comments:");
            foreach (var comment in Comments)
            {
                Console.WriteLine($"- {comment.Author}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

    