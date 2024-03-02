﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using try2.Domain.Entities;
using try2.Domain.Entities.Base;

namespace try2.Domain.Models.Entities
{
    public class Profile :Entity
    {
        public string NickName { get; set; }

        //public int UserId { get; set; }

        public byte[] Avatar { get; set; }

        public DateTime TimeCreate { get; set; }

        //public virtual User ThisUser { get; set; }

    }
}
