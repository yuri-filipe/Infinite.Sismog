using Sismog.Models;

namespace Sismog.Services.Interfaces
{
    public interface IUserService
    {
        string ValidarCredenciais(string login, string senha);
        Task<User> GetUser(string login);
        Task<bool> DesconectarUsuario(string login);

    }

    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}