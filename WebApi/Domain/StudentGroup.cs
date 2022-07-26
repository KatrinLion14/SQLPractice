namespace UniversityWebApi.Domain
{
    public class StudentGroup
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfessorEmail { get; set; }
        public StudentGroup(string name, string email, string professorEmail)
        {
            Name = name;
            Email = email;
            ProfessorEmail = professorEmail;
        }
    }
}
