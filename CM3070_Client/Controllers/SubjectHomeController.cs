using Microsoft.AspNetCore.Mvc;

namespace CM3070_Client.Controllers
{
    public class SubjectHomeController : Controller
    {
        public IActionResult Index ()
        {
            return View();
        }
    }
}
