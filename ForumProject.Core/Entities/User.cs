using System;
using System.Collections.Generic;
using System.Text;

namespace ForumProject.Core.Entities
{
    public class User : Identity
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate{ get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
