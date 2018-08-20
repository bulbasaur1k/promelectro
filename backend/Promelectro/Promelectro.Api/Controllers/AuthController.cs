using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Promelectro.Api.Auth;
using Promelectro.Api.Data;
using Promelectro.Api.Helpers;
using Promelectro.Api.Models;
using Promelectro.Api.ViewModels;

namespace Promelectro.Api.Controllers
{        
        [Route("api/[controller]/[action]")]    
        public class AuthController : Controller
        {
            private readonly UserManager<User> _userManager;
            private readonly IMapper _mapper;
            private readonly IJwtFactory _jwtFactory;
            private readonly ApplicationDbContext _dBContext;
            private readonly JwtIssuerOptions _jwtOptions;

            public AuthController(UserManager<User> userManager,IMapper mapper, IJwtFactory jwtFactory, ApplicationDbContext dBContext, IOptions<JwtIssuerOptions> jwtOptions)
            {
                _userManager = userManager;
                _mapper = mapper;
                _jwtFactory = jwtFactory;
                _dBContext = dBContext;
                _jwtOptions = jwtOptions.Value;
            }

            [HttpPost]
            public async Task<IActionResult> Login([FromBody]CredentialsViewModel credentials)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var jwt = await GetClaimsIdentity(credentials.UserName, credentials.Password);
                if (jwt == null)
                {
                    return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
                }

               // var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
                return new OkObjectResult(new {status = "success", token = jwt });
            }

            [HttpPost]
            public async Task<IActionResult> Register([FromBody] RegistrationViewModel model)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userIdentity = _mapper.Map<User>(model);
                var result = await _userManager.CreateAsync(userIdentity, model.Password);
                await _userManager.AddToRoleAsync(userIdentity, "USER");
                if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                await _dBContext.SaveChangesAsync();

                return new OkObjectResult("created");
            }
            
            private async Task<string> GetClaimsIdentity(string userName, string password)
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                    return await Task.FromResult<string>(null);

                // get the user to verifty
                var userToVerify = await _userManager.FindByNameAsync(userName);

                if (userToVerify == null) return await Task.FromResult<string>(null);

                // check the credentials
                if (await _userManager.CheckPasswordAsync(userToVerify, password))
                {
                    return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id.ToString()));
                }

                // Credentials are invalid, or account doesn't exist
                return await Task.FromResult<string>(null);
            }
        
    }
}