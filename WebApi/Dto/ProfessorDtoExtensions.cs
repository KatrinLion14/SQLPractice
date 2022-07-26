using UniversityWebApi.Domain;

namespace UniversityWebApi.Dto
{
    public static class ProfessorDtoExtensions
    {
        public static Professor ConvertToProfessor(this ProfessorDto professorDto)
        {
            return new Professor(professorDto.Email, professorDto.Name,
                professorDto.Subject, professorDto.DepartmentName);
        }

        public static ProfessorDto ConvertToProfessorDto(this Professor professor)
        {
            return new ProfessorDto
            {
                Email = professor.Email,
                Name = professor.Name,
                Subject = professor.Subject,
                DepartmentName = professor.DepartmentName
            };
        }
    }
}
