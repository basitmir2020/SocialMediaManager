using Microsoft.AspNetCore.Mvc;

namespace SocialMediaAutoPosterApp.Areas.Agency.Controllers
{
    public class AgencyController : ControllerBase 
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}