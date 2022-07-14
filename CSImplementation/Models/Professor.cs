namespace UniversityDB.Models
{
    public class Professor
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Subject { get; private set; }
        public string DepartmentName { get; private set; }
        public Professor(string email, string name, string subject, string departmentName)
        {
            Email = email;
            Name = name;
            Subject = subject;
            DepartmentName = departmentName;
        }
        public void UpdateName(string name)
        {
            Name = name;
        }
        public void UpdateSubject(string subject)
        {
            Subject = subject;
        }
        public void UpdateDepartmentName(string departmentName)
        {
            DepartmentName = departmentName;
        }
    }
}
