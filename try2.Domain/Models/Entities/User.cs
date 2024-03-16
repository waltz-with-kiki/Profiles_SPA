using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using try2.Domain.Entities.Base;
using try2.Domain.Models.Entities;
using try2.Domain.Models.Enums;

namespace try2.Domain.Entities
{
    public class User : Entity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string? Email { get; set; }

        public TypeUser UserType { get; set; }

        public string Sugar { get; set; }

        //public ICollection<Profile>? Profiles { get; set; }

    }
}
