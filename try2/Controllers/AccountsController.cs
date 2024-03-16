
using Microsoft.AspNetCore.Mvc;
using try2.DAL.Interfaces;
using try2.Domain.Entities;
using try2.Domain.Models.Entities;
using try2.Domain.Models.Entities.Base;
using try2.Services.Interfaces;

namespace try2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountsController : ControllerBase
    {
        private readonly IRepository<User> _RepUsers;

        private readonly IRepository<Profile> _RepProfiles;

        private readonly IUserService _UserService;

        public AccountsController(IRepository<User> Users, IRepository<Profile> Profiles, IUserService UserService)
        {
            _RepUsers = Users;
            _RepProfiles = Profiles;
            _UserService = UserService;
        }


        [HttpGet("profiles")]

        //[ResponseCache(Duration = 60)]
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

        }
        public record RemoveProfileRequest
        {
           public string nickName { get; set; }
        }

        [HttpPost("profiles/remove")]
        public IActionResult RemoveProfile([FromBody] RemoveProfileRequest request)
        {
            Profile RemoveProfile = _RepProfiles.Items.Where(x => x.NickName == request.nickName).FirstOrDefault();

            if( RemoveProfile != null)
            {
                _RepProfiles.Remove(RemoveProfile.Id);
                return Ok();
            }
            
            return NotFound();
        }

        [HttpGet("users")]
        public ICollection<User> GetUsers()
        {
            return _RepUsers.Items.ToList();
        }

        public record LogDetails
        {
            public string Login { get; set; }

            public string Password { get; set; }
        }

        public record RegDetails : LogDetails
        {
            public string Email { get; set; }

        }

        [HttpPost("user/registration")]
        public IActionResult Registration([FromBody] RegDetails user)
        {
            if(_UserService.Registration(user.Login, user.Password, user.Email))
            { 
                return Ok();
            }
            return NoContent();
        }



        [HttpPost("user/login")]
        public IActionResult Login([FromBody] LogDetails user)
        {
            var result = _UserService.Login(user.Login, user.Password);
            if (result.Success)
            {
                var AuthUser = _RepUsers.Items.Where(x => x.Login == user.Login).FirstOrDefault();

                var token = _UserService.JwtToken(AuthUser);

                return Ok(new { token });
            }
            return BadRequest(result.ErrorMessage);
        }



    }
}
