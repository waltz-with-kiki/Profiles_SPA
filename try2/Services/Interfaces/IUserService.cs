using try2.Domain.Entities;
using static try2.Services.UserService;

namespace try2.Services.Interfaces
{
    public interface IUserService
    {

        public LoginResult Login(string Login, string password);

        public bool Registration(string Login, string password, string Email);

        public string JwtToken(User user);

    }
}
