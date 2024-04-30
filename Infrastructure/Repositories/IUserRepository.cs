// using MySql.Data.MySqlClient;

using Google.Protobuf.WellKnownTypes;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllUsers();
        IEnumerable<Users> GetUserById(int id);
        Users CreateUser(Users user);
        bool DeleteUser(int id);
    }
}