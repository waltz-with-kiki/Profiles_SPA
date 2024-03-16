using try2.DAL.Interfaces;
using try2.Domain.Entities;
using try2.Services.Interfaces;

namespace try2.Services
{
    public class UserService : IUserService
    {

        public UserService(IRepository<User> users, IHashService hashService)
        {
            _RepUsers = users;
            _HashService = hashService;
        }

        private readonly IRepository<User> _RepUsers;
        private readonly IHashService _HashService;


        public User Login(string Login, string password)
        {

            return null;
        }

        public bool Registration(string Login, string password, string Email)
        {
            Login = Login.Trim();
            password = password.Trim();
            Email = Email.Trim();

            if (Login.Length > 3 && Login.Length <= 16)
            {
                if (password.Length > 3)
                {
                    User examination = _RepUsers.Items.Where(x => x.Login == Login).FirstOrDefault();

                    if (examination == null)
                    {
                        examination = _RepUsers.Items.Where(x => x.Email == Email).FirstOrDefault();

                        if (examination == null)
                        {
                            var salt = _HashService.GenerateSalt();

                            string hashedpassword = _HashService.CreateHashedPassword(password, salt);

                            User NewUser = new User { Login = Login, Email = Email, Password = hashedpassword, Sugar = salt, UserType = Domain.Models.Enums.TypeUser.CasualUser };

                            _RepUsers.Add(NewUser);

                            return true;
                        }

                    }

                }

            }
            return false;
        }
    }
}
