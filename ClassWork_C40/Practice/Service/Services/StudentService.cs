using ClassWork_C40.Domain.Entities;
using ClassWork_C40.Service.Interface;

namespace ClassWork_C40.Service.Services;

public class StudentService : IStudentService
{
    private List<Student> _students;
    private long _lastId;

    public StudentService()
    {
        _students = new List<Student>();
    }
    
    public Student Create(Student student)
    {
        student = new Student()
        { 
                        Id = _lastId++, 
                        FirstName = student.FirstName, 
                        LastName = student.LastName,
                        CrmId = student.CrmId,
        };
        _students.Add(student);
        
        return student;
        
    }

    public Student Update(Student student)
    {
        throw new NotImplementedException();
    }

    public bool Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Student GetById(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<Student> GetAll()
    {
        throw new NotImplementedException();
    }
}