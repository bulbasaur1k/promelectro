using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(user);
        }
    }
}