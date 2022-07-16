using UniversityWebApi.Domain;
using UniversityWebApi.Dto;

namespace UniversityWebApi.Services
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        Department GetDepartmentByName(string name);
        void DeleteDepartment(string name);
        int CreateDepartment(DepartmentDto department);
        int UpdateDepartment(DepartmentDto department);
        List<Tuple<string, int>> GetDepartmentCountGroupByAddress();
    }
}
