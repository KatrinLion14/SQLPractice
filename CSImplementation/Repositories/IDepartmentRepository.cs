using UniversityDB.Models;

namespace UniversityDB.Repositories
{
    internal interface IDepartmentRepository
    {
        IReadOnlyList<Department> GetAll();
        Department GetByName(string name);
        IReadOnlyList<Department> GetByAddress(string address);
        void Delete(Department department);
        void Update(Department department);
    }
}
