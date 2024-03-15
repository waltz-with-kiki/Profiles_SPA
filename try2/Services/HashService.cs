using try2.Services.Interfaces;
namespace try2.Services
{
    public class HashService : IHashService
    {

        private readonly IConfiguration _configuration;

        public HashService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConstant()
        {
            return _configuration["Hashing:Constant"]; 
        }

        public string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public string CreateHashedPassword(string password, string salt)
        {
            string constant = GetConstant();

            if(constant == null)
            {
                return null;
            }

            string passwordWithConstant = password + GetConstant();

            return BCrypt.Net.BCrypt.HashPassword(passwordWithConstant, salt);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            string passWithConstant = password + GetConstant();

            return BCrypt.Net.BCrypt.Verify(passWithConstant, passwordHash);
        }
    }
}
