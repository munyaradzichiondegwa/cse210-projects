// (Base Class)
public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Option 1: Protected access modifier (less restrictive than private)
    protected string StudentName { get { return _studentName; } }

    // Option 2: Public getter method (alternative to protected access)
    public string GetStudentName()
    {
        return _studentName;
    }
}