class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Views { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int views)
    {
        Title = title;
        Author = author;
        Views = views;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Views: {Views}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.Author}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

    