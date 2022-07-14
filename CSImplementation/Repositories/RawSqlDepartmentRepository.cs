using UniversityDB.Models;
using System.Data.SqlClient;
using System.Data;

namespace UniversityDB.Repositories
{
    internal class RawSqlDepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;

        public RawSqlDepartmentRepository(string connectionString)
        {
            _connectionString = connectionString;
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
            sqlCommand.Parameters.Add("@name", SqlDbType.Int).Value = department.Name;
            sqlCommand.ExecuteNonQuery();
        }

        public IReadOnlyList<Department> GetAll()
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

        public IReadOnlyList<Department> GetByAddress(string address)
        {
            var result = new List<Department>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Name], [Office], [Addres], [PhoneNumber] from [Department] " +
                "where [Addres] = @address";
            sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = address;
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

        public void Update(Department department)
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
            sqlCommand.ExecuteNonQuery();
        }
    }
}
