using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedStream.Entities
{
    class AppUser : IdentityUser
    {
        public string Username { get; set; }
        public string GoogleAccount { get; set; }

    }
}
