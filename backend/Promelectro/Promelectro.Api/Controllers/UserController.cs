using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promelectro.Api.Data;
using Promelectro.Api.Models;

namespace Promelectro.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ClaimsPrincipal _caller;


        public UserController(UserManager<User> userManager, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _caller = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        public async Task<IActionResult> Me()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByNameAsync(userId);
            var roles = await _appDbContext.UserRoles.Where(x => x.UserId == user.Id)
                .Join(_appDbContext.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => new
                {
                    id = r.Id,
                    roleName = r.Name,
                    description = r.Description
                }).ToListAsync();
            
            return Ok(new
            {
                userName = user.UserName,
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                pictureUrl = user.PictureUrl,
                phone = user.PhoneNumber,
                surname = user.Surname,
                roles
            });
        }
    }
}