namespace UniversityDB.Models
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string GroupName { get; private set; }
        public Student(int id, string name, string email, string groupName)
        {
            Id = id;
            Name = name;
            Email = email;
            GroupName = groupName;
        }
        public void UpdateName(string name)
        {
            Name = name;
        }
        public void UpdateEmail(string email)
        {
            Email = email;
        }
        public void UpdateGroupName(string groupName)
        {
            GroupName = groupName;
        }
    }
}
