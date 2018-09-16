﻿namespace Forum.App.DataBase.Entities
{
    public class User : Identity
    {
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }

        public override int GetHashCode() => base.GetHashCode();
    }
}