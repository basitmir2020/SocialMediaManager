using Microsoft.AspNetCore.Mvc;

namespace SocialMediaAutoPosterApp.Areas.Admin.Controllers
{
    public class AdminController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}