using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TextApp.Infrastructure.Texts;

namespace TextApp.Infrastructure.Users
{
    public class User : IdentityUser
    {
        public virtual ICollection<Text> Texts { get; set; } = new HashSet<Text>();
    }
}
