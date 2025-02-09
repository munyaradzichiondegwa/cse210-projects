// This class helps store information about comments on the videos
class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }
}
