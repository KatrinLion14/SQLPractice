using UniversityWebApi.Domain;

namespace UniversityWebApi.Dto
{
    public static class StudentDtoExtensions
    {
        public static Student ConvertToStudent(this StudentDto studentDto)
        {
            return new Student(studentDto.Id, studentDto.Name,
                studentDto.Email, studentDto.GroupName);
        }

        public static StudentDto ConvertToStudentDto(this Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                GroupName = student.GroupName
            };
        }
    }
}
