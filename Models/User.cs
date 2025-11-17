namespace Sismog.Models
{
    public class User
    {
        public string Login { get; set; }
        public List<string> Papeis { get; } = [];
        public User(string login)
        {
            Login = login;
        }
    }
}