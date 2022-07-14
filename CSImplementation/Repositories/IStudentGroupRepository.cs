using UniversityDB.Models;

namespace UniversityDB.Repositories
{
    internal interface IStudentGroupRepository
    {
        IReadOnlyList<StudentGroup> GetAll();
        IReadOnlyList<Tuple<StudentGroup, int>> GetGroupsWithStudentsAmount(int amount);
    }
}
