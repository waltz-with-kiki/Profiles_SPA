using try2.Domain.Entities;

namespace try2.Services.Interfaces
{
    public interface IUserService
    {

        public User Login(string Login, string password);

        public bool Registration(string Login, string password, string Email);

    }
}
