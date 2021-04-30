using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser:IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string SalesVideo { get; set; }
        public string ProfilePicture { get; set; }
        public ICollection<AppUserCategory> Categories { get; set; }
        public ICollection<AppUserLevel> Levels { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}