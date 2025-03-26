using Microsoft.AspNetCore.Mvc;

namespace PetNameGenerator.Controllers
{
    [ApiController]
    [Route("api/petnameGenerator")]
    public class PetNameGenerator : ControllerBase
    {
        private string[] petnameGenerator = new string[]
        {

        };
        public IActionResult Index()
        {
            return View();
        }
    }
}
