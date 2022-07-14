namespace UniversityDB.Models
{
    public class Department
    {
        public string Name { get; private set; }
        public int Office { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public Department(string name, int office, string address, string phoneNumber)
        {
            Name = name;
            Office = office;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        public void UpdateOffice(int office)
        {
            Office = office;
        }
        public void UpdateAddress(string address)
        {
            Address = address;
        }
        public void UpdatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
