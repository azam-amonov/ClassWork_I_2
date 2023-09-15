using ClassWork_C40.Domain.Entities;

namespace ClassWork_C40.Service.Interface;

public interface IStudentService
{
    Student Create(Student student);
    Student Update(Student student);
    bool Delete(long id);
    Student GetById(long id);
    IEnumerator<Student> GetAll();
}