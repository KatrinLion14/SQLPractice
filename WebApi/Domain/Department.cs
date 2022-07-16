namespace UniversityWebApi.Domain
{
    public class Department
    {
        public string Name { get; set; }
        public int Office { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Department(string name, int office, string address, string phoneNumber)
        {
            Name = name;
            Office = office;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
