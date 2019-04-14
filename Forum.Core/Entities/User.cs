using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    public class User
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate{ get; set; }
        public List<Role> Roles { get; set; }
    }
}
