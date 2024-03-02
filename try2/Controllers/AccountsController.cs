using Microsoft.AspNetCore.Mvc;
using try2.DAL.Interfaces;
using try2.Domain.Entities;
using try2.Domain.Models.Entities;
using try2.Domain.Models.Entities.Base;

namespace try2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountsController : ControllerBase
    {
        private readonly IRepository<User> _RepUsers;

        private readonly IRepository<Profile> _RepProfiles;

        public AccountsController(IRepository<User> Users, IRepository<Profile> Profiles)
        {
            _RepUsers = Users;
            _RepProfiles = Profiles;
        }


        [HttpGet("profiles")]
        public ICollection<Profile> GetProfiles()
        {
            return _RepProfiles.Items.ToList();
        }

        [HttpPost("profiles")]
        public IActionResult Add([FromBody] FakeProfile profile)
        {
            Profile NewProfile = new Profile{
                NickName = profile.NickName,
                Avatar = Convert.FromBase64String(profile.Avatar),
                TimeCreate = profile.TimeCreate
            };
          //  if (profile.NickName.Trim() != "" && profile.Avatar != null)
            {       
                // Добавление пользователя в репозиторий
                _RepProfiles.Add(NewProfile);
                // Возвращаем успешный статус
                return Ok();
            }

            return NoContent();
        }

        [HttpGet("user")]
        public ICollection<User> GetUsers()
        {
            return _RepUsers.Items.ToList();
        }

        [HttpPost("user")]
        public IActionResult Add([FromBody] User user)
        {

            if (user.Login.Trim() != "" && user.Email.Trim() != "" && user.Password.Trim() != "")
            {
                user.UserType = Domain.Models.Enums.TypeUser.CasualUser;
                // Добавление пользователя в репозиторий
                _RepUsers.Add(user);
                // Возвращаем успешный статус
                return Ok();
            }

            return NoContent();
        }

    }
}
