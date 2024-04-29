using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
//using System.Data;
using MySql.Data.Types;
using System.Collections.Generic;
using System.Data;
using Google.Protobuf.WellKnownTypes;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public class UserRepositoryMariaDB:IUserRepository
    {
        private readonly string _connectionString = "server=localhost;database=Empresa;user=root;password=root;";

        public IEnumerable<Users> GetAllUsers()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM User";
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

        public Users CreateUser(Users user) {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    // Insert statement with parameterized query for security
                    command.CommandText = "INSERT INTO User (Id,Name, Email, Password) VALUES (@Id,@Name, @Email, @Password)";
                    command.Parameters.AddWithValue("Id", user.Id);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);

                    command.ExecuteNonQuery(); // Execute the insert statement

                    // Optionally retrieve the newly created user's details
                    command.CommandText = "SELECT * FROM User WHERE Email = @Email"; // Assuming Email is unique
                    command.Parameters.Clear(); // Clear previous parameters
                    command.Parameters.AddWithValue("@Email", user.Email);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Users
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader.IsDBNull("Password") ? null : reader["Password"].ToString() // Handle null password
                            };
                        }
                        else
                        {
                            // Handle case where user creation failed (e.g., throw exception)
                            throw new Exception("User creation failed.");
                        }
                    }
                }
            }
        }

        // ... (implementar otros métodos de acceso a datos)
    }
        //public class Users
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Email { get; set; }
        //    public string Password { get; set; }

        //}

}
