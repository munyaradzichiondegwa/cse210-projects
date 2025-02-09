// This class helps store information about comments on the videos
using System;
using System.ComponentModel.Design;

public class Comment 
{
    // Tracking of who made the commnent and what they said
    private string _commenterName;
    private string _commentText;

    // When a new commednt is made, this will give a name and the comment
    public Comment(string commenterName, string commentText)
    {
        _commenterName = _commenterName;
        _commentText = _commentText;
    }

    // These methods let us get the commenter's name and comment text if we need them
    public string GetCommnenterName()
    {
        return _commenterName;
    }

    public string GetCommnentText()
    {
        return _commentText;
    }

}