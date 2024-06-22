using Microsoft.AspNetCore.Mvc;

namespace CM3070_Client.Controllers
{
    public class ProviderDetailController : Controller
    {
        public IActionResult Index ()
        {
            //return PartialView ("Popups/_ProviderDetail");

            return View();
        }
    }
}
