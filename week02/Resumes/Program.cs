// Job.cs
using System.Collections.Generic;

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

// Resume.cs

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}

// Program.cs

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Systems Analyst";
        job1._company = "DandeMutande";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "Econet Wireless";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume resume = new Resume();
        resume._name = "Munyaradzi Chiondegwa";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}
