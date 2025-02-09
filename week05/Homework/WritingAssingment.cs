// WritingAssignment.cs (Derived Class)
public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Accessing _studentName using either the protected property or the getter method
        return $"{_title} by {StudentName}"; // Using protected property
        // return $"{_title} by {GetStudentName()}"; // Using public getter method - uncomment if preferred
    }
}