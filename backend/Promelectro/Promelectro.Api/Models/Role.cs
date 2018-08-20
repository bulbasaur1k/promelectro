using Microsoft.AspNetCore.Identity;

namespace Promelectro.Api.Models
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; } 
    }
}