using UniversityDB.Models;

namespace UniversityDB.Repositories
{
    internal interface IProfessorRepository
    {
        IReadOnlyList<Professor> GetAll();
    }
}
