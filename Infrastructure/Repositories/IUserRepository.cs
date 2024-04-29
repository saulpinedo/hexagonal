// using MySql.Data.MySqlClient;

using Google.Protobuf.WellKnownTypes;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllUsers();
        Users CreateUser(Users user);
    }
}