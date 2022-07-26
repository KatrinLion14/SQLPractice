using UniversityWebApi.Domain;

namespace UniversityWebApi.Repositories
{
    public interface IProfessorRepository
    {
        List<Professor> GetAll();
        Professor GetByEmail(string email);
        void Delete(Professor professor);
        int Update(Professor professor);
        int Create(Professor professor);
    }
}
