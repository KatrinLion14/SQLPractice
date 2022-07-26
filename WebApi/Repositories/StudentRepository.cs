using UniversityWebApi.Domain;
using System.Data.SqlClient;
using System.Data;

namespace UniversityWebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Create(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Student] values (@id, @name, @email, @groupid)";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = student.Name;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = student.Email;
            sqlCommand.Parameters.Add("@groupid", SqlDbType.NVarChar, 100).Value = student.GroupName;
            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }

        public void Delete(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete from [Student] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
            sqlCommand.ExecuteNonQuery();
        }

        public List<Student> GetAll()
        {
            var result = new List<Student>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [Email], [GroupId] from [Student]";
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Student(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Email"]), Convert.ToString(reader["GroupId"])));
            }
            return result;
        }

        public Student GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [Email], [GroupId] from [Student] " +
                "where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Student(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Email"]), Convert.ToString(reader["GroupId"]));
            }
            else
            {
                return null;
            }
        }

        public int Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Student] set [Name] = @name, " +
                "[Email] = @email, [GroupId] = @groupid where [Id] = @id";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = student.Name;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = student.Email;
            sqlCommand.Parameters.Add("@groupid", SqlDbType.NVarChar, 100).Value = student.GroupName;
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }
    }
}
