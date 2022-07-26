using UniversityWebApi.Domain;

namespace UniversityWebApi.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Delete(Student student);
        int Update(Student student);
        int Create(Student student);
    }
}
