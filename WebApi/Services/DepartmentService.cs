using UniversityWebApi.Domain;
using UniversityWebApi.Dto;
using UniversityWebApi.Repositories;

namespace UniversityWebApi.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public int CreateDepartment(DepartmentDto department)
        {
            if (department == null)
            {
                throw new Exception($"{nameof(Department)} not found");
            }
            Department departmentEntity = department.ConvertToDepartment();
            return _departmentRepository.Create(departmentEntity);
        }

        public void DeleteDepartment(string name)
        {
            Department department = _departmentRepository.GetByName(name);
            if (department == null)
            {
                throw new Exception($"{nameof(Department)} not found, #Name - {name}");
            }
            _departmentRepository.Delete(department);
        }

        public Department GetDepartmentByName(string name)
        {
            Department department = _departmentRepository.GetByName(name);
            if (department == null)
            {
                throw new Exception($"{nameof(Department)} not found, #Name - {name}");
            }
            return department;
        }

        public List<Tuple<string, int>> GetDepartmentCountGroupByAddress()
        {
            return _departmentRepository.GetDepartmentCountGroupByAddress();
        }

        public List<Department> GetDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public int UpdateDepartment(DepartmentDto department)
        {
            if (department == null)
            {
                throw new Exception($"{nameof(Department)} not found");
            }
            Department departmentEntity = department.ConvertToDepartment();
            Department departmentTemp = _departmentRepository.GetByName(departmentEntity.Name);
            if (departmentTemp == null)
            {
                throw new Exception($"{nameof(Department)} not found");
            }
            return _departmentRepository.Update(departmentEntity);
        }
    }
}
