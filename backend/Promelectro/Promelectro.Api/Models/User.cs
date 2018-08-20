using Microsoft.AspNetCore.Identity;

namespace Promelectro.Api.Models
{
    public class User : IdentityUser<int>
    {
        // Extended Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string PictureUrl { get; set; }
    }
}