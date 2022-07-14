using UniversityDB.Models;
using UniversityDB.Repositories;

const string connectionString = @"Data Source=LAPTOP-5GE8TOQE\SQLEXPRESS;Initial Catalog=University;Pooling=true;Integrated Security=SSPI;TrustServerCertificate=True";

IDepartmentRepository departmentRepository = new RawSqlDepartmentRepository(connectionString);
IProfessorRepository professorRepository = new RawSqlProfessorRepository(connectionString);
IStudentGroupRepository studentGroupRepository = new RawSqlStudentGroupRepository(connectionString);
IStudentRepository studentRepository = new RawSqlStudentRepository(connectionString);

PrintCommands();

while (true)
{
    string command = Console.ReadLine();
    if (command == "get-departments")
    {
        IReadOnlyList<Department> departments = departmentRepository.GetAll();
        if (departments.Count == 0)
        {
            Console.WriteLine("Nothing was found");
            continue;
        }
        foreach (Department department in departments)
        {
            Console.WriteLine($"Name: {department.Name}, Office: {department.Office}, " +
                $"Address: {department.Address}, Phone Number: {department.PhoneNumber}");
        }
        Console.WriteLine("\nWrite new command:");
    }
    else if (command == "get-departments-by-address")
    {
        Console.WriteLine("Enter address:");
        string address = Console.ReadLine();
        while (string.IsNullOrEmpty(address))
        {
            Console.WriteLine("Empty address. Write again:");
            address = Console.ReadLine();
        }
        IReadOnlyList<Department> departments = departmentRepository.GetByAddress(address);
        if (departments.Count == 0)
        {
            Console.WriteLine("No departments with such address. Check data and try again.");
            continue;
        }
        foreach (Department department in departments)
        {
            Console.WriteLine($"Name: {department.Name}, Office: {department.Office}, " +
                $"Address: {department.Address}, Phone Number: {department.PhoneNumber}");
        }
        Console.WriteLine("\nWrite new command:");
    }
    else if (command == "get-department-by-name")
    {
        Console.WriteLine("Enter address:");
        string name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Empty name. Write again:");
            name = Console.ReadLine();
        }
        Department department = departmentRepository.GetByName(name);
        if (department == null)
        {
            Console.WriteLine("Such department doesn't exist. Check data and try again.");
            continue;
        }
        Console.WriteLine($"Name: {department.Name}, Office: {department.Office}, " +
                $"Address: {department.Address}, Phone Number: {department.PhoneNumber}");
        Console.WriteLine("\nWrite new command:");
    }
    else if (command == "delete-department-by-name")
    {
        Console.WriteLine("Enter department's name:");
        string name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Empty name. Write again:");
            name = Console.ReadLine();
        }
        Department department = departmentRepository.GetByName(name);
        if (department == null)
        {
            Console.WriteLine("Such department doesn't exist. Check data and try again.");
        }
        else
        {
            departmentRepository.Delete(department);
            Console.WriteLine("Department was deleted.");
            Console.WriteLine("\nWrite new command:");
        }
    }
    else if (command == "update-department-by-name")
    {
        Console.WriteLine("Enter department's name:");
        string name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Empty name. Write again:");
            name = Console.ReadLine();
        }
        Console.WriteLine("Enter new office number (or press enter for next parameter):");
        int office = -1;
        string temp = Console.ReadLine();
        while ((office == -1) && (!string.IsNullOrEmpty(temp)))
        {
            try
            {
                office = Convert.ToInt32(temp);
            }
            catch (FormatException)
            {
                Console.WriteLine("Positive number is requiered. Try again (or press enter for next parameter):");
                office = -1;
                temp = Console.ReadLine();
            }
            if (office < 0)
            {
                Console.WriteLine("Positive number is requiered. Try again (or press enter for next parameter):");
                office = -1;
                temp = Console.ReadLine();
            }
        }
        Console.WriteLine("Enter new address (or press enter for next parameter):");
        string address = Console.ReadLine();
        Console.WriteLine("Enter new phone number (or press enter for next parameter):");
        string phoneNumber = Console.ReadLine();
        Department department = departmentRepository.GetByName(name);
        if (department == null)
        {
            Console.WriteLine("Such department doesn't exist. Check data and try again.");
            continue;
        }
        if (office > -1)
        {
            department.UpdateOffice(office);
        }
        if (!string.IsNullOrEmpty(address))
        {
            department.UpdateAddress(address);
        }
        if (!string.IsNullOrEmpty(phoneNumber))
        {
            department.UpdatePhoneNumber(phoneNumber);
        }
        departmentRepository.Update(department);
        Console.WriteLine("Department was updated.");
        Console.WriteLine("\nWrite new command:");
    }
    else if (command == "get-professors")
    {
        IReadOnlyList<Professor> professors = professorRepository.GetAll();
        if (professors.Count == 0)
        {
            Console.WriteLine("Nothing was found");
            continue;
        }
        foreach (Professor professor in professors)
        {
            Console.WriteLine($"Email: {professor.Email}, Name: {professor.Name}, " +
                $"Subject: {professor.Subject}, Department Name: {professor.DepartmentName}");
        }
        Console.WriteLine("\nWrite new command:");
    }
    else if (command == "get-student-groups")
    {
        IReadOnlyList<StudentGroup> studentGroups = studentGroupRepository.GetAll();
        if (studentGroups.Count == 0)
        {
            Console.WriteLine("Nothing was found");
            continue;
        }
        foreach (StudentGroup studentGroup in studentGroups)
        {
            Console.WriteLine($"Name: {studentGroup.Name}, Email: {studentGroup.Email}, " +
                $"Professor's Email: {studentGroup.ProfessorEmail}");
        }
        Console.WriteLine("\nWrite new command:");
    }
    else if (command == "get-groups-with-students-amount")
    {
        Console.WriteLine("Enter minimal amount of students:");
        int amount = -1;
        string temp = Console.ReadLine();
        while (amount < 0)
        {
            try
            {
                amount = Convert.ToInt32(temp);
            }
            catch (FormatException)
            {
                Console.WriteLine("Positive number or 0 is requiered. Try again:");
                amount = -1;
                temp = Console.ReadLine();
            }
            if (amount < 0)
            {
                Console.WriteLine("Positive number or 0 is requiered. Try again:");
                amount = -1;
                temp = Console.ReadLine();
            }
        }
        IReadOnlyList<Tuple<StudentGroup, int>> studentGroups = studentGroupRepository.GetGroupsWithStudentsAmount(amount);
        if (studentGroups.Count == 0)
        {
            Console.WriteLine("Nothing was found");
            continue;
        }
        foreach (var studentGroup in studentGroups)
        {
            Console.WriteLine($"Name: {studentGroup.Item1.Name}, Email: {studentGroup.Item1.Email}, " +
                $"Professor's Email: {studentGroup.Item1.ProfessorEmail}, Student's amount: {studentGroup.Item2}");
        }
        Console.WriteLine("\nWrite new command:");
    }
    else if (command == "get-students")
    {
        IReadOnlyList<Student> students = studentRepository.GetAll();
        if (students.Count == 0)
        {
            Console.WriteLine("Nothing was found");
            continue;
        }
        foreach (Student student in students)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, " +
                $"Email: {student.Email}, Group: {student.GroupName}");
        }
        Console.WriteLine("\nWrite new command:");
    }
    else if (command == "help")
    {
        PrintCommands();
    }
    else if (command == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Wrong command");
    }
}

void PrintCommands()
{
    Console.WriteLine("Commands:");
    Console.WriteLine("\tDepartment:");
    Console.WriteLine("\t\tget-departments - Get all departments");
    Console.WriteLine("\t\tget-departments-by-address - Get all departments with this address");
    Console.WriteLine("\t\tget-department-by-name - Get department by name");
    Console.WriteLine("\t\tdelete-department-by-name - Delete department by name");
    Console.WriteLine("\t\tupdate-department-by-name - Update department by name");
    Console.WriteLine("\tProfessor:");
    Console.WriteLine("\t\tget-professors - Get all professors");
    Console.WriteLine("\tStudent Group:");
    Console.WriteLine("\t\tget-student-groups - Get all student groups");
    Console.WriteLine("\t\tget-groups-with-students-amount - Get all student groups with entered minimal amount of students");
    Console.WriteLine("\tStudent:");
    Console.WriteLine("\t\tget-students - Get all students");
    Console.WriteLine("help - List of commands");
    Console.WriteLine("exit - Exit the programm");
}