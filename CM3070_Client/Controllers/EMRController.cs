using Microsoft.AspNetCore.Mvc;

namespace CM3070_Client.Controllers
{
    public class EMRController : Controller
    {
        public IActionResult Index ()
        {
            return View();
        }
    }
}
