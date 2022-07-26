using UniversityWebApi.Domain;
using System.Data.SqlClient;
using System.Data;

namespace UniversityWebApi.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Create(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Department] values (@name, @office, @address, @phonenumber)";
            sqlCommand.Parameters.Add("@office", SqlDbType.Int).Value = department.Office;
            sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = department.Address;
            sqlCommand.Parameters.Add("@phonenumber", SqlDbType.NVarChar, 14).Value = department.PhoneNumber;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = department.Name;
            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }

        public void Delete(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete from [Department] where [Name] = @name";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = department.Name;
            sqlCommand.ExecuteNonQuery();
        }

        public List<Department> GetAll()
        {
            var result = new List<Department>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Name], [Office], [Addres], [PhoneNumber] from [Department]";
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Department(Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Office"]),
                    Convert.ToString(reader["Addres"]), Convert.ToString(reader["PhoneNumber"])));
            }
            return result;
        }

        public Department GetByName(string name)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Name], [Office], [Addres], [PhoneNumber] from [Department] " +
                "where [Name] = @name";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Department(Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Office"]),
                    Convert.ToString(reader["Addres"]), Convert.ToString(reader["PhoneNumber"]));
            }
            else
            {
                return null;
            }
        }

        public List<Tuple<string, int>> GetDepartmentCountGroupByAddress()
        {
            var result = new List<Tuple<string, int>>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Addres], count(*) as [Count] from [Department] group by [Addres]";
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Tuple<string, int>(Convert.ToString(reader["Addres"]), Convert.ToInt32(reader["Count"])));
            }
            return result;
        }

        public int Update(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Department] set [Office] = @office, " +
                "[Addres] = @address, [PhoneNumber] = @phonenumber where [Name] = @name";
            sqlCommand.Parameters.Add("@office", SqlDbType.Int).Value = department.Office;
            sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = department.Address;
            sqlCommand.Parameters.Add("@phonenumber", SqlDbType.NVarChar, 14).Value = department.PhoneNumber;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = department.Name;
            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }
    }
}
