using UniversityDB.Models;
using System.Data.SqlClient;
using System.Data;

namespace UniversityDB.Repositories
{
    internal class RawSqlProfessorRepository : IProfessorRepository
    {
        private readonly string _connectionString;

        public RawSqlProfessorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IReadOnlyList<Professor> GetAll()
        {
            var result = new List<Professor>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Email], [Name], [Subject], [DepartmentName] from [Professor]";
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Professor(Convert.ToString(reader["Email"]), Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Subject"]), Convert.ToString(reader["DepartmentName"])));
            }
            return result;
        }
    }
}
