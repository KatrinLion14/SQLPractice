using UniversityDB.Models;
using System.Data.SqlClient;
using System.Data;

namespace UniversityDB.Repositories
{
    internal class RawSqlStudentGroupRepository : IStudentGroupRepository
    {
        private readonly string _connectionString;

        public RawSqlStudentGroupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IReadOnlyList<StudentGroup> GetAll()
        {
            var result = new List<StudentGroup>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Name], [Email], [ProfessorEmail] from [StudentGroup]";
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new StudentGroup(Convert.ToString(reader["Name"]), Convert.ToString(reader["Email"]),
                    Convert.ToString(reader["ProfessorEmail"])));
            }
            return result;
        }

        public IReadOnlyList<Tuple<StudentGroup, int>> GetGroupsWithStudentsAmount(int amount)
        {
            var result = new List<Tuple<StudentGroup, int>>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [GroupId], count(*) as [count]" +
                "from [Student] group by [GroupId] having count(*) >= @amount";
            sqlCommand.Parameters.Add("@amount", SqlDbType.Int).Value = amount;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                using var connectionTemp = new SqlConnection(_connectionString);
                connectionTemp.Open();
                using SqlCommand sqlCommandTemp = connectionTemp.CreateCommand();
                sqlCommandTemp.CommandText = "select [Name], [Email], [ProfessorEmail] from [StudentGroup] " +
                    "where [Name] = @name";
                sqlCommandTemp.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = Convert.ToString(reader["GroupId"]);
                using SqlDataReader reader_temp = sqlCommandTemp.ExecuteReader();
                reader_temp.Read();
                var temp = new Tuple<StudentGroup, int>(new StudentGroup(Convert.ToString(reader_temp["Name"]), Convert.ToString(reader_temp["Email"]),
                    Convert.ToString(reader_temp["ProfessorEmail"])), Convert.ToInt32(reader["count"]));
                result.Add(temp);
            }
            return result;
        }
    }
}
