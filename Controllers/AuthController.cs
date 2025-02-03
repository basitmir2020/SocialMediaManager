using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaAutoPosterApp.Controllers
{
    public class AuthController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}