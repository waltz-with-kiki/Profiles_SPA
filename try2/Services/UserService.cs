using try2.DAL.Interfaces;
using try2.Domain.Entities;
using try2.Services.Interfaces;

namespace try2.Services
{
    public class UserService : IUserService
    {

        public UserService(IRepository<User> users, IHashService hashService, IJwtService JwtService)
        {
            _RepUsers = users;
            _HashService = hashService;
            _JwtService = JwtService;
        }

        private readonly IRepository<User> _RepUsers;
        private readonly IHashService _HashService;
        private readonly IJwtService _JwtService;


        public record LoginResult
        {
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
        }

        public LoginResult Login(string Login, string password)
        {
            if (Login.Length < 4 || password.Length < 4)
            {
                return new LoginResult { Success = false, ErrorMessage = "Логин и пароль должны содержать не менее 4 символов." };
            }

            User Currentuser = _RepUsers.Items.Where(x => x.Login == Login).FirstOrDefault();

            if (Currentuser == null)
            {
                return new LoginResult { Success = false, ErrorMessage = "Пользователь с таким логином не найден." };
            }

            var logSuccess = _HashService.VerifyPassword(password, Currentuser.Sugar, Currentuser.Password);

            if (!logSuccess)
            {
                return new LoginResult { Success = false, ErrorMessage = "Неправильный пароль." };
            }

            return new LoginResult { Success = true };
        }

        public string JwtToken(User user)
        {
            var token = _JwtService.GenerateToken(user);
            return token;
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
