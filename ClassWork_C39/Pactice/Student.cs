namespace ClassWork_C39;

public class Student
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Student()
    {
        
    }
    public Student(long id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    
    public override string ToString() =>
                    $"{Id} {FirstName} {LastName}";
}