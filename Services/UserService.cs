using Microsoft.IdentityModel.Tokens;
using Sismog.Models;
using Sismog.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sismog.Services
{
    public class UserService : IUserService
    {
        private static readonly IDictionary<string, (string HashSenha, User User)> Users =
    new Dictionary<string, (string HashSenha, User User)>();

        private readonly IDatabaseService _databaseService;
        private readonly ILogger<UserService> _logger;

        public UserService(IDatabaseService databaseService, ILogger<UserService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public string ValidarCredenciais(string login, string senha)
        {
            try
            {
                var conexao = _databaseService.ConnectDatabase(login, senha);

                var roles = _databaseService.GetRoles(login);

                var user = new User(login);

                user.Papeis.AddRange(roles);

                _ = AddUser(senha, user);

                // var token = GenerateToken(user);

                conexao.Close();

                return "success";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return "error";
            }
        }

        private Task AddUser(string senha, User user)
        {
            if (Users.ContainsKey(user.Login))
                return Task.FromResult(false);

            Users.Add(user.Login, (senha, user));
            return Task.CompletedTask;
        }

        public Task<User> GetUser(string login)
        {
            return !Users.ContainsKey(login) ? throw new Exception("Usuário não está autenticado!") : Task.FromResult(Users[login].User);
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login.ToString()),
                    new Claim(ClaimTypes.Role, user.Papeis.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public Task<bool> DesconectarUsuario(string login)
        {
            if (!Users.ContainsKey(login))
                return Task.FromResult(false);

            _ = _databaseService.CloseConnection(login);

            _ = Users.Remove(login);

            return Task.FromResult(true);
        }

    }
}