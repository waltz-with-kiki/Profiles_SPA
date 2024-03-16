namespace try2.Services.Interfaces
{
    public interface IHashService
    {

        public string GenerateSalt();

        public string CreateHashedPassword(string password, string salt);

        public bool VerifyPassword(string password, string salt, string passwordHash);

    }
}
