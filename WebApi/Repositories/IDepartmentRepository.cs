using UniversityWebApi.Domain;

namespace UniversityWebApi.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetByName(string name);
        void Delete(Department department);
        int Update(Department department);
        int Create(Department department);
        List<Tuple<string, int>> GetDepartmentCountGroupByAddress();
    }
}
