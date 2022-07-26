namespace UniversityWebApi.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string GroupName { get; set; }
        public Student(int id, string name, string email, string groupName)
        {
            Id = id;
            Name = name;
            Email = email;
            GroupName = groupName;
        }
    }
}
