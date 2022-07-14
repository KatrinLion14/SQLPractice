using UniversityDB.Models;

namespace UniversityDB.Repositories
{
    internal interface IStudentRepository
    {
        IReadOnlyList<Student> GetAll();
    }
}
