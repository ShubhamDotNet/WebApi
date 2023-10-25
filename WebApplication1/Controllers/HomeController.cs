using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        //[NonAction]
        public IActionResult Index()
        {
            return View();
        }
    }
}
