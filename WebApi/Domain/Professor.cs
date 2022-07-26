namespace UniversityWebApi.Domain
{
    public class Professor
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string DepartmentName { get; set; }
        public Professor(string email, string name, string subject, string departmentName)
        {
            Email = email;
            Name = name;
            Subject = subject;
            DepartmentName = departmentName;
        }
    }
}
