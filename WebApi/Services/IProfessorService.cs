using UniversityWebApi.Domain;
using UniversityWebApi.Dto;

namespace UniversityWebApi.Services
{
    public interface IProfessorService
    {
        List<Professor> GetAllProfessors();
        Professor GetProfessorByEmail(string email);
        void DeleteProfessor(string email);
        int UpdateProfessor(ProfessorDto professor);
        int CreateProfessor(ProfessorDto professor);
    }
}
