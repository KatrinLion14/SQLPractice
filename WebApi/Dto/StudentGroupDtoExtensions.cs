using UniversityWebApi.Domain;

namespace UniversityWebApi.Dto
{
    public static class StudentGroupDtoExtensions
    {
        public static StudentGroup ConvertToStudentGroup(this StudentGroupDto studentGroupDto)
        {
            return new StudentGroup(studentGroupDto.Name, studentGroupDto.Email,
                studentGroupDto.ProfessorEmail);
        }

        public static StudentGroupDto ConvertToStudentGroupDto(this StudentGroup studentGroup)
        {
            return new StudentGroupDto
            {
                Name = studentGroup.Name,
                Email = studentGroup.Email,
                ProfessorEmail = studentGroup.ProfessorEmail
            };
        }
    }
}
