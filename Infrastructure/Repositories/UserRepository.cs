// using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.Types;
using System.Collections.Generic;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public class UserRepository //: IUserRepository
    {
        private readonly string _connectionString = "server=localhost;database=Empresa;user=sa;password=Passw0rd";

        public IEnumerable<Users> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Users";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Users
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString(),
                                Email = reader["email"].ToString(),
                                Password = reader["password"].ToString()
                            };
                        }
                    }
                }
            }
        }

        // ... (implementar otros métodos de acceso a datos)
    }

    //private class Users {
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string Password { get; set; }

    //}
}
