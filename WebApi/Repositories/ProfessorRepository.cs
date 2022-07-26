using UniversityWebApi.Domain;
using System.Data.SqlClient;
using System.Data;

namespace UniversityWebApi.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {

        private readonly string _connectionString;

        public ProfessorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Professor> GetAll()
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
        public int Create(Professor professor)
        {
            if (professor == null)
            {
                throw new ArgumentNullException(nameof(professor));
            }
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Professor] values (@email, @name, @subject, @departmentname)";
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = professor.Email;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = professor.Name;
            sqlCommand.Parameters.Add("@subject", SqlDbType.NVarChar, 100).Value = professor.Subject;
            sqlCommand.Parameters.Add("@departmentname", SqlDbType.NVarChar, 100).Value = professor.DepartmentName;
            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }

        public void Delete(Professor professor)
        {
            if (professor == null)
            {
                throw new ArgumentNullException(nameof(professor));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete from [Professor] where [Email] = @email";
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = professor.Email;
            sqlCommand.ExecuteNonQuery();
        }

        public Professor GetByEmail(string email)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Email], [Name], [Subject], [DepartmentName] from [Professor] " +
                "where [Email] = @email";
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Professor(Convert.ToString(reader["Email"]), Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Subject"]), Convert.ToString(reader["DepartmentName"]));
            }
            else
            {
                return null;
            }
        }

        public int Update(Professor professor)
        {
            if (professor == null)
            {
                throw new ArgumentNullException(nameof(professor));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Professor] set [Name] = @name, " +
                "[Subject] = @subject, [DepartmentName] = @departmentname where [Email] = @email";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = professor.Name;
            sqlCommand.Parameters.Add("@subject", SqlDbType.NVarChar, 100).Value = professor.Subject;
            sqlCommand.Parameters.Add("@departmentname", SqlDbType.NVarChar, 100).Value = professor.DepartmentName;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = professor.Email;
            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }
    }
}
