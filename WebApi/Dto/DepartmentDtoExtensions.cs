using UniversityWebApi.Domain;

namespace UniversityWebApi.Dto
{
    public static class DepartmentDtoExtensions
    {
        public static Department ConvertToDepartment(this DepartmentDto departmentDto)
        {
            return new Department(departmentDto.Name, departmentDto.Office,
                departmentDto.Address, departmentDto.PhoneNumber);
        }

        public static DepartmentDto ConvertToDepartmentDto(this Department department)
        {
            return new DepartmentDto
            {
                Name = department.Name,
                Office = department.Office,
                Address = department.Address,
                PhoneNumber = department.PhoneNumber
            };
        }
    }
}
