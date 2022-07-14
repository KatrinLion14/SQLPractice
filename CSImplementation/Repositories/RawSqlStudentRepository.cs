using UniversityDB.Models;
using System.Data.SqlClient;
using System.Data;

namespace UniversityDB.Repositories
{
    internal class RawSqlStudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public RawSqlStudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IReadOnlyList<Student> GetAll()
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
    }
}
