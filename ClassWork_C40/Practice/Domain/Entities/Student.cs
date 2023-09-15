namespace ClassWork_C40.Domain.Entities;

public class Student
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    string ProjectPath { get; set; }
    public string CrmId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDateTime { get; set; }

    public Student()
    {
        
    }
    
    public Student(long id, string firstName, string lastName, string projectPath, string crmId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        ProjectPath = projectPath;
        CrmId = crmId;
        CreatedDateTime = DateTime.Now;
    }
}