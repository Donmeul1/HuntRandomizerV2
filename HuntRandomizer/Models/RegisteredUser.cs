using Microsoft.AspNetCore.Identity;

namespace HuntRandomizer.Models
{
    public class RegisteredUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
