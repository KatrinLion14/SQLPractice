using UniversityWebApi.Domain;
using UniversityWebApi.Dto;

namespace UniversityWebApi.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int id);
        int UpdateStudent(StudentDto student);
        int CreateStudent(StudentDto student);
    }
}
