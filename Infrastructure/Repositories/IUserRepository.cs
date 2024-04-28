// using MySql.Data.MySqlClient;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllUsers();
    }
}