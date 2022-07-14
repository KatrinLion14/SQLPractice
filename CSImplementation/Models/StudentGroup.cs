namespace UniversityDB.Models
{
    public class StudentGroup
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string ProfessorEmail { get; private set; }
        public StudentGroup(string name, string email, string professorEmail)
        {
            Name = name;
            Email = email;
            ProfessorEmail = professorEmail;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }
        public void UpdateProfessorEmail(string professorEmail)
        {
            ProfessorEmail = professorEmail;
        }
    }
}
