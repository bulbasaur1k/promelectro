using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Promelectro.Api.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger _logger;  
        public HomeController(ILogger logger)  
        {  
            _logger = logger;  
        }  
        
    }
}