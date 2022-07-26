using UniversityWebApi.Domain;
using UniversityWebApi.Dto;
using UniversityWebApi.Repositories;

namespace UniversityWebApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public int CreateStudent(StudentDto student)
        {
            if (student == null)
            {
                throw new Exception($"{nameof(Student)} not found");
            }
            Student studentEntity = student.ConvertToStudent();
            return _studentRepository.Create(studentEntity);
        }

        public void DeleteStudent(int id)
        {
            Student student = _studentRepository.GetById(id);
            if (student == null)
            {
                throw new Exception($"{nameof(Student)} not found, #Id - {id}");
            }
            _studentRepository.Delete(student);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudentById(int id)
        {
            Student student = _studentRepository.GetById(id);
            if (student == null)
            {
                throw new Exception($"{nameof(Student)} not found, #Id - {id}");
            }
            return student;
        }

        public int UpdateStudent(StudentDto student)
        {
            if (student == null)
            {
                throw new Exception($"{nameof(Student)} not found");
            }
            Student studentEntity = student.ConvertToStudent();
            Student studentTemp = _studentRepository.GetById(studentEntity.Id);
            if (studentTemp == null)
            {
                throw new Exception($"{nameof(Student)} not found");
            }
            return _studentRepository.Update(studentEntity);
        }
    }
}
