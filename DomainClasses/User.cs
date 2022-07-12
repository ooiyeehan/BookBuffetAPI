using System;
using System.Collections.Generic;

#nullable disable

namespace BookBuffetWeb2.DomainClasses
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImageUrl { get; set; }

    }
}
