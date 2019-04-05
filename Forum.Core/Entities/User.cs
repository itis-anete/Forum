using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    class User
    {
        public string Nickname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime RegistrationDate{ get; private set; }
        public Role Role { get; private set; }
    }
}
