using try2.Domain.Entities;

namespace try2.Services.Interfaces
{
    public interface IJwtService
    {

        string GenerateToken(User user);

    }
}
